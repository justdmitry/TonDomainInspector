using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;
using Polly;
using TonLibDotNet;

namespace Server
{
    public class SearchMiddleware
    {
        private static readonly TimeSpan CacheExpiration = TimeSpan.FromMinutes(15);

        private readonly RequestDelegate next;
        private readonly IMemoryCache memoryCache;
        private readonly ILogger logger;

        public SearchMiddleware(RequestDelegate next, IMemoryCache memoryCache, ILogger<SearchMiddleware> logger)
        {
            this.next = next;
            this.memoryCache = memoryCache;
            this.logger = logger;
        }

        public Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/search" && context.Request.Method == "GET")
            {
                return Search(context);
            }
            else
            {
                return next(context);
            }
        }

        public async Task Search(HttpContext context)
        {
            var req = context.Request;

            var domain = req.Query["domain"];

            context.Response.Headers.AccessControlAllowOrigin = "*";

            if (!TonRecipes.RootDns.TryNormalizeName(domain, out var normalizedName))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = System.Net.Mime.MediaTypeNames.Text.Plain;
                await context.Response.WriteAsync("Invalid domain");
                return;
            }

            if (!memoryCache.TryGetValue(domain, out var info))
            {
                var tonClient = context.RequestServices.GetRequiredService<ITonClient>();
                var policy = Policy.Handle<Exception>().RetryAsync(5);

                var res = await policy.ExecuteAndCaptureAsync(async () =>
                {
                    await tonClient.InitIfNeeded();
                    return await TonRecipes.RootDns.GetAllInfoByName(tonClient, normalizedName).ConfigureAwait(false);
                });

                if (res.Outcome == OutcomeType.Successful)
                {
                    info = res.Result;
                    memoryCache.Set(domain, info, CacheExpiration);
                }
                else
                {
                    logger.LogError(res.FinalException, "Failed with exception");
                }
            }

            if (info == null)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = System.Net.Mime.MediaTypeNames.Text.Plain;
                await context.Response.WriteAsync("Failed to get info from blockchain");
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.ContentType = System.Net.Mime.MediaTypeNames.Application.Json;
                await JsonSerializer.SerializeAsync(context.Response.Body, info);
            }
        }
    }
}
