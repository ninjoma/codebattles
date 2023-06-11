<script lang="ts">
import axios from "axios";
export default { 
    components: { },
    data() {
        
    }
    mounted() {
        axios.get("/ranking", function(){
            
        })
    }
}
</script>
<template>
    <div class="lg:rounded-xl p-4 lg:p-10 font-inter w-full">
        <div class="rounded-xl px-6 flex items-center justify-center w-full">
            <span class="text-success pr-3">Place</span>
            <div class="flex w-full justify-between">
                <span>username</span>
                <span>Total battles won</span>
            </div>
        </div>
        <div v-for="user, index in ranking" class="rounded-xl bg-base-300 p-4 px-6 flex items-center justify-center w-full">
            <h3 class="text-2xl text-success pr-3">#{{ index }}</h3>
            <div class="flex w-full justify-between">
                <span>{{ user.username }}</span>
                <span>{{ user.battleswon }}</span>
            </div>
        </div>
    </div>
</template>