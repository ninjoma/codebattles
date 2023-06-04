<script lang="ts">
import Header from "./components/Header.vue";
import Drawer from "./components/Drawer.vue";
import ToastHandler from "./components/ToastHandler.vue";

export default {
    components: {
        Header,
        Drawer,
        ToastHandler
    },
    mounted() {
      this.$store.dispatch("User/load");
    }
}
</script>

<template>
    <div class="min-h-screen flex flex-col">
        <Drawer>  
          <RouterView></RouterView>
          <ToastHandler></ToastHandler>
        </Drawer>
    </div>
</template>
<style>
::-webkit-scrollbar {
  width: 10px;
}

/* Track */
::-webkit-scrollbar-track {
  background: #20252e;
}
 
/* Handle */
::-webkit-scrollbar-thumb {
  background: #36d399; 
}

</style>
