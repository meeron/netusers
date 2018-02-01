<template>
    <table>
      <thead>
        <tr>
          <th>Name</th>
          <th>Users count</th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="group in groups" :key="group.id">
          <td>{{group.name}}</td>
          <td>{{group.usersCount}}</td>
          <td>
            <Preloader :isLoading="group.deleting" />
            <button v-if="!group.deleting" @click="deleteUser(group)" class="btn-floating btn-small waves-effect waves-light red">
              <i class="material-icons">remove</i>
            </button>
          </td>
        </tr>
      </tbody>
    </table>
</template>

<script>
import { mapState, mapActions } from 'vuex'
import Preloader from '@/components/Preloader'

export default {
  name: 'GroupsList',
  computed: {
    ...mapState('groups', {
      groups: state => state.groups
    })
  },
  methods: {
    ...mapActions('groups', ['remove']),
    deleteUser(group) {
      if (confirm(`Are you sure you want to delete groups '${group.name}'?`)) {
        this.remove(group.id);
      }
    }
  },
  components: { Preloader }
}
</script>

