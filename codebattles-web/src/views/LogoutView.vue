<script lang="ts">
import LoginComponent from '../components/LoginComponent.vue';
import router from '../router';

export default {
    mounted(){
        this.$store.commit("User/logout");
        router.push({ path: '/login' });
    }
}
</script>

<template>
    <div class="flex flex-col flex-1 flex">

    </div>
</template>

