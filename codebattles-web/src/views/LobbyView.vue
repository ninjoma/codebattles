<script lang="ts">
import LobbyHeader from "../components/LobbyHeader.vue";
import CodeEditor from "../components/CodeEditor.vue";
import PlayerCard from "../components/PlayerCard.vue";
import ScoreCard from "../components/ScoreCard.vue";
export default {
    components: {
        LobbyHeader,
        CodeEditor,
        PlayerCard,
        ScoreCard
    }
}
</script>

<template>
    <div class="flex flex-col flex-1">
        <div class="w-full font-inter">
            <div className="collapse collapse-arrow bg-success">
                <input type="checkbox" className="peer" /> 
                <div className="collapse-title text-primary-content">
                    <h3 class="font-inter text-xl font-bold text-black">Exercise: A walk in the park</h3>
                </div>
                <div className="collapse-content text-primary-content"> 
                    <p className="rounded-xl bg-base-300 p-2">
Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus eget mattis metus, nec tempus tortor. Donec turpis ex, semper eget tellus quis, mattis pellentesque quam. Nulla facilisi. Mauris in arcu et diam efficitur ornare ac ut libero. Cras quis lorem laoreet neque facilisis laoreet sit amet quis nulla. Mauris eget gravida ipsum. Sed mollis rhoncus mi bibendum vehicula. Pellentesque id tellus id massa feugiat scelerisque et quis massa. Nullam erat augue, imperdiet in consectetur ut, eleifend vel metus. Quisque et felis sed odio tempor eleifend. Maecenas id lectus dui. Morbi pretium, odio a placerat porttitor, leo ligula feugiat sem, quis malesuada metus augue eu neque. Proin vulputate maximus dui, vitae rhoncus justo aliquet vitae.</p>
                </div>
            </div>
        </div>
        <LobbyHeader></LobbyHeader>
        <div class="w-full py-2.5 px-4 flex gap-40 justify-between items-center">
            <div className="w-1/2 flex justify-between">
                <PlayerCard/>
                <ScoreCard/>
            </div>
            <div className="w-1/2 flex justify-between">
                <ScoreCard/>
                <PlayerCard/>
            </div>
        </div>
        <div class="flex grow w-full px-4 pb-2 gap-5">
            <div class="grow w-1/2 bg-base-200 rounded-tr-lg p-3">
                <CodeEditor></CodeEditor>
            </div>
            <div class="grow w-1/2 bg-base-200 rounded-tl-lg p-3">
                <CodeEditor></CodeEditor>
            </div>
        </div>
    </div>
</template>

