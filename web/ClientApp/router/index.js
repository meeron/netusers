import Vue from 'vue'
import Router from 'vue-router'

import Users from '@/pages/Users'
import Groups from '@/pages/Groups'

Vue.use(Router)

export default new Router({
  routes: [
    { path: '/', name: 'Users', component: Users },
    { path: '/groups', name: 'Groups', component: Groups }
  ]
})
