import axios from "axios";

const defaultUser = {
	token: localStorage.token,
	id: null,
	username: "",
	email: "",
	isPremium: false,
	isAdmin: false,
	isLogged: false
}

export default {
	namespaced: true,
	state() {
		return defaultUser
	},
	getters: {
		isLogged(state){
			return state.isLogged;
		},
		getId(state){
			return state.id;
		}
	},
	mutations: {
		load(state, data) {
			state.isLogged = data;
			if(state.isLogged) {
				axios.defaults.headers.common["Authorization"] = state.token ? ('Bearer ' + state.token) : null;
			}	
			axios.get('/api/User/me').then((userResponse) => {
				state.id = userResponse.data.id;
				state.email = userResponse.data.email;
				state.level = userResponse.data.level;
				state.experience = userResponse.data.experience;
				state.isPremium = userResponse.data.isPremium;
				state.isAdmin = userResponse.data.isAdmin;
			});
		},
		login(state, data) {
			axios.post("/api/Auth/Login", {
                email: data.email,
                password: data.password
            })
            .then((tokenResponse) => {
				if(tokenResponse.data.length < 1){
					return;
				};
				localStorage.token = tokenResponse.data;
				state.token = localStorage.token;
				axios.defaults.headers.common["Authorization"] = state.token ? ('Bearer ' + state.token) : null;
				state.isLogged = true;
            })
		},
		loginsso(state, data) {
			axios.post("/api/sso/login", data)
            .then((tokenResponse) => {
				localStorage.token = tokenResponse.data;
				state.token = localStorage.token;
				axios.defaults.headers.common["Authorization"] = state.token ? ('Bearer ' + state.token) : null;
				state.isLogged = true;
            })
		},
		logout(state) {
			delete localStorage.token;
			state.isLogged = false;
			state = defaultUser;
		},
	},
	actions: {
		register({ commit }, data) {
			axios.post('/api/Auth/Register', {
                username: data.username,
                email: data.email,
                password: data.password
            }).then((response) => {
                commit("login", {email: data.email, password: data.password});
            });
		},
		load({ commit }) {
			commit('load', localStorage.token != null);
		},
		loginsso({ commit }, data){
			commit('loginsso', data);
		},
		login({ commit }, data){
			commit('login', data);
			commit('load', localStorage.token != null);
		}
	}
};