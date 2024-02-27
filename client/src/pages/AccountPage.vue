<template>
  <div class="about text-center">
    <h3>Welcome {{ account.name }}</h3>
  </div>
  <div class="row justify-content-center mt-4">
    <div class="col-lg-5 col-10 text-center d-flex flex-column align-items-center">
      <img class="rounded-circle mb-2" :src="account.picture" alt="" />
      <h4>Account Details</h4>
      <form class="w-50">
        <span class="d-flex flex-column justify-content-center">
          <h5 class="me-3">Name:</h5>
          <input v-model="accountData.name" class="form-control" type="text">
        </span>
        <span class="d-flex flex-column">
          <h5 class="me-3">Email:</h5>
          <input v-model="accountData.email" class="form-control" type="text">
        </span>
        <span class="d-flex flex-column">
          <h5 class="me-3">Picture URL:</h5>
          <input v-model="accountData.picture" class="form-control" type="url">
        </span>
        <button class="mt-3 btn btn-outline-dark">Save</button>
      </form>
    </div>
  </div>
</template>

<script>
import { computed, ref } from 'vue';
import { AppState } from '../AppState';
export default {
  setup() {
    let accountData = ref({})
    return {
      accountData,
      account: computed(() => AppState.account)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
