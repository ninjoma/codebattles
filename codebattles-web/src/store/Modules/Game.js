import axios from "axios";
import Store from '../index.js';

export default {
	namespaced: true,
	state() {
		return {
			games: {},
			currentGame: {}
		}
	},
	getters: {
		getGames(state){
			return state.games;
		}
	},
	mutations: {
		setGames(state, games) {
			state.games = games;
		},
		setGame(state, game) {
			state.currentGame = game;
		}
	},
	actions: {
		retrieveGames({ commit }){
			axios.get('/api/Game?gameStatus=1', {
			}).then((response) => {
				response.data.forEach(game => {
					game.userInBattle = game.participants.map((participant) => { return participant.userId }).includes(Store.getters['User/getId']);
				});
				commit('setGames', response.data);
			})
		},
		getGame({ commit }, data){
			axios.get('/api/Game/' + data)
			.then((response) => {
				console.log(response.data);
				commit('setGame', response.data);
			})
		},
		addParticipant({ commit }, data) {
			axios.post('/api/Participant/', {
				gameId: data.game
			})
		},
		createGame({ commit }, data) {
			axios.post('/api/Game/', {
				languageId: data.language,
				gameModeId: 1,
				gameStatus: 1
			}).then((response) => {
				commit('setGame', response.data);
			})
		}
	}
};