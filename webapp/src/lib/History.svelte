<script lang="ts">
    export let domains: string[] | null = [];
</script>

{#if domains && domains.length > 0}
    <h3>Last searches</h3>
    {#each domains as domain}
        <button class="button">{domain}</button>
    {/each}
{/if}

<style>
    button {
        padding-left: 1.5rem;
        padding-right: 1.5rem;
        margin-right: 1rem;
    }
</style>
