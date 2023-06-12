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
    },
    watch: {
        '$store.state.Game.currentGame': {
            handler(currentGame) {
                if(currentGame.userInBattle == null){
                    this.$store.commit("Alert/show", {type: "error", message: "This game has concluded or you're not in it"});
                    this.$router.push('/battle');
                }
            }
        }
    }
}
</script>

<template>
    <div class="flex flex-col flex-1">
        <BattleArenaComponent></BattleArenaComponent>
    </div>
</template>

