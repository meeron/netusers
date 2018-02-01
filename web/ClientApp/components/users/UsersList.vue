<template>
  <table>
    <thead>
      <tr>
        <th>Name</th>
        <th>Email</th>
        <th></th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="user in users" :key="user.id">
        <td>{{user.name}}</td>
        <td>{{user.email}}</td>
        <td>
          <button @click="deleteUser(user)" class="btn-floating btn-small waves-effect waves-light red">
            <i class="material-icons">remove</i>
          </button>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script>
import { mapState, mapActions } from 'vuex'

export default {
  name: 'UsersList',
  computed: {
    ...mapState('users', {
      users: state => state.users
    })
  },
  methods: {
    ...mapActions('users', ['remove']),
    deleteUser(user) {
      if (confirm(`Are you sure you want to delete user '${user.name}'`)) {
        this.remove(user.id);
      }
    }    
  }
}
</script>

