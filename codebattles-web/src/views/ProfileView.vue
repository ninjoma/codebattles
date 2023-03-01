<script lang="ts">
export default {
    components: {
        
    }
}
</script>

<template>
    <div class="flex flex-col flex-1 items-center bg-base-300">
        <div class="max-w-screen-lg w-full">
            <div class="bg-base-100 m-5 rounded-xl p-2">
                <div class="flex flex-col sm:flex-row m-5 rounded-xl gap-3">
                    <div className="avatar p-2 justify-center sm:justify-start">
                        <div className="w-44 rounded-xl shadow-lg ring ring-success bg-base-100">
                            
                        </div>
                    </div>
                    <div class="flex flex-col items-stretch w-full">
                        <div class="flex flex-col w-full">
                            <div class="flex w-full">
                                <div>
                                    <h3 class="text-2xl font-bold text-[#36D399]">Username</h3>
                                    <blockquote class="text-sm italic">
                                        <p>"An Experienced Developer"</p>
                                    </blockquote>
                                </div>
                                <div class="flex justify-end flex-1 items-baseline gap-1 font-inter w-full">
                                    <a>LEVEL</a>
                                    <a class="text-3xl text-[#36D399]">23</a>
                                </div>
                            </div>
                            <div class="py-2 flex flex-col items-center rounded-xl w-full">
                                <progress className="progress progress-success h-10 m-1 rounded-sm" value="30" max="100"></progress>
                                <div class="flex justify-end font-inter w-full">
                                    <a>CurrEXP / MaxEXP</a>
                                </div>
                            </div>
                            <div class="flex gap-2 w-full">
                                <button className="btn flex gap-2 flex-1">
                                    <font-awesome-icon icon="fa-solid fa-plus" /> Friend List
                                </button>
                                <button className="btn flex gap-2 flex-1">
                                    <font-awesome-icon icon="fa-solid fa-flag"  /> Report
                                </button>
                                <button className="btn flex gap-2 flex-1">
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
            <div class="bg-base-100 m-5 rounded-xl p-2">
                <div>
                    <h3 className="px-6 pt-3 text-xl underline underline-offset-4 font-inter decoration-4 decoration-[#36D399]">Stats</h3>
                </div>
                <div class="flex flex-col">
                    <div className="stats w-full font-inter flex flex-col sm:flex-row sm:flex-row stats-vertical sm:stats-horizontal">
                        <div className="stat text-center flex-1">
                            <div className="stat-title">Total Battles</div>
                            <div className="stat-value text-success">1,131</div>
                            <div className="stat-desc">200 in the last week</div>
                        </div>
                        <div className="stat text-center flex-1">
                            <div className="stat-title">Won Battles</div>
                            <div className="stat-value text-success">1,000</div>
                            <div className="stat-desc">30 in the last week</div>
                        </div>
                        <div className="stat text-center flex-1">
                            <div className="stat-title">Ratio of Battles Won</div>
                            <div className="stat-value text-success">44,33%</div>
                            <div className="stat-desc">21% more than last week</div>
                        </div>
                    </div>
                    <div className="stats w-full font-inter flex flex-col sm:flex-row stats-vertical sm:stats-horizontal">
                        <div className="stat text-center flex-1">
                            <div className="stat-title">Fastest Win</div>
                            <div className="stat-value text-success">55s</div>
                            <div className="stat-desc">200 in the last week</div>
                        </div>
                        <div className="stat text-center flex-1">
                            <div className="stat-title">Won in a row</div>
                            <div className="stat-value text-success">33</div>
                            <div className="stat-desc">Back in 2019</div>
                        </div>
                        <div className="stat text-center flex-1">
                            <div className="stat-title">Ratio of Battles Won</div>
                            <div className="stat-value text-success">44,33%</div>
                            <div className="stat-desc">21% more than last week</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

