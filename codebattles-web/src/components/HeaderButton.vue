<script lang="ts">
export default {
    props: ['targetUrl']
}
</script>

<template>
    <div class="header-button border-b-2 items-center flex font-bold">
        <RouterLink :to="targetUrl" class="">
            <slot/>
        </RouterLink>
    </div>
</template>
<style scoped>
.header-button {
    border-color: #A6ADBB;
    width:100%;
    white-space: nowrap;
    padding-left:15px;
    padding-right:15px;
    transition-property: all; 
    transition-duration: 0.15s;
}

.header-button:hover {
    border-color: #36D399;
    background-color: #1d765651;
    font-style: italic;
    font-size: 1.5em;
    font-weight: 700;
}


</style>