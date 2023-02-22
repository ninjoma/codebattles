<script lang="ts">
import Header from "../components/Header.vue";
import LobbyHeader from "../components/LobbyHeader.vue";
import CodeEditor from "../components/CodeEditor.vue";
export default {
    components: {
        Header,
        LobbyHeader,
        CodeEditor
    }
}
</script>

<template>
    <div class="h-screen flex flex-col">
        <Header></Header>
        <LobbyHeader></LobbyHeader>
        <div class="w-full py-2.5 px-4 flex gap-40 justify-between items-center">
            <div className="w-1/2 flex gap-2">
              <div className="bg-base-300 rounded-lg p-2">
                
                <a className="font-bold text-sm">55</a>
              </div>
              <div className="bg-base-300 rounded-lg p-2">
                <span>Mega Sweat Lord</span>
              </div>
            </div>
            <div className="w-1/2 flex">
              <div className="bg-base-300 rounded-lg p-2">
                <a className="font-bold">LVL:55 </a>
                <span>Mega Sweat Lord</span>
              </div>
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

