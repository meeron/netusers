<template>
  <div class="preloader-template-wrapper" v-if="isLoading">
    <div v-if="type === 'linear'" class="progress">
      <div class="indeterminate"></div>
    </div>
    <div v-if="type === 'circle'" class="preloader-wrapper small active">
      <div class="spinner-layer spinner-green-only">
        <div class="circle-clipper left">
          <div class="circle"></div>
        </div><div class="gap-patch">
          <div class="circle"></div>
        </div><div class="circle-clipper right">
          <div class="circle"></div>
        </div>
      </div>
    </div>     
  </div>
</template>

<script>
export default {
  props: {
    isLoading: Boolean,
    type: {
      type: String,
      default: 'circle'
    }
  }
}
</script>

