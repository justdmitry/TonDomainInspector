<script lang="ts">
    import type { DomainInfo } from "$lib/DomainInfo";
    import { slide } from 'svelte/transition';
    export let domain: DomainInfo | null;
</script>

{#if domain}
<div transition:slide>
    <h3>{domain.FullName}</h3>
    <dl>
        <dt>Address</dt>
        <dd><pre><a target="_blank" href="https://tonscan.org/address/{domain.Address}">{domain.Address}</a></pre></dd>
        <dt>Deployed</dt>
        <dd>{domain.IsDeployed}</dd>
        <dt>Index</dt>
        <dd><pre>{domain.Index}</pre></dd>
        <dt>Collection address</dt>
        <dd><pre>{domain.CollectionAddress}</pre></dd>
        <dt>Domain</dt>
        <dd>{domain.Domain}</dd>
        <dt>Owner address</dt>
        {#if domain.OwnerAddress }
            <dd><pre><a target="_blank" href="https://tonscan.org/address/{domain.OwnerAddress}">{domain.OwnerAddress}</a></pre></dd>
        {:else}
            <dd>none</dd>
        {/if}
        <dt>Auction info</dt>
        {#if domain.AuctionInfo }
            <dd>
                <dl>
                    <dt>MaxBid</dt>
                    <dd>{domain.AuctionInfo.MaxBidAmount}</dd>
                    <dt>MaxBid address</dt>
                    <dd><pre><a target="_blank" href="https://tonscan.org/address/{domain.AuctionInfo.MaxBidAddress}">{domain.AuctionInfo.MaxBidAddress}</a></pre></dd>
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
                {#if domain.Entries?.Wallet }
                    <dd><pre>{domain.Entries.Wallet}</pre></dd>
                {:else}
                    <dd>none</dd>
                {/if}

                <dt>site (ADNL)</dt>
                {#if domain.Entries?.SiteToAdnl }
                    <dd><pre>{domain.Entries?.SiteToAdnl}</pre></dd>
                {:else}
                    <dd>none</dd>
                {/if}

                <dt>site (Storage)</dt>
                {#if domain.Entries?.SiteToStorage }
                    <dd><pre>{domain.Entries?.SiteToStorage}</pre></dd>
                {:else}
                    <dd>none</dd>
                {/if}

                <dt>storage</dt>
                {#if domain.Entries?.Storage }
                    <dd><pre>{domain.Entries?.Storage}</pre></dd>
                {:else}
                    <dd>none</dd>
                {/if}

                <dt>dnsNextResolver</dt>
                {#if domain.Entries?.DnsNextResolver }
                    <dd><pre>{domain.Entries?.DnsNextResolver}</pre></dd>
                {:else}
                    <dd>none</dd>
                {/if}
            </dl>
        </dd>
    </dl>

    <hr />
</div>
{/if}
