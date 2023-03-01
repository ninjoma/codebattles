<script lang="ts">
export default {
    
}
</script>
<template>
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
</template>