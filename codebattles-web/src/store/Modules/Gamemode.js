import axios from "axios";
import Store from '../index.js';

export default {
    namespaced: true,
    state() {
        return {
            gamemodes: [],
        }
    },
    getters: {
        getGamemodes(state) {
            return state.gamemodes;
        }
    },
    mutations: {
        setGamemodes(state, gamemodes) {
            state.gamemodes = gamemodes;
        },
    },
    actions: {
        retrieveGamemodes({ commit }) {
            axios.get('/api/GameMode', {
            }).then((response) => {
                commit('setGamemodes', response.data);
            })
        }
    }
};