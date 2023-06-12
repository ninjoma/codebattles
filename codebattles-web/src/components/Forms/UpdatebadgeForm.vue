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
            badgeId: 0,
        }
    },
    methods: {
        Create() {
            axios.put('/badge/' + this.badgeId, {
                id: this.badgeId,
                name: this.badgeName,
                description: this.description
            })
                .then((response) => {
                    this.$store.commit('Alert/show', { type: 'success', message: 'Badge Succesfully created' })
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
        <input type="number" placeholder="Badge Name" v-model="badgeId" class="input input-bordered w-full" />
    </div>
    <div class="form-control w-full my-3">
        <input type="text" placeholder="Badge Name" v-model="badgeName" class="input input-bordered w-full" />
    </div>
    <div class="form-control w-full my-3">
        <input type="text" placeholder="Badge Description" v-model="description" class="input input-bordered w-full" />
    </div>
    <button class="w-full btn btn-success" v-on:click="Create()">
        Update Badge
    </button>
</template>