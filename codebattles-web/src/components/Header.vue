<script lang="ts">
import HeaderButton from "./HeaderButton.vue";
export default {
    components: {
        HeaderButton
    },
    data(){
        return {
            showSearchBar: false
        }
    },
    methods: {
        search() {
            var searchInput = (this.$refs.searchInput as any)
            searchInput.value.length > 1 ? this.showSearchBar = true : this.showSearchBar = false
        }
    }
}
</script>
<template>
    <div className="navbar bg-base-300 flex items-center justify-between gap-3 p-0 px-2 items-stretch drop-shadow-lg fixed z-50">
        <div class="">
            <input id="header-drawer" type="checkbox" className="drawer-toggle" />
            <div className="flex-none sm:hidden">
                <label htmlFor="header-drawer" className="btn btn-square btn-ghost">
                    <font-awesome-icon icon="fa-solid fa-bars" class="text-xl"/>
                </label>
            </div>
            <a className="normal-case text-xl font-inter font-bold px-2">>/&lt; CODE BATTLES</a>
            <div class="h-full flex gap-3 hidden sm:flex">
                <HeaderButton targetUrl="/lobby" v-if="$store.state.isLogged">
                    <a>Lobby</a>
                </HeaderButton>
                <HeaderButton targetUrl="/battle">
                    <a>Battles</a>
                </HeaderButton>
            </div>
        </div>
        <div v-if="$store.state.isLogged">
            <div class="px-3 hidden sm:flex">
                <input ref="searchInput" v-on:input="search" type="text" placeholder="Search..." className="input input-sm input-ghost w-full w-96"/>
                <div v-if="showSearchBar" className="card w-96 bg-base-100 shadow-xl absolute top-14">
                    <div className="card-body">

                    </div>
                </div>
            </div>
            <div class="h-full flex gap-3 hidden sm:flex">
                <HeaderButton targetUrl="/profile">
                    <font-awesome-icon icon="fa-solid fa-user" />
                </HeaderButton>
                <HeaderButton targetUrl="/logout">
                    <font-awesome-icon icon="fa-solid fa-right-from-bracket" />
                </HeaderButton>
            </div>
        </div>
    </div>
</template>

