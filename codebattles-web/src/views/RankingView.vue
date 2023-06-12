<script lang="ts">
import RankingComponent from '../components/RankingComponent.vue';

export default {
    components: {
        RankingComponent
    }
}
</script>

<template>
    <div class="flex-col flex-1 flex">
        <div class="flex w-full items-center justify-center">
            <div class="max-w-xl w-full">
                <RankingComponent></RankingComponent>
            </div>
        </div>
    </div>
</template>

