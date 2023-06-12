<script lang="ts">
import { mapState } from 'vuex';
import SectionTitle from './SectionTitle.vue';
export default {
    props: ['username'],
    components: {
        SectionTitle
    },
    computed: mapState({
        profile: state => state.Profile
    })
}
</script>
<template>
    <div class="bg-base-100 m-5 rounded-xl p-2">
        <div class="px-5">
            <SectionTitle>Badges</SectionTitle>
        </div>
        <div class="flex">
            <div class="px-6 py-2 flex gap-2">
                <div class="p-3 bg-base-300 rounded-xl flex flex-col w-36 items-center justify-center">
                    <font-awesome-icon icon="fa-solid fa-cake-candles" class="text-5xl text-[#36D399] p-10 py-5" />
                    <h4 class="text-center font-inter font-bold">New player</h4>
                    <small class="text-center"> {{ profile.username }} Joined in 2023.</small>
                </div>
            </div>
        </div>
    </div>
</template>