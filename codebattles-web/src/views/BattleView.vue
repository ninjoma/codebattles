<script lang="ts">
import SectionTitle from '../components/SectionTitle.vue';
import BattleContainer from '../components/BattleContainer.vue';
import BattleCreationComponent from '../components/BattleCreationComponent.vue';
export default {
    components: { SectionTitle, BattleContainer, BattleCreationComponent }
}
</script>
<template>
<div class="flex flex-col flex-1 items-center">
    <div class="max-w-screen-lg w-full p-2">
        <div class="bg-base-300 rounded-xl px-6 py-3 shadow my-5 flex flex-col">
            <BattleCreationComponent/>
        </div>
        <div class="flex flex-col gap-3">
            <BattleContainer/>
            <BattleContainer/>
            <BattleContainer/>
            <BattleContainer/>
        </div>
    </div>
</div>
</template>