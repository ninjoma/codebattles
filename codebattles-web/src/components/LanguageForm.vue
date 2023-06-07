<script lang="ts">
import axios from "axios";

export default {
    components: {
    },
    mounted() {
    },
    data() {
        return {
            badgeName: null,
            description: null,
        }
    },
    methods: {
        Create() {
            axios.post('api/Language/', {
                id: 0,
                name: this.badgeName,
                judge0Id: this.description
            })
                .then((response) => {
                    this.$store.commit('Alert/show', { type: 'success', message: 'Entity Succesfully created' })
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
        <input type="text" placeholder="Language Name" v-model="badgeName" class="input input-bordered w-full" />
    </div>
    <div class="form-control w-full my-3">
        <input type="number" placeholder="Judge0 Id" v-model="description" class="input input-bordered w-full" />
    </div>
    <button class="w-full btn btn-success" v-on:click="Create()">
        Create Badge
    </button>
</template>