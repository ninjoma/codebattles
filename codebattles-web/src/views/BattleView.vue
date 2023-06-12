<script lang="ts">
import SectionTitle from '../components/SectionTitle.vue';
import BattleContainer from '../components/BattleContainer.vue';
import BattleCreationComponent from '../components/BattleCreationComponent.vue';
import BattleFilter from '../components/BattleFilter.vue'
export default {
    components: { 
        SectionTitle, 
        BattleContainer,  
        BattleCreationComponent,
        BattleFilter
    },
    mounted() {
        this.$store.dispatch("Game/retrieveGames");
        this.$store.dispatch("Language/retrieveLanguages");
        this.$store.dispatch("Gamemode/retrieveGamemodes");
    }
    
}
</script>
<template>
<div class="flex flex-col flex-1 items-center">
    <div class="max-w-screen-lg w-full p-2">
        <div class="bg-base-300 rounded-xl px-6 py-3 shadow my-5 flex flex-col">
            <div class="flex gap-2 flex-1 w-full">
                <SectionTitle>Battles</SectionTitle>
            </div>
            <BattleCreationComponent/>
            <BattleFilter/>
        </div>
        <div class="flex flex-col gap-3">
            <BattleContainer/>
        </div>
    </div>
</div>
</template>