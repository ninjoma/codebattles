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
		}
	},
	mutations: {
		setUser(state, user) {
			state.id = user.id;
			state.username = user.username;
			state.email = user.email;
			state.isPremium = user.isPremium;
			state.isAdmin = user.isAdmin;
		}
	},
	actions: {
		loadProfile({ commit }, data){
			axios.get('/api/User/' + data.id)
			.then((response) => {
				commit('setUser', response.data);
			})
		}
	}
};