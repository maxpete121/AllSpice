<template>
  <nav class="navbar-dark px-3">
    <!-- <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button> -->
    <div class="d-flex justify-content-evenly align-items-center" id="navbarText">
      <div class="d-flex justify-content-start w-25">
        <ul class="navbar-nav me-auto">
          <li>
            <router-link :to="{ name: 'Home' }">
              <i class="mdi mdi-home fs-1 text-success"></i>
            </router-link>
          </li>
        </ul>
      </div>
      <div class="w-50 d-flex justify-content-center">
        <SearchBar/>
      </div>
      <div class="d-flex justify-content-end w-25">
        <Login />
      </div>
    </div>
  </nav>
</template>

<script>
import { onMounted, ref } from 'vue';
import { loadState, saveState } from '../utils/Store.js';
import Login from './Login.vue';
import SearchBar from './SearchBar.vue';
export default {
  setup() {

    const theme = ref(loadState('theme') || 'light')

    onMounted(() => {
      document.documentElement.setAttribute('data-bs-theme', theme.value)
    })

    return {
      theme,
      toggleTheme() {
        theme.value = theme.value == 'light' ? 'dark' : 'light'
        document.documentElement.setAttribute('data-bs-theme', theme.value)
        saveState('theme', theme.value)
      }
    }
  },
  components: { Login, SearchBar }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 576px) {
  nav {
    height: 64px;
  }
}
</style>
