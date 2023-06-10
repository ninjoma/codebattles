<script lang="ts">
import LoginComponent from '../components/LoginComponent.vue';

export default {
    components: {
        LoginComponent
    }
}
</script>

<template>
    <div class="flex flex-col flex-1 flex justify-center">
        <div class="flex w-full h-full items-center justify-center">
            <div class="max-w-md w-full">
                <LoginComponent></LoginComponent>
            </div>
        </div>
    </div>
</template>

