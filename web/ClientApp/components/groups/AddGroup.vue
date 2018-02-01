<template>
  <button v-if="!isAdding" @click="newGroup" class="btn-floating btn-small waves-effect waves-light blue">
    <i class="material-icons">add</i>
  </button>
  <form novalidate class="col s5" v-else @submit.prevent="save">
    <div class="row">
      <div class="input-field">
        <input v-validate="'required'" v-model="groupName" id="groupName" type="text" class="validate">
        <label for="groupName">Name</label>
      </div>
    </div>
    <div class="row">
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

export default {
  name: 'AddGroup',
  data() {
    return {
      isAdding: false,
      groupName: ''
    };
  },
  methods: {
    ...mapActions('groups', ['addGroup']),
    newGroup() {
      this.isAdding = true;
    },
    cancelEdit() {
      this.isAdding = false;
      this.groupName = '';
    },
    save() {
      this.$validator.validateAll().then((result) => {
        if (result) {
          this.addGroup(this.groupName);
          this.cancelEdit();
        }
      });      
    }
  }
}
</script>

