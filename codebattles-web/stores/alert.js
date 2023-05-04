import { defineStore } from 'pinia'

export const useAlertStore = defineStore('alert', {
    state: () => {
        return { alerts: [] }
    },
    actions: {
        increment() {
            this.alerts = []
        },
    },
})