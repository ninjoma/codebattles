<script lang="ts">
import HeaderButton from "./HeaderButton.vue";
import SearchBar from "./SearchBar.vue";
export default {
    components: {
        HeaderButton,
        SearchBar
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
    },
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
                <HeaderButton targetUrl="/battle">
                    <a>Battles</a>
                </HeaderButton>
                <HeaderButton targetUrl="/admin">
                    <a>Admin</a>
                </HeaderButton>
            </div>
        </div>
        <div v-if="$store.state.User.isLogged">
            <SearchBar></SearchBar>
            <div class="h-full flex gap-3 hidden sm:flex">
                <HeaderButton :targetUrl=" '/users/' + $store.state.User.id + '/profile'">
                    <font-awesome-icon icon="fa-solid fa-user" />
                </HeaderButton>
                <HeaderButton targetUrl="/logout" v-if="$store.state.User.isLogged">
                    <font-awesome-icon icon="fa-solid fa-right-from-bracket" />
                </HeaderButton>
            </div>
        </div>
    </div>
</template>

