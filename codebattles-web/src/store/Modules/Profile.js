import axios from "axios";

export default {
	namespaced: true,
	state() {
		return {
			id: null,
			username: "",
			email: "",
			isPremium: false,
			isAdmin: false,
			level: 0,
			avatarBase64: "",
			badges: "",
		}
	},
	mutations: {
		setUser(state, user) {
			state.id = user.id;
			state.username = user.username;
			state.email = user.email;
			state.isPremium = user.isPremium;
			state.isAdmin = user.isAdmin;
			state.level = user.level;
			state.experience = user.experience;
			state.avatarBase64 = user.avatarBase64;
			state.badges = user.badges;
		}
	},
	actions: {
		loadProfile({ commit }, data){
			axios.get('/User/' + data.id)
			.then((response) => {
				commit('setUser', response.data);
			})
		},
		updateProfile({ commit }, data) {
			axios.put('/User/me', {
				username: data.username,
				avatarBase64: data.avatarBase64,
			})
			.then((response) => {
				
			})
		}
	}
};