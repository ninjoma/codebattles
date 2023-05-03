<script lang="ts">
import GoogleButton from './GoogleButton.vue';
import RegisterForm from './RegisterForm.vue';
import SectionTitle from './SectionTitle.vue';
import LoginForm from './LoginForm.vue';
import ResetPasswordForm from './ResetPasswordForm.vue';



export default { 
    components: {
        GoogleButton,
        SectionTitle,

    },
    data() {

    }
}

</script>
<template>
    <div class="lg:rounded-xl p-4 lg:p-10 font-inter w-full">
        <SectionTitle>Login</SectionTitle>
        <div className="form-control w-full py-2">
            <input type="text" placeholder="Username" className="input input-bordered w-full" />
        </div>
        <div className="form-control w-full py-2">
            <input type="password" placeholder="Password" className="input input-bordered w-full" />
            <label className="label">
                <span className="label-text-alt"><a className="link" href="/forgot-password">I've forgotten my password</a></span>
            </label>
        </div>
        <div class="pb-5">
            <div class="flex flex-col items-center gap-y-5">
                <div class="flex flex-col gap-3 items-center w-full">
                    <button className="btn flex-1 w-full btn-success">Log In</button>
                    <GoogleButton className="w-full"></GoogleButton>
                </div>
                <b className="text-success">Don't have a codebattles account?</b>
                <router-link to="/register" tag="button" className="btn flex-1 w-full">Register</router-link>
            </div>
        </div>
    </div>
</template> 