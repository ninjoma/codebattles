<script lang="ts">
import {ref, shallowRef } from "vue"
import { Codemirror } from "vue-codemirror"
import { javascript } from '@codemirror/lang-javascript'
import { oneDark } from "@codemirror/theme-one-dark"


export default {
    components: {
        Codemirror
    },
    setup() {
        const code = ref(`console.log("Hello, world!")`);
        const extensions = [javascript(), oneDark];
        const view = shallowRef();

        const handleReady = (payload: any) => {
            view.value = payload.view
        }

        const getCodemirrorStates = () => {
            const state = view.value.state
            const ranges = state.selection.ranges
            const selected = ranges.reduce((r: any, range: any) => r + range.to - range.from, 0)
            const cursor = ranges[0].anchor
            const length = state.doc.length
            const lines = state.doc.lines
            // more state info ...
            // return ...
        }

        return {
            code,
            extensions,
            handleReady,
            log: console.log
        }

    }

}
</script>
<template>
    <codemirror
        v-model="code"
        placeholder="Nothing here yet..."
        :autofocus="false"
        :indent-with-tab="true"
        :tab-size="2"
        :style= "{
            height: '100%'
        }"
        :extensions="extensions"
        @ready="handleReady"
        @change="log('change', $event)"
        @focus="log('focus', $event)"
        @blur="log('blur', $event)"
    />
</template>