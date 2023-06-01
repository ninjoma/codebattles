import { createApp } from 'vue'
import { createStore } from 'vuex'
import axios from "axios";

export default createStore({
	state() {
		return {
			token: ""
		}
	},
	mutations: {
		setToken(state, token) {
			state.token = token
			axios.defaults.headers.common["Authorization"] = state.token ? ('Bearer ' + state.token) : null;
		}
	},
	actions: {
		login({ commit }, token) {
			commit('setToken', token);
		},
		logout({ commit }) {
			commit('setToken', null);
		}
	},
});