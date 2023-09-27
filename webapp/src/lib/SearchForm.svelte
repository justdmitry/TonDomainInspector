<script lang="ts">
    export let domain: string;
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
        />
        <span class="errorText">Error text goes here.</span>
    </div>
    <button class="u-full-width button-primary">Get info</button>
</form>
