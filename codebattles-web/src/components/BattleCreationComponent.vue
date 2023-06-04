<script lang="ts">
import SectionTitle from './SectionTitle.vue';
import Devicon from './Devicon.vue';
export default {
    components: {
        SectionTitle,
        Devicon
    }
}
</script>

<template>
    <div class="flex flex-col">
        <div class="flex gap-2 flex-1 w-full justify-between items-baseline">
            <SectionTitle>Battles</SectionTitle>
            <div className="form-control">
                <div className="input-group input-group-md">
                    <input type="text" placeholder="Input Lobby Code..." className="input input-sm input-bordered" />
                    <button className="btn btn-sm btn-success">
                    Join
                    </button>
                </div>
            </div>
        </div>
        <div class="flex justify-between gap-3 flex-wrap lg:flex-nowrap">
            <div class="flex items-start flex-col w-full">
                <h6 class="">Language of choice</h6>
                <div class="grid grid-cols-3 lg:grid-cols-6 py-2 gap-3 w-full">
                    <div class="flex flex-col items-center rounded drop-shadow-lg bg-base-100 gap-1 p-3">
                        <Devicon icon="devicon-nodejs-plain"></Devicon>
                        Javascript
                    </div>
                    <div class="flex flex-col items-center rounded drop-shadow-lg bg-base-100 gap-1 p-3">
                        <Devicon icon="devicon-csharp-plain"></Devicon>
                        C Sharp
                    </div>
                    <div class="flex flex-col items-center rounded drop-shadow-lg bg-base-100 gap-1 p-3">
                        <Devicon icon="devicon-python-plain"></Devicon>
                        Python
                    </div>
                    <div class="flex flex-col items-center rounded drop-shadow-lg bg-base-100 gap-1 p-3">
                        <Devicon icon="devicon-rust-plain"></Devicon>
                        Rust
                    </div>
                    <div class="flex flex-col items-center rounded drop-shadow-lg bg-base-100 gap-1 p-3">
                        <Devicon icon="devicon-cplusplus-plain"></Devicon>
                        C++
                    </div>
                    <div class="flex flex-col items-center rounded drop-shadow-lg bg-base-100 gap-1 p-3">
                        <Devicon icon="devicon-css3-plain"></Devicon>
                        CSS
                    </div>
                </div>
            </div>
            <div class="lg:max-w-xs w-full">
                <h6 class="">General Settings</h6>
                <div class="flex flex-col gap-2 py-2">
                    <select className="select select-sm w-full">
                        <option disabled selected>Time limit</option>
                        <option>3 min</option>
                        <option>5 min</option>
                        <option>10 min</option>
                        <option>15 min</option>
                        <option>20 min</option>
                    </select>
                    <select className="select select-sm w-full">
                        <option disabled selected>Gamemode</option>
                        <option>Classic</option>
                        <option>Hidden responses</option>
                        <option>Battle Royale</option>
                    </select>
                </div>
                <label class="flex gap-1 btn btn-success btn-sm" htmlFor="create-modal">
                    <font-awesome-icon icon="fa-solid fa-plus" />
                    Create
                </label>
            </div>
        </div>
    </div>
    
</template>