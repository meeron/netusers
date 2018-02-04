import api from '@/tools/api'
import { ADD_GROUP, GET_GROUPS, DELETE_GROUP, DELETE_GROUP_REQUEST } from './mutation-types'
import { mapGroups, mapGroup } from './mappers'

const state = {
  groups: [],
  fetched: false
}

const actions = {
  addGroup({ commit }, name) {
    api.addGroup({ id: Date.now(), name })
      .then(group => commit(ADD_GROUP, mapGroup(group)));
  },
  
  getGroups({ commit }) {
    api.getGroups()
    .then(groups => commit(GET_GROUPS, mapGroups(groups)));
  },

  remove({ commit, state }, id) {
    const index = state.groups.findIndex(grp => grp.id === id);

    commit(DELETE_GROUP_REQUEST, index);

    api.deleteGroup(id).then(result => {
      if (result) {
        commit(DELETE_GROUP, index);
      } else {
        throw new Error(`Group ${id} not found.`);
      }
    });    
  }
}

const mutations = {
  [ADD_GROUP](state, newGroup) {
    state.groups.push(newGroup);
  },

  [GET_GROUPS](state, groups) {
    state.groups = groups;
    state.fetched = true;
  },

  [DELETE_GROUP_REQUEST](state, index) {
    state.groups[index].deleting = true;
  },

  [DELETE_GROUP](state, index) {
    state.groups.splice(index, 1);
  }
}

export default {
  namespaced: true,
  state,
  actions,
  mutations
}