<script lang="ts">
import SectionTitle from './SectionTitle.vue';
import Devicon from './Devicon.vue';
export default {
    components: {
        SectionTitle,
        Devicon
    },
    data() {
        return {
            languages: [
                { icon: 'devicon-nodejs-plain', name: 'Javascript', isActive: false, id: 1,  disabled: false },
                { icon: 'devicon-csharp-plain', name: 'C Sharp', isActive: false, id: 2, disabled: true },
                { icon: 'devicon-python-plain', name: 'Python', isActive: false, id: 3, disabled: true },
                { icon: 'devicon-rust-plain', name: 'Rust', isActive: false, id: 4, disabled: true },
                { icon: 'devicon-cplusplus-plain', name: 'C++', isActive: false, id: 5, disabled: true },
                { icon: 'devicon-css3-plain', name: 'CSS', isActive: false, id:6, disabled: true },

            ]
        }
    },
    methods: {
        selectLanguage(language) {
            if(!language.disabled) {
                this.languages.forEach(element => {
                    element.isActive = false;
                });
                language.isActive = true;
            } 
        },
        createBattle(){
            let selectedLanguage = this.languages.filter((lang) => lang.isActive);
            if(selectedLanguage[0] == null) {
                this.$store.commit("Alert/show", {type: "error", message: "You have to select a language"});
                return;
            }
            this.$store.dispatch("Game/createGame", { language: selectedLanguage[0].id });
        }
    },
    watch: {
        "$store.state.Game.currentGame": {
            handler(currentGame) {
                this.$router.push('/lobby/' + this.$store.state.Game.currentGame.id);
            }
        }
    }
}
</script>

<template>
    <div class="flex flex-col">
        <div class="flex gap-2 flex-1 w-full justify-between items-baseline">
            <SectionTitle>Battles</SectionTitle>
        </div>
        <div class="flex justify-between gap-3 flex-wrap lg:flex-nowrap">
            <div class="flex items-start flex-col w-full">
                <h6 class="">Language of choice</h6>
                <div  class="grid grid-cols-3 lg:grid-cols-6 py-2 gap-3 w-full">
                    <button v-for="language in languages" v-on:click="selectLanguage(language)" :class="'flex flex-col items-center rounded drop-shadow-lg gap-1 p-3 cursor-pointer ' + (language.isActive ? 'btn-success text-black' : 'bg-base-100') + (language.disabled ? 'btn-disabled' : '')">
                        <Devicon :icon="language.icon"></Devicon>
                        {{ language.name }}
                    </button>
                </div>
            </div>
            <div class="lg:max-w-xs w-full">
                <h6 class="">General Settings</h6>
                <div class="flex flex-col gap-2 py-2">
                    <select className="select select-sm w-full">
                        <option disabled selected>Time limit</option>
                        <option>3 min</option>
                        <option>5 min</option>
                        <option>10 min</option>
                        <option>15 min</option>
                        <option>20 min</option>
                    </select>
                    <select className="select select-sm w-full">
                        <option disabled selected>Gamemode</option>
                        <option>Classic</option>
                        <option>Hidden responses</option>
                        <option>Battle Royale</option>
                    </select>
                </div>
                <button v-on:click="createBattle" className="btn btn-sm w-full btn-success gap-1">
                    <font-awesome-icon icon="fa-solid fa-plus" />
                    <span>Create</span>
                </button>
            </div>
        </div>
    </div>
    
</template>