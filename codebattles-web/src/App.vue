<script lang="ts">
import Header from "./components/Header.vue";
export default {
    components: {
        Header
    }
}
</script>

<template>
    <div class="min-h-screen flex flex-col">
        <Header></Header>
        <RouterView></RouterView>
    </div>
</template>

