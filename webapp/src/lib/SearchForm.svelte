<script lang="ts">
    import { createEventDispatcher } from "svelte";

    export let domain: string;

    const dispatch = createEventDispatcher();

    function onSearchPressed() : any {
        dispatch("search", fullDomain);
    }

    export function setDomain(val: string) {
        domain = val;
        tryNormalize();
    }

    let ok: boolean = false;
    let fullDomain: string = "";
    let errorText: string = "";

    function tryNormalize () {
        if (domain == "") return setError("");
        if (domain.length < 3) return setError("Domain must have at least 3 characters");
        let parts = domain.toLowerCase().split(".");
        if (parts.length == 1) {
            if (domain.length > 126) return setError("Domain can't have more than 126 characters");
            return clearError(parts[0] + ".ton");
        } else if (parts.length == 2) {
            if (parts[1] != "ton") return setError("Only *.ton domains are supported.");
            if (parts[0].length < 3) return setError("Domain must have at least 3 characters");
            if (parts[0].length > 126) return setError("Domain can't have more than 126 characters");
            return clearError(parts[0] + ".ton");
        } else {
            return setError("Only top-level domains (e.g. anything.ton) are supported.");
        }
    }

    function setError(error: string)
    {
        ok = false;
        fullDomain = "";
        errorText = error;
    }

    function clearError(domain: string) {
        ok = true;
        fullDomain = domain;
        errorText = "";
    }

</script>

<form>
    <div class="row">
        <label for="domain">Domain name</label>
        <input
            class="u-full-width"
            type="text"
            name="domain"
            placeholder="e.g. foundation.ton, www.ton"
            required
            autocomplete="off"
            bind:value={domain}
            on:input={tryNormalize}
            on:change={tryNormalize}
        />
        <span class="errorText">{errorText}</span>
    </div>
    <button class="u-full-width button-primary" disabled={!ok} on:click={onSearchPressed}>Get info</button>
</form>
