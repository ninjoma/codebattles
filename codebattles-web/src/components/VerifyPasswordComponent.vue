<script lang="ts">
import SectionTitle from './SectionTitle.vue';
import { event } from "vue-gtag";

export default { 
    components: { 
        SectionTitle 
    },
    methods: {
        resetPassword() {
            var passwordValue = (this.$refs.password as any).value;
            var verifypasswordValue = (this.$refs.verifypassword as any).value;
            var tokenValue = (this.$refs.token as any).value;

            event('verifypassword', { event_category: 'login' })
            this.$store.dispatch('User/verifyPassword', { token: tokenValue, password: passwordValue, verifypassword: verifypasswordValue })
            this.$router.push('/login');
        }
    }
}
</script>
<template>
    <div class="lg:rounded-xl p-4 lg:p-10 font-inter w-full">
        <SectionTitle>Reset Password</SectionTitle>
        <div class="flex gap-3">
            <div className="form-control w-full py-2">
                <input ref="token" type="text" placeholder="Token" className="input input-bordered w-full" />
            </div>
        </div>
        <div class="flex gap-3">
            <div className="form-control w-full py-2">
                <input  ref="password" type="text" placeholder="Password" className="input input-bordered w-full" />
            </div>
        </div>
        <div className="form-control w-full py-2">
            <input type="password" ref="verifypassword" placeholder="Repeat Password" className="input input-bordered w-full" />
        </div>
        <div class="pb-5">
            <div class="flex flex-col items-center gap-y-5 py-3">
                <div class="flex gap-3 items-center w-full">
                    <router-link to="/forgot-password" tag="button" className="btn flex-1 w-full">Back</router-link>
                    <button @click="resetPassword" className="btn flex-1 w-full btn-success">Reset Password</button>
                </div>
            </div>
        </div>
    </div>
</template>