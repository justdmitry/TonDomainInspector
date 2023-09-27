using TonLibDotNet.Types;
using TonLibDotNet;

namespace Server
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.ConfigureLogging(builder => builder.AddSystemdConsole());

            builder.Services.AddSingleton<ITonClient, TonClient>();
            builder.Services.Configure<TonOptions>(o =>
            {
                o.VerbosityLevel = 0;
                o.Options.KeystoreType = new KeyStoreTypeDirectory(".");
            });

            builder.Services.AddMemoryCache();

            var app = builder.Build();

            app.UseStatusCodePages();
            app.UseMiddleware<RobotsTxtMiddleware>();
            app.UseMiddleware<SearchMiddleware>();

            app.Run();
        }
    }
}