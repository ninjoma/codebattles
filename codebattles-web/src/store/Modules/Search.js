import axios from "axios";

export default {
	namespaced: true,
	state() {
		return {
			users: {}
		}
	},
	getters: {
		getUsers(state){
			return state.users;
		}
	},
	mutations: {
		setSearchedUsers(state, users) {
			state.users = users;
		}
	},
	actions: {
		search({ commit }, data){
			axios.get('/api/User', {
				params: {
					username: data.value,
					email: data.value 

				}
			}).then((response) => {
				let formattedUsers = response.data.map(function(element) {
					return {
						id: element.id,
						email: element.email,
						username: element.username,
						avatarBase64: element.avatarBase64
					}
				});
				commit('setSearchedUsers', formattedUsers);
			})
		}
	}
};