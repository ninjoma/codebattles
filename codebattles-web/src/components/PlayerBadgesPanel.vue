<script lang="ts">
export default {
    
}
</script>
<template>
    <div class="bg-base-100 m-5 rounded-xl p-2">
        <div>
            <h3 className="px-6 pt-3 text-xl underline underline-offset-4 font-inter decoration-4 decoration-[#36D399]">Badges</h3>
        </div>
        <div class="flex">
            <div class="px-6 py-2 flex gap-2">
                <div class="p-3 bg-base-300 rounded-xl flex flex-col w-36 items-center justify-center">
                    <font-awesome-icon icon="fa-solid fa-brain" class="text-5xl text-[lightblue] p-10 py-5" />
                    <h4 class="text-center font-inter font-bold">Biggest Brain</h4>
                    <small class="text-center">[username] has played more than 1000 matches!</small>
                </div>
                <div class="p-3 bg-base-300 rounded-xl flex flex-col w-36 items-center justify-center">
                    <font-awesome-icon icon="fa-solid fa-brain" class="text-5xl text-[lightblue] p-10 py-5" />
                    <h4 class="text-center font-inter font-bold">Biggest Brain</h4>
                    <small class="text-center">[username] has played more than 1000 matches!</small>
                </div>
            </div>
        </div>
    </div>
</template>