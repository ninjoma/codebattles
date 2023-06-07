<script lang="ts">
import EntityListContainer from '../components/EntityListContainer.vue'
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
            languageList: [],
        }
    },
    methods: {
        EnterKeyHandler(event) {
            if (event.key == 'Enter') {
                this.fetchData();
            }
        },
        fetchData() {
            axios.get('/api/Language')
			.then((response) => {
				this.languageList = response.data;
            }).catch((error) => {
                this.languageList = [];
            })
        }
    }
}
</script>
<template>
    <button class="btn btn-success w-full my-3" v-on:click="fetchData()"> Refresh </button>
    <EntityListContainer :displayed-list="languageList"></EntityListContainer>
</template>