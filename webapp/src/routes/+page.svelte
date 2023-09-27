<script lang="ts">
    import SearchForm from "$lib/SearchForm.svelte";
    import DomainDetails from "$lib/DomainDetails.svelte";
    import History from "$lib/History.svelte";

    import type { DomainInfo } from "$lib/DomainInfo";

    import { PUBLIC_SERVER } from '$env/static/public';

    let domain: string = "";
    let domainInfo: DomainInfo | null;
    let searchForm: SearchForm;
    let history: History;

    function doSearch(event: CustomEvent<string>) {
        let dm = event.detail;
        domainInfo = null;
        history.add(dm);
        fetch(PUBLIC_SERVER + "?domain=" + dm)
            .then(r => r.json())
            .then(r => { domainInfo = r as DomainInfo; domainInfo.FullName = dm; })
            .finally(() => { searchForm.loadingCompleted(); });
    }

    function restoreFromHistory(event: CustomEvent<string>) {
        searchForm.setDomain(event.detail);
        domainInfo = null;
    }
</script>

<h1>TON Domain Inspector</h1>
<p>
    Get information about <code>*.ton</code> domains: current status/owner, auction
    status, renewal time and DNS records.
</p>

<SearchForm bind:this={searchForm} bind:domain={domain} on:search={doSearch} />

<DomainDetails bind:domain={domainInfo} />

<History bind:this={history} on:restore={restoreFromHistory} />

<p class="mt-5 small muted">Debug info: Telegram Bot API v{Telegram.WebApp.version}</p>
