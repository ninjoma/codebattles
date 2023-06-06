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
    }
}
</script>
<template>
<div v-for="game in $store.state.Game.games" className="w-full">
    <div class="bg-base-300 rounded-xl p-6 shadow font-inter">
        <div className="flex justify-between items-baseline">
            <div>
                <h5 class="text-[#36D399] font-bold text-lg">user with id {{ game.participants[0].userId }}'s lobby</h5>
                <div class="flex flex-col">
                    <span>Settings:</span>
                    <span>{{ game.gameMode.description }}</span>
                </div>
            </div>
            <div class="flex flex-col items-end">
                <span>Players: {{ game.participants.length }}/2</span>
                <span class="text-end">{{ game.participants.map((participant) => { return 'ID: ' + participant.userId }).join(',') }}</span>
                <button class="mt-2">
                    <RouterLink v-if="game.gameStatus != GameStatus.Ended" :to="'/lobby/' + game.id">
                        <button className="btn btn-success btn-sm">
                            <span v-if="game.userInBattle == true">
                                You are still in battle! Rejoin
                            </span>
                            <span v-else-if="game.participants.length < 2 && game.gameStatus != GameStatus.Started">
                                Join Game
                            </span>
                        </button>
                    </RouterLink>
                    <button v-else className="btn btn-success btn-disabled btn-sm">
                        <span>
                            This game already Ended
                        </span>
                    </button>
                </button>
            </div>
        </div>
        <div class="flex justify-between">
            
        </div>
    </div>
</div>
</template>