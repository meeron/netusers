<template>
  <div>
    <h3>Groups</h3>
    <div class="row"><AddGroup /></div>
    <div v-if="fetched" class="row"><GroupsList /></div>
    <div v-else class="row"><Preloader :isLoading="!fetched" type="linear" /></div>
  </div>
</template>

<script>
import { mapState, mapActions } from 'vuex'
import AddGroup from '@/components/groups/AddGroup'
import GroupsList from '@/components/groups/GroupsList'
import Preloader from '@/components/Preloader'

export default {
  name: 'Groups',
  mounted () {
    this.getGroups();
  },
  computed: {
    ...mapState('groups', {
      fetched: state => state.fetched
    })
  },
  methods: {
    ...mapActions('groups', ['getGroups'])
  },
  components: { AddGroup, GroupsList, Preloader }
}
</script>

<style>
</style>
