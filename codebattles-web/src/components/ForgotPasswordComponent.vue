<script lang="ts">
import SectionTitle from './SectionTitle.vue';
import { event } from "vue-gtag";

export default { 
    components: { 
        SectionTitle 
    },
    methods: {
        resetPassword() {
            event('resetPassword', { event_category: 'login' })
            this.$store.dispatch('User/resetPassword', (this.$refs.email as any).value);
            this.$router.push('/verify-password');
        }
    }
}
</script>
<template>
    <div class="lg:rounded-xl p-4 lg:p-10 font-inter w-full">
        <SectionTitle>Reset Password</SectionTitle>
        <div class="flex gap-3">
            <div className="form-control w-full py-2">
                <input ref="email" type="text" placeholder="Email" className="input input-bordered w-full" />
            </div>
        </div>
        <div class="pb-5">
            <div class="flex flex-col items-center gap-y-5 py-3">
                <div class="flex gap-3 items-center w-full">
                    <router-link to="/login" tag="button" className="btn flex-1 w-full">Back</router-link>
                    <router-link to="/verify-password" tag="button" className="btn flex-1 w-full btn-success" @click="resetPassword">
                        Send Recovery Email
                    </router-link>
                </div>
            </div>
        </div>
    </div>
</template>