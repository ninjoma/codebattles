<script lang="ts">
import HeaderButton from "./HeaderButton.vue";
import SearchBar from "./SearchBar.vue";
export default {
    components: {
        HeaderButton,
        SearchBar
    },
    methods: {
    },
}
</script>
<template>
    <div className="navbar bg-base-300 flex items-center justify-between gap-3 p-0 px-2 items-stretch drop-shadow-lg fixed z-50">
        <div class="">
            <a className="normal-case text-xl font-inter font-bold px-2 flex gap-3">
                >/&lt; 
                <span className="">CODE BATTLES</span>
            </a>
            <div class="h-full flex gap-3 hidden sm:flex">
                <HeaderButton targetUrl="/battle" v-if="$store.state.User.isLogged">
                    <a>Battles</a>
                </HeaderButton>
                <HeaderButton v-if="$store.state.User.isAdmin" targetUrl="/admin">
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

