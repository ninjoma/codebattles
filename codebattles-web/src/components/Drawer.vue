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
        <div className="drawer-content flex flex-col">
            <!-- Navbar -->
            <Header/>
            <!-- Page content here -->
            <div class="pt-14">
                <slot/>
            </div>
        </div> 
        <div className="drawer-side">
            <label htmlFor="header-drawer" className="drawer-overlay"></label> 
            <ul className="menu p-4 w-80 bg-base-100">
            <!-- Sidebar content here -->
            <li><a>Sidebar Item 1</a></li>
            <li><a>Sidebar Item 2</a></li>
            
            </ul>
            
        </div>
        </div>
</template>