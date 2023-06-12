<script lang="ts">
import Header from './Header.vue';
import MobileNav from './MobileNav.vue' 
export default {
    components: {
        Header,
        MobileNav
    },
}
</script>
<template>
    <div className="drawer-content flex flex-col min-h-screen">
            <!-- Navbar -->
            <Header/>
            <!-- Page content here -->
            <div class="pt-16 min-h-screen flex flex-col">
                <slot/>
            </div>
        </div> 
        <MobileNav/>
        <div class="sm:h-0 h-16">

        </div>
</template>