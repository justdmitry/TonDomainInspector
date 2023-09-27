<script lang="ts">
    import type { DomainInfo } from "$lib/DomainInfo";
    export let domain: DomainInfo | null;
</script>

{#if domain}
    <h3>{domain.FullName}</h3>
    <dl>
        <dt>Address</dt>
        <dd><pre>{domain.Address}</pre></dd>
        <dt>Deployed</dt>
        <dd>{domain.Deployed}</dd>
        <dt>Index</dt>
        <dd><pre>{domain.Index}</pre></dd>
        <dt>Collection address</dt>
        <dd><pre>{domain.Collection}</pre></dd>
        <dt>Domain</dt>
        <dd>{domain.Domain}</dd>
        <dt>Owner address</dt>
        <dd><pre>{domain.Owner}</pre></dd>
        <dt>Auction info</dt>
        {#if domain.AuctionInfo }
            <dd>
                <dl>
                    <dt>MaxBid</dt>
                    <dd>{domain.AuctionInfo.MaxBidAmount}</dd>
                    <dt>MaxBid address</dt>
                    <dd><pre>{domain.AuctionInfo.MaxBidAddress}</pre></dd>
                    <dt>End time</dt>
                    <dd>{domain.AuctionInfo.AuctionEndTime}</dd>
                </dl>
            </dd>
        {:else}
            <dd>No auction</dd>
        {/if}
        <dt>Last fill-up time</dt>
        <dd>{domain.LastFillUpTime}</dd>
        <dt>DNS entries</dt>
        <dd>
            <dl>
                <dt>wallet</dt>
                {#if domain.DnsEntries.Wallet }
                    <dd><pre>{domain.DnsEntries.Wallet}</pre></dd>
                {:else}
                    <dd>none</dd>
                {/if}

                <dt>site (ADNL)</dt>
                {#if domain.DnsEntries.SiteADNL }
                    <dd><pre>{domain.DnsEntries.SiteADNL}</pre></dd>
                {:else}
                    <dd>none</dd>
                {/if}

                <dt>site (Storage)</dt>
                {#if domain.DnsEntries.SiteStorage }
                    <dd><pre>{domain.DnsEntries.SiteStorage}</pre></dd>
                {:else}
                    <dd>none</dd>
                {/if}

                <dt>storage</dt>
                {#if domain.DnsEntries.Storage }
                    <dd><pre>{domain.DnsEntries.Storage}</pre></dd>
                {:else}
                    <dd>none</dd>
                {/if}

                <dt>dnsNextResolver</dt>
                {#if domain.DnsEntries.NextResolver }
                    <dd><pre>{domain.DnsEntries.NextResolver}</pre></dd>
                {:else}
                    <dd>none</dd>
                {/if}
            </dl>
        </dd>
    </dl>

    <hr />
{/if}
