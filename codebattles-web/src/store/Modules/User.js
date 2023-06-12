import axios from "axios";

const defaultUser = {
	token: localStorage.token,
	id: null,
	username: "",
	email: "",
	isPremium: false,
	isAdmin: false,
	isLogged: false,
	avatarBase64: "",
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
			state.token = localStorage.token;
			axios.defaults.headers.common["Authorization"] = state.token ? ('Bearer ' + state.token) : null;
			state.id = data.id;
			state.email = data.email;
			state.level = data.level;
			state.experience = data.experience;
			state.isPremium = data.isPremium;
			state.isAdmin = data.isAdmin;
			state.avatarBase64 = data.avatarBase64;
			state.isLogged = true;
		},
		login(state, token) {
			if(token.length < 1){
				return;
			};
			localStorage.token = token;
			state.token = localStorage.token;
			axios.defaults.headers.common["Authorization"] = state.token ? ('Bearer ' + state.token) : null;
			state.isLogged = true;
		},
		loginsso(state, token) {
			if(token.length < 1){
				return;
			};
			localStorage.token = token;
			state.token = localStorage.token;
			axios.defaults.headers.common["Authorization"] = state.token ? ('Bearer ' + state.token) : null;
			state.isLogged = true;
		},
		logout(state) {
			delete localStorage.token;
			state.isLogged = false;
			state = defaultUser;
		},
	},
	actions: {
		register({ commit }, data) {
			axios.post('/Auth/Register', {
                username: data.username,
                email: data.email,
                password: data.password
            }).then((response) => {
				login({ commit }, response.data);
            });
		},
		load({ commit }) {
			axios.get('/User/me').then((userResponse) => {
				commit('load', userResponse.data);
			});
		},
		loginsso({ commit }, data){
			axios.post("/sso/login", data).then((userResponse) => {
				commit('loginsso', userResponse.data);	
				load({ commit });
            });
		},
		login({ commit }, data){
			return axios.post("/Auth/Login", {
                email: data.email,
                password: data.password
            })
            .then((tokenResponse) => {
				commit('login', tokenResponse.data);
				load({ commit });
            }).catch((call) => {
				if(call.response.data.errorCode == 2) {
					return call.response.data.errorTranslation;
				}
			});
		},
		resetPassword({ commit }, data){
			axios.get('/Auth/Password', {
                params: { email: data }
            })
		},
		verifyPassword({ commit }, data){
			axios.post('/Auth/Password', { 
				NewPassword: data.password,
				RepeatNewPassword: data.verifypassword,
				PasswordResetToken: data.token
			}).then((response) => {
				
            });
		}
	}
};