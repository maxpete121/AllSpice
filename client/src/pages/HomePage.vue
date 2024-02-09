<template>
  <section class="container-fluid">
    <section class="row justify-content-center">
      <div class="col-10 d-flex main-card flex-column align-items-center p-4">
        <div class="main-child text-center w-25 p-2">
          <h3>All Spice</h3>
          <h5>Cherish your family</h5>
          <h5>and their cooking!</h5>
        </div>
      </div>
    </section>
    <section class="row justify-content-center">
      <div class="col-3 d-flex select-bar p-2 justify-content-center mt-3">
        <div class="d-flex">
          <button class="btn btn-outline-dark">Home</button>
          <button class="ms-lg-3 me-lg-3 btn btn-outline-dark">My Recipes</button>
          <button class="btn btn-outline-dark">Favorite</button>
        </div>
      </div>
    </section>
    <section class="row mt-4 justify-content-center">
      <div class="col-3 mt-4 ms-1 me-1" v-for="recipe in recipes">
        <RecipeCard :recipe="recipe"/>
      </div>
    </section>
    <div class="sticky-bottom row justify-content-end">
      <div class="col-2 d-flex">
          <CreateCard/>
      </div>
    </div>
  </section>
</template>

<script>
import { computed, onMounted } from 'vue';
import { recipeService } from '../services/RecipeService';
import {AppState} from '../AppState'
import RecipeCard from '../components/RecipeCard.vue';
import CreateCard from '../components/CreateCard.vue';
export default {
  setup() {
    onMounted(()=>{
      getRecipes()
    })

    async function getRecipes(){
      await recipeService.getRecipes()
    }
    return {
      recipes: computed(()=> AppState.recipes)
    }
  }, components: {RecipeCard, CreateCard}
}
</script>

<style scoped lang="scss">

.main-card{
  background-image: url(https://food.unl.edu/newsletters/images/food-groups.png);
  background-position: center;
  background-size: cover;
  border-radius: 5px;
  box-shadow: 3px 7px 7px rgba(0, 0, 0, 0.641);
}

.main-child{
  background-color: rgba(255, 255, 255, 0.792);
  border-radius: 20px;
}

.select-bar{
  background-color: rgb(225, 225, 225);
  border-radius: 15px;
  outline: solid 1px black;
  box-shadow: 2px 5px 5px rgba(0, 0, 0, 0.633);
}
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: clamp(500px, 50vw, 100%);

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
