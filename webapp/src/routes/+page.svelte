<script lang="ts">
    import SearchForm from "$lib/SearchForm.svelte";
    import DomainDetails from "$lib/DomainDetails.svelte";
    import History from "$lib/History.svelte";

    import { onMount } from "svelte";
    import { DomainInfo } from "$lib/DomainInfo";

    let domain: string = "";
    let domainInfo: DomainInfo | null;
    let history: string[] | null;

    onMount(() => {
        // emulate delay
        setTimeout(() => {
            domainInfo = new DomainInfo();
            history = ["foundation.ton" ];
        }, 1000);
    });
</script>

<h1>TON Domain Inspector</h1>
<p>
    Get information about <code>*.ton</code> domains: current status/owner, auction
    status, renewal time and DNS records.
</p>

<SearchForm domain={domain} />

<DomainDetails domain={domainInfo} />

<History domains={history} />

<p class="mt-5 small muted">Debug info: Telegram Bot API v?.?.</p>
