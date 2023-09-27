<script lang="ts">
    import { onMount } from "svelte";
    import { createEventDispatcher } from "svelte";

    let domains: string[] = [];

    const dispatch = createEventDispatcher();

    function onItemPressed(domain: string) : any {
        dispatch("restore", domain);
    }

    export function add(domain: string)
    {
        let existing = domains.indexOf(domain);
        if (existing >= 0) {
            domains.splice(existing, 1);
        }
        domains.unshift(domain);
        domains.splice(5);
        domains = domains; // to update bindings
        Telegram.WebApp.CloudStorage.setItem("domains", domains.join("\n"));
    }

    onMount(() => {
        Telegram.WebApp.CloudStorage.getItem("domains", (e, v) => 
        {
            if (e == null) {
                domains = v.split("\n");
            }
        });
    });
</script>

{#if domains && domains.length > 0}
    <h3>Last searches</h3>
    {#each domains as domain}
        <button class="button" on:click={onItemPressed(domain)}>{domain}</button>
    {/each}
{/if}

<style>
    button {
        padding-left: 1.5rem;
        padding-right: 1.5rem;
        margin-right: 1rem;
    }
</style>
