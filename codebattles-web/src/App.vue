<script lang="ts">
import Header from "./components/Header.vue";
import Drawer from "./components/Drawer.vue";
export default {
    components: {
        Header,
        Drawer
    }
}
</script>

<template>
    <div class="min-h-screen flex flex-col">
        <Drawer>
            <RouterView></RouterView>
        </Drawer>
    </div>
</template>

