import axios from "axios";
import Store from '../index.js';

export default {
    namespaced: true,
    state() {
        return {
            languages: [],
        }
    },
    getters: {
        getLanguages(state) {
            return state.languages;
        }
    },
    mutations: {
        setLanguages(state, languages) {
            state.languages = languages;
        },
    },
    actions: {
        retrieveLanguages({ commit }) {
            axios.get('/Language', {
            }).then((response) => {
                commit('setLanguages', response.data);
            })
        }
    }
};