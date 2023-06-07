<script lang="ts">
export default {
    components: {
    },
    mounted() {
    },
    props: {
        displayedList: {
            type: Array<any>,
            required: false,
        }
    }

}
</script>
<template>
    <div class="d-flex flex-column items-center justify-items-center font-bold">
        <div v-if="displayedList == null || displayedList.length == 0" class="bg-info  text-info-content rounded p-3 ">
            No data to display
        </div>
        <div class="overflow-x-auto max-h-82" v-if="displayedList != null && displayedList.length != 0">
            <table class="table w-full">
                <thead class="sticky top-0">
                    <tr>
                        <th v-for="property in Object.keys(displayedList[0])">{{property}}</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="entity in displayedList">
                        <td v-for="property in Object.keys(entity)">{{entity[property]}}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>