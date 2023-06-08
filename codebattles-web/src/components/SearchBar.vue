<script lang="ts">
import axios from "axios";
import HeaderButton from "./HeaderButton.vue";
export default {
    components: {
        HeaderButton
    },
    data() {
        return {
            showSearchBar: false,
        }
    },
    methods: {
        search() {
            var searchInput = (this.$refs.searchInput as any)
            if (searchInput.value.length > 1) {
                this.$store.dispatch('Search/search', { value: searchInput.value });
                this.showSearchBar = true
            } else {
                this.showSearchBar = false;
            }
        },
        clearSearch() {
            var searchInput = (this.$refs.searchInput as any)
            this.showSearchBar = false;
            searchInput.value = "";
        }
    },
}
</script>
<template>
    <div class="px-5 hidden sm:flex max-w-96">
        <div className="relative">
            <input ref="searchInput" v-on:input="search" type="text" placeholder="Search..."
                className="input input-sm input-ghost flex-grow" />
            <div v-if="showSearchBar" className="card w-full bg-base-100 shadow-xl absolute top-10">
                <div className="p-2 shadow-lg rounded-sm">
                    <b>Users</b>
                    <div className="w-100 bg-base-300 rounded p-1">
                        <div className="grid grid-cols-2 p-1 gap-3">
                            <RouterLink v-for="user in $store.state.Search.users" :to="'/users/' + user.id + '/profile'">
                                <div v-on:click="clearSearch" className="flex items-center gap-2">
                                    <div className="avatar">
                                        <div className="w-12 rounded bg-base-100">
                                            <img style=' display:block;' id='base64image' :src="user.avatarBase64"
                                                v-if="user.avatarBase64 != '' && user.avatarBase64 != null"
                                                class="w-full h-full" />
                                        </div>
                                    </div>
                                    <span>{{ user.username }}</span>
                                </div>
                            </RouterLink>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</template>