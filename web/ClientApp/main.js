// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import VeeValidate from 'vee-validate';

import App from './App'
import router from './router'
import store from './store'
import validatorConfig from './tools/ValidatorConfig'

Vue.config.productionTip = false

Vue.use(VeeValidate, validatorConfig);

/* eslint-disable no-new */
new Vue({
  el: '#app',
  store,
  router,
  components: { App },
  template: '<App/>'
})
