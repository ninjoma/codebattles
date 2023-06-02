import { createApp } from 'vue'
import { createStore } from 'vuex'
import axios from "axios";

const defaultUser = {
	id: null,
	username: "",
	email: "",
	isPremium: false,
	isAdmin: false
}

export default createStore({
	state() {
		return {
			token: "",
			user: defaultUser,
			isLogged: false
		}
	},
	getters: {
		isLogged(state){
			return state.isLogged;
		}
	},
	mutations: {
		login(state, data) {
			axios.post("/api/Auth/Login", {
                email: data.email,
                password: data.password
            })
            .then((tokenResponse) => {
                state.token = tokenResponse.data
				state.token.length > 1 ? state.isLogged = true : state.isLogged = false;
				axios.defaults.headers.common["Authorization"] = state.token ? ('Bearer ' + state.token) : null;
				axios.get('/api/User/me').then((userResponse) => {
					state.user = {
						id: userResponse.data.id,
						email: userResponse.data.email,
						isPremium: userResponse.data.isPremium,
						isAdmin: userResponse.data.isAdmin
					}
				})
            })
		},
		register(state, data) {

		},
		logout(state) {
			state.token = "";
			state.user = defaultUser;
			state.isLogged = false;
		}
	},
});