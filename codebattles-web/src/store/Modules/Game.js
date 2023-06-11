import axios from "axios";
import Store from '../index.js';

export default {
	namespaced: true,
	state() {
		return {
			games: {},
			currentGame: {
				id: null,
				steps: [],
				userInBattle: { user: { level: null } },
				opponents: []
			}
		}
	},
	getters: {
		getGames(state) {
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
		retrieveGames({ commit }) {
			axios.get('/Game?gameStatus=1', {
			}).then((response) => {
				response.data.forEach(game => {
					game.userInBattle = game.participants.map((participant) => { return participant.userId }).includes(Store.getters['User/getId']);
				});
				commit('setGames', response.data);
			})
		},
		retrieveFilterGames({ commit }, data) {

			axios.get('/Game', {
				params: {
					gameStatus: data.GameStatus,
					gameModeId: data.Gamemode,
					languageId: data.Language,
				}
			}).then((response) => {
				response.data.forEach(game => {
					game.userInBattle = game.participants.map((participant) => { return participant.userId }).includes(Store.getters['User/getId']);
				});
				commit('setGames', response.data);
			})
		},
		getGame({ commit }, data){
			axios.get('/Game/' + data)
			.then((response) => {
				var data = response.data
				data.userInBattle = data.participants.filter(participant => {
					return participant.userId == Store.getters['User/getId'];
				})[0];
				data.opponents = data.participants.filter(participant => {
					return participant.userId != Store.getters['User/getId'];
				});
				delete data.participants;
				commit('setGame', data);
			})
		},
		addParticipant({ commit }, data) {
			axios.post('/Participant/', {
				gameId: data
			})
		},
		createGame({ commit }, data) {
			axios.post('/Game/', {
				languageId: data.language,
				gameModeId: 1,
				gameStatus: 1
			}).then((response) => {
				commit('setGame', response.data);
			})
		}
	}
};