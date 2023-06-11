<script lang="ts">
import GoogleButton from './GoogleButton.vue';
import SectionTitle from './SectionTitle.vue';
import axios from "axios";

export default { 
    components: {
        GoogleButton,
        SectionTitle,
    },
    methods: {
        login() {
            var emailInput = (this.$refs.email as any);
            var passwordInput = (this.$refs.password as any);
            if(emailInput.value.length > 3 && passwordInput.value.length > 3) {
                this.$store.dispatch("User/login", {email: (this.$refs.email as any).value, password: (this.$refs.password as any).value});
            } else {
                this.$store.commit("Alert/show", {type: "error", message: "username and password both have to be over 3 characters long."});
            }
        },
        test() {
            axios.post("https://codebattlesapi.azurewebsites.net/Auth/Login", {
                email: "data.email",
                password: "data.password"
            })
        }
    },
    watch: {
        "$store.state.User.isLogged": {
            handler(isLogged) {
                if(isLogged == true) {
                    this.$router.push("/battle");
                    this.$store.dispatch("User/load");
                } 
            }
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
                <router-link to="/forgot-password">
                    <a className="link" href="">I've forgotten my password</a>
                </router-link>
            </label>
        </div>
        <div class="pb-5">
            <div class="flex flex-col items-center gap-y-5">
                <div class="flex flex-col gap-3 items-center w-full">
                    <button className="btn flex-1 w-full btn-success" v-on:click="login">Log In</button>
                    <GoogleButton className="flex justify-center"></GoogleButton>
                </div>
                <b className="text-success">Don't have a codebattles account?</b>
                <router-link to="/register" tag="button" className="btn flex-1 w-full">Register</router-link>
            </div>
        </div>
    </div>
</template> 