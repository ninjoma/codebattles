<script lang="ts">
import SectionTitle from './SectionTitle.vue';
export default {
    components: {
        SectionTitle
    }
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
                    <font-awesome-icon icon="fa-solid fa-brain" class="text-5xl text-[#36D399] p-10 py-5" />
                    <h4 class="text-center font-inter font-bold">Biggest Brain</h4>
                    <small class="text-center">[username] has played more than 1000 matches!</small>
                </div>
                <div class="p-3 bg-base-300 rounded-xl flex flex-col w-36 items-center justify-center">
                    <font-awesome-icon icon="fa-solid fa-brain" class="text-5xl text-[#36D399] p-10 py-5" />
                    <h4 class="text-center font-inter font-bold">Biggest Brain</h4>
                    <small class="text-center">[username] has played more than 1000 matches!</small>
                </div>
            </div>
        </div>
    </div>
</template>