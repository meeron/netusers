import api from '@/tools/Api'
import { GET_USERS, SAVE_USER, DELETE_USER } from './mutation-types'

const state = {
  users: [],
  fetched: false
}

const actions = {
  getUsers({ commit, state }) {
    !state.fetched && api.getUsers().then(users => {
      commit(GET_USERS, users);
    });
  },

  save({ commit, state }, newUser) {
    const user = {
      ...newUser,
      id: Date.now()
    };

    return api.saveUser(user).then(user => {
      return new Promise(resolve => {
        commit(SAVE_USER, user);
        resolve();
      });
    });
  },

  remove({ commit, state }, id) {
    api.deleteUser(id).then(result => {
      if (result) {
        const index = state.users.findIndex(usr => usr.id === id);
        commit(DELETE_USER, index);
      } else {
        throw new Error(`User ${id} not found.`);
      }
    });
  }
}

const mutations = {
  [GET_USERS](state, users) {
    state.users = users;
    state.fetched = true;
  },

  [SAVE_USER](state, user) {
    state.users.push(user);
  },

  [DELETE_USER](state, index) {
    state.users.splice(index, 1);
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions
}
