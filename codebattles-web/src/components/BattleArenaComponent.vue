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
        document.addEventListener('keydown', this.HandleGlobalKeyDown);

        startSignalRConnection().then(connection => {
            this.battleId = Array.isArray(this.$route.params.battleId)
                ? this.$route.params.battleId[0]
                : this.$route.params.battleId;

            connection.invoke("JoinBattle", this.battleId).then(() => {
                console.log("- You succesfully joined 'battle " + this.battleId + "'")
            })
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
                this.connection.invoke("SendCode", this.battleId, this.myCode, "1") //TODO: Cambiar el uno por el ID del usuario
                    .then(() => {
                        console.log("Code succesfully sended")
                    })
                    .catch((error: any) => {
                        console.error(error);
                    });
            }
        },
        RecieveMessage(mensaje: any) {
            console.log(mensaje)
            if (mensaje.userId != this.test) { //TODO: Cambiar el test por el ID del usuario
                this.enemyCode = mensaje.code;
            }
            console.log(this.test)
        },
        HandleGlobalKeyDown(event: any) {
            if (event.key === 's' && event.ctrlKey) {
                event.preventDefault(); // Evitar el comportamiento predeterminado (guardar la página)
                this.SendMessage();
            }
        },
        UserJoined(mensaje: any) {
            console.log(mensaje);
        },
        UserLeft(mensaje: any) {
            console.log(mensaje);
        }
    }
}
</script>

<template>
    <LobbyHeader></LobbyHeader>
    <input type="text" v-model="test">
    <div class="w-full py-2.5 px-4 flex gap-40 justify-between items-center">
        <div className="w-1/2 flex justify-between">
            <PlayerCard />
            <ScoreCard />
        </div>
        <div className="w-1/2 flex justify-between">
            <ScoreCard />
            <PlayerCard />
        </div>
    </div>
    <div class="flex grow w-full px-4 pb-2 gap-5">
        <div class="grow w-1/2 bg-base-200 rounded-tr-lg p-3">
            <CodeEditor v-model="myCode"></CodeEditor>
        </div>
        <div class="grow w-1/2 bg-base-200 rounded-tl-lg p-3">
            <CodeEditor v-model="enemyCode"></CodeEditor>
        </div>
    </div>
</template>