<script lang="ts">
import RegisterComponent from '../components/RegisterComponent.vue';

export default {
    components: {
        RegisterComponent
    }
}
</script>

<template>
    <div class="flex flex-col flex-1 flex">
        <div class="flex w-full h-full items-center justify-center">
            <div class="max-w-md w-full">
                <RegisterComponent></RegisterComponent>
            </div>
        </div>
    </div>
</template>

