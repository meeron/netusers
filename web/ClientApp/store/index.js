import Vue from 'vue'
import Vuex from 'vuex'

import users from './users'
import groups from './groups'

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    users,
    groups
  }
});