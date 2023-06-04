<script lang="ts">

export default { 
    components: { 
        
    }, 
    data() {
        return {
            showToast: true,
            alerts: []
        }
    },
    methods: {
        setIcon(type) {
            switch(type) {
                case 'success':
                    return 'fa-circle-check';
                case 'warning':
                    return 'fa-triangle-exclamation';
                case 'info':
                    return 'fa-circle-info';
                case 'error':
                    return 'fa-circle-exclamation';
                default:
                    return 'fa-circle-info';
            }
        }
    }
}
</script>
<style>
.fade-enter-active, .fade-leave-active {
  transition: all .25s;
}
.fade-enter-from, .fade-leave-to {
  opacity: 0;
  transform: scale(0.9);
}
</style>
<template>
    <div class="fixed right-0 bottom-0">
        <TransitionGroup name="fade" tag="div">
            <div v-for="alert in $store.state.Alert">
                <div class="toast m-0 p-2" style="position:unset;">
                    <div :className="'alert alert-' + alert.type">
                        <div class="d-flex gap-3">
                            <font-awesome-icon :icon="'fa-solid ' + setIcon(alert.type)" />
                            <span>{{ alert.message }}</span>
                        </div>
                    </div>
                </div>
            </div>
        </TransitionGroup>
    </div>
</template>