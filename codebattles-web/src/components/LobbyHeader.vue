<script lang="ts">
export default {}
</script>
<template>
    <div class="w-full font-inter">
        <div className="collapse collapse-arrow bg-success">
            <input type="checkbox" className="peer" />
            <div className="collapse-title text-primary-content">
                <h3 class="font-inter text-xl font-bold text-black">Exercise: {{ }}</h3>
            </div>
            <div className="collapse-content text-primary-content">
                <p className="rounded-xl bg-base-300 p-2">

                </p>
            </div>
        </div>
    </div>
    <div className="navbar flex justify-between px-4 bg-base-200 h-5">
        <a className="font-inter font-bold flex-1">Battle Num: #{{ $store.state.Game.currentGame.id }}</a>
        <div className="relative rounded-lg bg-base-200 p-2 top-6 border-0">
            <div className="">
                <button className="btn btn-lg btn-success flex-1 flex flex-col">
                    <a className="">Submit</a>
                    <small>(Ctrl + S)</small>
                </button>
            </div>
        </div>
        <a className="font-mono font-bold flex-1 justify-end flex gap-1 text-success">
            <font-awesome-icon icon="fa-solid fa-stopwatch" />
            <span className="countdown">
                <span style="{{'--value':52}}"></span>
            </span>
        </a>
    </div>

</template>