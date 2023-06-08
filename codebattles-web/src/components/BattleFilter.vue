<script lang="ts">
import SectionTitle from './SectionTitle.vue';
export default {
    components: {
        SectionTitle
    },
    mounted() {
    },
    data() {
        return {
            Language: null,
            Gamemode: null,
            GameStatus: 1 ,
        }
    },
    methods: {
        FilterList() {
            this.$store.dispatch("Game/retrieveFilterGames", {Language: this.Language, Gamemode: this.Gamemode, GameStatus: this.GameStatus});
        }
    }
}
</script>
<template>
    <div class="flex flex-col bg-base-300 rounded-xl flex flex-col px-1">
        <div class="">
            <h3 class="text-lg font-inter decoration-4 decoration-[#36D399]">Filter Battles
            </h3>
            <div class="">
                <div class="flex gap-3 py-3">
                    <select className="select select-sm grow" v-model="Language">
                        <option selected :value="null">Language</option>
                        <option v-for="language in $store.state.Language.languages" :value="language.id">{{ language.name }}
                        </option>
                    </select>
                    <select className="select select-sm grow" v-model="Gamemode">
                        <option selected :value="null">GameMode</option>
                        <option v-for="gamemode in $store.state.Gamemode.gamemodes" :value="gamemode.id">{{ gamemode.name }}
                        </option>
                    </select>
                    <select className="select select-sm grow" v-model="GameStatus">
                        <option selected :value="null">GameMode</option>
                        <option value="1">Waiting</option>
                        <option value="2">Started</option>
                        <option value="3">Ended</option>
                    </select>
                    <button class="btn btn-sm btn-success grow" v-on:click="FilterList">
                        Filter
                    </button>
                </div>
            </div>
        </div>
</div></template>