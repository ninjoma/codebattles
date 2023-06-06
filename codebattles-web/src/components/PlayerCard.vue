<script lang="ts">
export default {
    props: ['level', 'username']
}
</script>
<template>
    <div className="flex gap-2">
        <div className="bg-base-300 rounded-lg p-2 flex gap-1 items-center">
            <font-awesome-icon icon="fa-solid fa-crown" />
            <a className="font-bold text-sm">{{ level }}</a>
        </div>
        <div className="bg-base-300 rounded-lg p-2">
            <span>{{ username }}</span>
        </div>
    </div>
</template>