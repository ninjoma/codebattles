import axios from "axios";

export default {
	namespaced: true,
	state() {
		return []
	},
	mutations: {
		show(state, alert) {
			state.push(alert);
			setTimeout(() => {
				state = state.splice(state.indexOf(alert), 1);
			}, 2500)
		},
		hide(state, alert) {
			state.push(alert);
		}
	},
};