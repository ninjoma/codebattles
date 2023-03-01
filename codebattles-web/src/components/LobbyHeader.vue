<script lang="ts">
export default {}
</script>
<template>
    <div className="navbar flex justify-between px-4 bg-base-200 h-5">
        <a className="font-inter font-bold flex-1">Battle Num: #12312</a>
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