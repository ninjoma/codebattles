<script lang="ts">
import LobbyHeader from "./LobbyHeader.vue";
import CodeEditor from "./CodeEditor.vue";
import PlayerCard from "./PlayerCard.vue";
import ScoreCard from "./ScoreCard.vue";
import { startSignalRConnection } from "../signalr/signalr";
import { HubConnection } from "@microsoft/signalr";
import { mapState } from "vuex";
import axios from "axios";
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
            this.myCode = this.currentStep?.boilerPlate;
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
        Submited() {
            axios.post('/Code', {
                battleId: this.$store.state.Game.currentGame.id,
                code: this.myCode
            }).then((response) => {
                this.$store.dispatch("Game/getGame", this.$route.params.battleId);
                this.$store.commit('Alert/show', { type: 'success', message: 'you passed the step!' })
                setTimeout(() => {
                    this.Closegame();
                }, 3000);

            }).catch((error) => {
                this.$store.commit('Alert/show', { type: 'error', message: error.response.data.message })
            })
        },
        Closegame() {
            if (this.currentGame.userInBattle?.currentStep == this.currentGame?.steps.length) {
                this.$store.commit('Alert/show', { type: 'success', message: 'you won!' })
                this.$router.push("../battle");
            }
        }
    },
    computed: mapState({
        currentGame: state => state.Game.currentGame,
        currentStep: state => state.Game.currentGame.steps[state.Game.currentGame.userInBattle?.currentStep]
    }),
    watch: {
    }
}
</script>

<template>
    <LobbyHeader @Submited="Submited"></LobbyHeader>
    <div class="h-8 lg:h-0">
    </div>
    <div class="w-full grow py-2 flex overflow-x-scroll lg:overflow-x-none no-scrollbar">
        <div class="lg:w-1/2 flex flex-col grow gap-1">
            <div className="lg:w-full w-screen flex justify-between px-4">
                <PlayerCard :level="currentGame.userInBattle?.user.level ?? '0'"
                    :username="currentGame.userInBattle?.user.username ?? 'Waiting...'" />
                <div class="lg:pr-20">
                    <ScoreCard :currentStep="currentGame.userInBattle?.currentStep ?? '0'"
                        :totalSteps="currentGame?.steps.length ?? '0'" />
                </div>
            </div>
            <div className="lg:w-full flex grow no-scrollbar">
                <div class="px-4 w-screen flex grow">
                    <div class="w-full grow bg-base-200 rounded-tl-lg p-3 flex-shrink-0">
                        <CodeEditor v-model="myCode" @codeEditor:onchange="onCodeEditorChange"></CodeEditor>
                    </div>
                </div>
            </div>
        </div>
        <div class="lg:w-1/2 flex flex-col grow gap-1">
            <div className="lg:w-full w-screen flex justify-between px-4">
                <div className="lg:pl-20">
                    <PlayerCard :level="currentGame.userInBattle?.user.level ?? '0'"
                        :username="currentGame.userInBattle?.user.username ?? 'Waiting...'" />
                </div>
                <ScoreCard :currentStep="currentGame.userInBattle?.currentStep ?? '0'"
                    :totalSteps="currentGame?.steps.length ?? '0'" />
            </div>
            <div className="lg:w-full flex grow no-scrollbar">
                <div class="px-4 w-screen flex grow">
                    <div class="w-full grow bg-base-200 rounded-tl-lg p-3 flex-shrink-0">
                        <CodeEditor v-model="enemyCode" :disabled="true"></CodeEditor>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>