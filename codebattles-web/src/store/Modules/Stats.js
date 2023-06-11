import axios from "axios";
export default {
    namespaced: true,
    state() {
        return {
            Stats: {
                totalBattles: 0,
                wonBattles: 0,
                wonbattlesRatio: 0,
                fastestWin: 0,
                wonInRow: 0,
            },
        }
    },
    getters: {
        getLanguages(state) {
            return state.languages;
        }
    },
    mutations: {
        setStats(state, Stats) {
            state.Stats = Stats;
        },
    },
    actions: {
        retrieveStats({ commit }) {
            axios.get('/Stat/me', {
            }).then((response) => {
                commit('setStats', response.data);
            })
        }
    }
};