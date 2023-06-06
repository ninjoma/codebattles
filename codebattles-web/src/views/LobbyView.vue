<script lang="ts">
import LobbyHeader from "../components/LobbyHeader.vue";
import CodeEditor from "../components/CodeEditor.vue";
import PlayerCard from "../components/PlayerCard.vue";
import ScoreCard from "../components/ScoreCard.vue";
import { startSignalRConnection } from "../signalr/signalr";
import BattleArenaComponent from "../components/BattleArenaComponent.vue";
export default {
    components: {
    LobbyHeader,
    CodeEditor,
    PlayerCard,
    ScoreCard,
    BattleArenaComponent
    },
    mounted() {
        this.$store.dispatch("Game/getGame", this.$route.params.battleId);
    }
}
</script>

<template>
    <div class="flex flex-col flex-1">
        <div class="w-full font-inter">
            <div className="collapse collapse-arrow bg-success">
                <input type="checkbox" className="peer" />
                <div className="collapse-title text-primary-content">
                    <h3 class="font-inter text-xl font-bold text-black">Exercise: {{  }}</h3>
                </div>
                <div className="collapse-content text-primary-content">
                    <p className="rounded-xl bg-base-300 p-2">
                       </p>
                </div>
            </div>
        </div>
        <BattleArenaComponent></BattleArenaComponent>
    </div>
</template>

