<script lang="ts">
import { mapState } from 'vuex';
import { GameStatus } from '../Enum/index';

export default {
    mounted() {

    },
    data() {
        return {
            GameStatus
        }
    },
    methods: {
        joinBattle(gameId){
            this.$store.dispatch("Game/addParticipant", gameId).then(() => {
                this.enterLobby(gameId)
            });
        },
        enterLobby(gameId) {
            this.$router.push("lobby/" + gameId);
        }
    },
}
</script>
<template>
<div v-for="game in $store.state.Game.games" className="w-full">
    <div class="bg-base-300 rounded-xl p-6 shadow font-inter">
        <div className="flex justify-between items-baseline">
            <div>
                <h5 class="text-[#36D399] font-bold text-lg">{{ game.participants[0] != null ? game.participants[0].user.username : null }}'s lobby</h5>
                <div class="flex flex-col">
                    <span>Settings:</span>
                    <span>{{ game.gameMode.description }}, language: {{ game.language.name }}</span>
                </div>
            </div>
            <div class="flex flex-col items-end">
                <span>Players: {{ game.participants.length }}/2</span>
                <span class="text-end">{{ game.participants.map((participant) => { return participant.user.username }).join(',') }}</span>
                <button class="mt-2">
                    <button v-if="game.gameStatus != GameStatus.Ended" v-on:click="game.userInBattle == false ? joinBattle(game.id) : enterLobby(game.id)" className="btn btn-success btn-sm">
                        <span v-if="game.userInBattle == true">
                            You are still in battle! Rejoin
                        </span>
                        <span v-else-if="game.participants.length < 2 && game.gameStatus != GameStatus.Started">
                            Join Game
                        </span>
                    </button>
                    <button v-else className="btn btn-success btn-disabled btn-sm">
                        <span>
                            This game already Ended
                        </span>
                    </button>
                </button>
            </div>
        </div>
    </div>
</div>
</template>