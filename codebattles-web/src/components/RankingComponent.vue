<script lang="ts">
import axios from "axios";
import GraphComponent from "../components/GraphComponent.vue";
export default { 
    components: { 
        GraphComponent
    },
    data() {
        return {
            ranking: {}
        }
    },
    mounted() {
        axios.get("/Rankings")
            .then((response) => {
                this.ranking = response.data
            })
    }
}
</script>
<template>
    <div class="lg:rounded-xl p-4 lg:p-10 font-inter w-full">
        <GraphComponent></GraphComponent>
        <div class="rounded-xl px-6 flex items-center justify-center w-full">
            <span class="text-success pr-3">Place</span>
            <div class="flex w-full justify-between">
                <span>username</span>
                <span>Total battles won</span>
            </div>
        </div>
        <div v-for="user, index in ranking" class="rounded-xl bg-base-300 p-4 px-6 flex my-1 items-center justify-center w-full">
            <h3 class="text-2xl text-success pr-3">#{{ index + 1 }}</h3>
            <div class="flex w-full justify-between">
                
                <span>{{ 
                    // @ts-ignore
                    user.username 
                    }}</span>
                <span>{{ 
                // @ts-ignore
                user.battlesWon 
                }}</span>
            </div>
        </div>
    </div>
</template>