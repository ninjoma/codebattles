<script lang="ts">
export default {
    methods: {
        isActive(url) {
            if(url == this.$route.name) {
                return 'text-3xl text-success active';
            } else {
                return 'text-2xl';
            }
        }
    }
}
</script>
<template>
    <div v-if="$store.state.User.isLogged" className="sm:hidden btm-nav bg-base-300">
        <RouterLink tag="button" :className="isActive('battles')" to="/battle">
            <font-awesome-icon icon="fa-solid fa-skull-crossbones" />
        </RouterLink>
        <RouterLink tag="button" :class="isActive('profile')" :to="'/users/' + $store.state.User.id + '/profile'">
            <font-awesome-icon icon="fa-solid fa-user" />
        </RouterLink>
        <RouterLink tag="button" :class="isActive('logout')" to="/logout">
            <font-awesome-icon icon="fa-solid fa-right-from-bracket" />
        </RouterLink>
    </div>
</template>