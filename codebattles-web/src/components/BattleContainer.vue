<script lang="ts">
export default {}
</script>

<template>
<div className="w-full">
    <div class="bg-base-300 rounded-xl p-6 shadow font-inter">
        <div className="flex justify-between items-baseline">
            <div>
                <h5 class="text-[#36D399] font-bold text-lg">{username}'s lobby</h5>
                <div class="flex flex-col">
                    <span>Settings:</span>
                    <span>C# and JS only, 5 min/question </span>
                </div>
            </div>
            <div class="flex flex-col items-end">
                <span>Players: 1/2</span>
                <span class="text-end">{username}, {username}</span>
                <button class="mt-2">
                    <button className="btn btn-success btn-sm">TO BATTLE!</button>
                </button>
            </div>
        </div>
        <div class="flex justify-between">
            
        </div>

    </div>
</div>
</template>