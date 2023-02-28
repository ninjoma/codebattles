<script lang="ts">
export default {
    components: {
        
    }
}
</script>

<template>
    <div class="flex flex-col flex-1 items-center bg-base-300">
        <div class="max-w-screen-lg w-full">
            <div class="bg-base-200 m-5 rounded-xl p-2">
                <div class="flex m-5 rounded-xl gap-3">
                    <div className="avatar p-2">
                        <div className="w-44 rounded-xl shadow-lg ring ring-success bg-base-300">
                            
                        </div>
                    </div>
                    <div class="flex flex-col items-stretch w-full">
                        <div class="flex items-baseline flex-col w-full">
                            <h3 class="text-2xl font-bold text-[#36D399]">Username</h3>
                            <blockquote class="text-sm italic">
                                <p>"An Experienced Developer"</p>
                            </blockquote>
                            <div class="p-2 flex flex-col items-center rounded-xl w-full">
                                <div class="flex justify-end flex-1 items-baseline gap-1 font-inter w-full">
                                    <a>LEVEL</a>
                                    <a class="text-3xl text-[#36D399]">23</a>
                                </div>
                                <progress className="progress progress-success h-10 m-1 rounded-sm" value="30" max="100"></progress>
                                <div class="flex justify-end font-inter w-full">
                                    <a>CurrEXP / MaxEXP</a>
                                </div>
                            </div>
                            <div class="flex gap-2">
                                <button className="btn btn-sm flex gap-2">
                                    <font-awesome-icon icon="fa-solid fa-plus" /> Friend List
                                </button>
                                <button className="btn btn-sm flex gap-2">
                                    <font-awesome-icon icon="fa-solid fa-flag"  /> Report
                                </button>
                                <button className="btn btn-sm flex gap-2">
                                    <font-awesome-icon icon="fa-solid fa-pen-to-square" /> Edit Profile
                                </button>
                            </div>
                            <div class="flex">

                            </div>
                        </div>
                        <div class="flex gap-1">
                            <div class="">
                                <div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

