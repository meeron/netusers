<template>
  <div>
    <h3>Users</h3>
    <div class="row">
      <AddUser />
    </div>
    <div v-if="!fetched" class="row">
      <Preloader :isLoading="!fetched" type="linear" />
    </div>
    <div v-else class="row">
      <UsersList />
    </div>
  </div>
</template>

<script>
import { mapActions, mapState } from 'vuex'
import AddUser from '@/components/users/AddUser'
import UsersList from '@/components/users/UsersList'
import Preloader from '@/components/Preloader'

export default {
  name: 'Users',
  computed: {
    ...mapState('users', {
      fetched: state => state.fetched
    })
  },
  mounted () {
    this.getUsers();
  },
  methods: {
    ...mapActions('users', ['getUsers'])
  },
  components: { AddUser, UsersList, Preloader }
}
</script>

<style>
</style>
