<script lang="ts">
import axios from "axios";

export default {
    components: {
    },
    mounted() {
    },
    data() {
        return {
            name: null,
            description: null,
        }
    },
    methods: {
        Create() {
            axios.post('GameMode/', {
                id: 0,
                name: this.name,
                description: this.description,
                time: 120
            })
                .then((response) => {
                    this.$store.commit('Alert/show', { type: 'success', message: 'GameMode Succesfully created' })
                }).catch((error) => {
                    console.log(error)
                    this.$store.commit('Alert/show', { type: 'error', message: error.response.data.errorTranslation })
                })
        }
    }

}
</script>
<template>
    <div class="form-control w-full my-3">
        <input type="text" placeholder="GameMode Name" v-model="name" class="input input-bordered w-full" />
    </div>
    <div class="form-control w-full my-3">
        <input type="text" placeholder="GameMode Description" v-model="description" class="input input-bordered w-full" />
    </div>
    <button class="w-full btn btn-success" v-on:click="Create()">
        Create GameMode
    </button>
</template>