<script lang="ts">
import Header from './Header.vue';
export default {
    components: {
        Header
    }
}
</script>
<template>
    <div className="drawer">
        <input id="header-drawer" type="checkbox" className="drawer-toggle" /> 
        <div className="drawer-content flex flex-col min-h-screen">
            <!-- Navbar -->
            <Header/>
            <!-- Page content here -->
            <div class="pt-16 min-h-screen flex flex-col">
                <slot/>
            </div>
        </div> 
        <div className="drawer-side">
            <label htmlFor="header-drawer" className="drawer-overlay"></label> 
            <div className="menu p-4 w-80 bg-base-100">
            <!-- Sidebar content here -->
                <div>
                    
                </div>
            
            </div>
            
        </div>
    </div>
</template>