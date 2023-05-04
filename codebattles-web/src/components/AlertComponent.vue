<script lang="ts">
import { useAlertStore } from "../../stores/alert.js";

const alertStore = useAlertStore()

export default {
    data(){
        return {
            alerts: alertStore.alerts
        }
    }
}
</script>
<template>
<div v-for="alert in alerts" className="alert alert-error">
    <div>
        <font-awesome-icon icon="fa-solid fa-circle-xmark" />
        <span>{{ alert }}</span>
    </div>
</div>
</template>