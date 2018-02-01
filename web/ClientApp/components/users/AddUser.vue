<template>
  <button v-if="!isAdding" @click="newUser" class="btn-floating btn-small waves-effect waves-light blue">
    <i class="material-icons">add</i>
  </button>
  <form novalidate class="col s5" v-else @submit.prevent="saveUser">
    <div class="row">
      <div class="input-field">
        <input v-validate="'required'" v-model="userName" id="userName" type="text" class="validate">
        <label for="userName">Name</label>
      </div>
    </div>
    <div class="row">
      <div class="input-field">
        <input v-validate="'required|email'" v-model="userEmail" id="userEmail" type="email" class="validate">
        <label for="userEmail">Email</label>
      </div>
    </div>
    <Preloader :isLoading="loading" />
    <div class="row" v-show="!loading">
      <input type="reset" value="Cancel" class="btn btn-small" @click="cancelEdit" />
      <button class="btn waves-effect waves-light" type="submit">
        Save
        <i class="material-icons right">send</i>
      </button>
    </div>
  </form>
</template>

<script>
import { mapActions } from 'vuex'
import Preloader from '@/components/Preloader'

export default {
  name: 'AddUser',
  data() {
    return {
      isAdding: false,
      userName: '',
      userEmail: '',
      loading: false
    };
  },
  methods: {
    ...mapActions('users', ['save']),
    newUser() {
      this.isAdding = true;
    },
    cancelEdit() {
       this.userName = '';
       this.userEmail = '';
       this.isAdding = false;     
    },
    saveUser() {
      this.$validator.validateAll().then((result) => {
        if (result) {
          this.loading = true;
          this.save({ name: this.userName, email: this.userEmail})
            .then(() => {
              this.loading = false;
              this.cancelEdit();
            });
        }
      });
    }    
  },
  components: { Preloader }
}
</script>

