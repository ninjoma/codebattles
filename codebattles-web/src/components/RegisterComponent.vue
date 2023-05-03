<script lang="ts">
import SectionTitle from './SectionTitle.vue';



export default { 
    components: {
        SectionTitle,

    },
    data() {

    }
}

</script>
<template>
    <div class="lg:rounded-xl p-4 lg:p-10 font-inter w-full">
        <SectionTitle>Register</SectionTitle>
        <div class="flex gap-3">
            <div className="form-control w-full py-2">
                <input type="text" placeholder="First Name" className="input input-bordered w-full" />
            </div>
            <div className="form-control w-full py-2">
                <input type="text" placeholder="Last Name" className="input input-bordered w-full" />
            </div>
        </div>
        <div className="form-control w-full py-2">
            <input type="text" placeholder="Username" className="input input-bordered w-full" />
        </div>
        <div className="form-control w-full py-2">
            <input type="text" placeholder="Email" className="input input-bordered w-full" />
        </div>
        <div className="form-control w-full py-2">
            <input type="password" placeholder="Password" className="input input-bordered w-full" />
        </div>
        <div class="pb-5">
            <div class="flex flex-col items-center gap-y-5">
                <div class="flex flex-col gap-3 items-center w-full">
                    <button className="btn flex-1 w-full btn-success">Register</button>
                </div>
                <b className="text-success">Already have a codebattles account?</b>
                <router-link to="/login" tag="button" className="btn flex-1 w-full">Login</router-link>
            </div>
        </div>
    </div>
</template> 