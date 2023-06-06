<script lang="ts">
import LobbyHeader from "./LobbyHeader.vue";
import CodeEditor from "./CodeEditor.vue";
import PlayerCard from "./PlayerCard.vue";
import ScoreCard from "./ScoreCard.vue";
import { startSignalRConnection } from "../signalr/signalr";
import { HubConnection } from "@microsoft/signalr";
export default {
    components: {
        LobbyHeader,
        CodeEditor,
        PlayerCard,
        ScoreCard
    },
    data() {
        return {
            battleId: '',
            myCode: '',
            enemyCode: '',
            connection: null as HubConnection | null,
            test: '1',
        }
    },
    created() {
        startSignalRConnection().then(connection => {
            this.battleId = Array.isArray(this.$route.params.battleId)
                ? this.$route.params.battleId[0]
                : this.$route.params.battleId;

            connection.invoke("JoinBattle", this.battleId)
            .catch((error: any) => {
                console.error(error);
            });

            connection.on("RecieveCode", this.RecieveMessage);
            connection.on("UserJoined", this.UserJoined);
            connection.on("UserLeft", this.UserJoined);
            this.connection = connection;
        })

    },
    methods: {
        SendMessage() {
            if (this.connection != null) {
                this.connection.invoke("SendCode", this.battleId, this.myCode, "1")
                .catch((error: any) => {
                    console.error(error);
                });
            }
        },
        RecieveMessage(mensaje: any) {
            this.enemyCode = mensaje.code;
        },
        onCodeEditorChange(event: any) {
            setTimeout(() => {
                this.SendMessage();
            }, 150);
        },
        UserJoined(mensaje: any) {
            this.SendMessage()
        },
        UserLeft(mensaje: any) {
            
        },
        getOtherParticipantInfo(data){
            this.$store.state.Game.currentGame.participants;
        }
    }
}
</script>

<template>
    <LobbyHeader></LobbyHeader>
    <div class="w-full py-2.5 px-4 flex gap-40 justify-between items-center">
        <div className="w-1/2 flex justify-between">
            <PlayerCard :level="$store.state.User.level" />
            <ScoreCard />
        </div>
        <div className="w-1/2 flex justify-between">
            <ScoreCard />
            <PlayerCard :level="1"  />
        </div>
    </div>
    <div class="flex grow w-full px-4 pb-2 gap-5">
        <div class="grow w-1/2 bg-base-200 rounded-tr-lg p-3">
            <CodeEditor v-model="myCode" @codeEditor:onchange="onCodeEditorChange"></CodeEditor>
        </div>
        <div class="grow w-1/2 bg-base-200 rounded-tl-lg p-3">
            <CodeEditor v-model="enemyCode" :disabled="true"></CodeEditor>
        </div>
    </div>
</template>