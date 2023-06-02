<script lang="ts">
import SectionTitle from './SectionTitle.vue';

export default { 
    components: { 
        SectionTitle 
    }
}
</script>
<template>
    <div class="lg:rounded-xl p-4 lg:p-10 font-inter w-full">
        <SectionTitle>Reset Password</SectionTitle>
        <div class="flex gap-3">
            <div className="form-control w-full py-2">
                <input type="text" placeholder="Password" className="input input-bordered w-full" />
            </div>
        </div>
        <div className="form-control w-full py-2">
            <input type="password" placeholder="Repeat Password" className="input input-bordered w-full" />
        </div>
        <div class="pb-5">
            <div class="flex flex-col items-center gap-y-5 py-3">
                <div class="flex gap-3 items-center w-full">
                    <router-link to="/login" tag="button" className="btn flex-1 w-full">Back</router-link>
                    <button className="btn flex-1 w-full btn-success">Reset Password</button>
                </div>
            </div>
        </div>
    </div>
</template>