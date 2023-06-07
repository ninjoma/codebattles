<script lang="ts">
import EntityListContainer from './EntityListContainer.vue'
import axios from "axios"

export default {
    components: {
        EntityListContainer,
    },
    mounted() {
        this.fetchData();
    },
    data() {
        return {
            gamemodeList: [],
            searchName: '',
        }
    },
    methods: {
        EnterKeyHandler(event) {
            if (event.key == 'Enter') {
                this.fetchData();
            }
        },
        fetchData() {
            axios.get('/api/GameMode' + (this.searchName != '' && this.searchName != null ? '?name=' + this.searchName : ''))
			.then((response) => {
				this.gamemodeList = response.data;
            }).catch((error) => {
                this.gamemodeList = [];
            })
        }
    }
}
</script>
<template>
    <div class="form-control w-full my-3">
        <div class="input-group w-full">
            <input type="text" placeholder="Badge name" v-model="searchName" class="input input-bordered w-full" :onkeyup="EnterKeyHandler"/>
            <button class="btn btn-square" v-on:click="fetchData()">
                <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24"
                    stroke="currentColor">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                        d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z" />
                </svg>
            </button>
        </div>
    </div>
    <EntityListContainer :displayed-list="gamemodeList"></EntityListContainer>
</template>