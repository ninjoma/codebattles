<script lang="ts">
import PlayerStatsPanel from '../components/PlayerStatsPanel.vue';
import PlayerBadgesPanel from "../components/PlayerBadgesPanel.vue";
import PlayerInfoPanel from '../components/PlayerInfoPanel.vue';


export default {
    components: {
        PlayerStatsPanel,
        PlayerBadgesPanel,
        PlayerInfoPanel
    },
    mounted() {
        this.$store.dispatch("Profile/loadProfile", {id: this.$route.params.id});
    },
    watch: {
        "$route.params.id": {
            handler() {
                this.$store.dispatch("Profile/loadProfile", {id: this.$route.params.id});
            }
        }
    }
}
</script>

<template>
    <div class="flex flex-col flex-1 items-center bg-base-300">
        <div class="max-w-screen-lg w-full">
            <PlayerInfoPanel/>
            <PlayerStatsPanel/>
            <PlayerBadgesPanel/>
        </div>
    </div>
</template>

