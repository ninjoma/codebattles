<script lang="ts">
import GoogleButton from './GoogleButton.vue';
import SectionTitle from './SectionTitle.vue';
import axios from "axios";

export default { 
    components: {
        GoogleButton,
        SectionTitle,

    },
    data() {

    },
    methods: {
        login() {
            axios.post("/api/Auth/Login", {
                email: this.$refs.email,
                password: this.$refs.password
            })
            .then((response) => {
                this.$store.commit("setToken", response.data);
            })
        }
    }
}

</script>
<template>
    <div class="lg:rounded-xl p-4 lg:p-10 font-inter w-full">
        <SectionTitle>Login</SectionTitle>
        <div className="form-control w-full py-2">
            <input ref="email" type="text" placeholder="Email" className="input input-bordered w-full" />
        </div>
        <div className="form-control w-full py-2">
            <input ref="password" type="password" placeholder="Password" className="input input-bordered w-full" />
            <label className="label">
                <span className="label-text-alt"><a className="link" href="/forgot-password">I've forgotten my password</a></span>
            </label>
        </div>
        <div class="pb-5">
            <div class="flex flex-col items-center gap-y-5">
                <div class="flex flex-col gap-3 items-center w-full">
                    <button className="btn flex-1 w-full btn-success" :on-click="login">Log In</button>
                    <GoogleButton className="w-full"></GoogleButton>
                </div>
                <b className="text-success">Don't have a codebattles account?</b>
                <router-link to="/register" tag="button" className="btn flex-1 w-full">Register</router-link>
            </div>
        </div>
    </div>
</template> 