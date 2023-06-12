<script lang="ts">
export default {
    props: ['currentStep', 'totalSteps']
}
</script>

<template>
    <div className="bg-base-300 rounded-lg p-2 flex gap-1 items-center">
        <font-awesome-icon icon="fa-solid fa-circle-arrow-up" />
            <a className="font-bold text-sm">{{ currentStep }} / {{ totalSteps }}</a>
    </div>
</template>