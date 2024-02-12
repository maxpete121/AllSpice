<template>
  <section class="container-fluid">
    <section class="row justify-content-center">
      <div class="col-lg-10 col-12 d-flex main-card flex-column align-items-center p-4">
        <div class="main-child text-center w-50 p-2">
          <h3>All Spice</h3>
          <h5>Cherish your family</h5>
          <h5>and their cooking!</h5>
        </div>
      </div>
    </section>
    <section class="row justify-content-center">
      <div class="col-lg-3 col-10 d-flex select-bar p-2 justify-content-center mt-3">
        <div class="d-flex">
          <button @click="getRecipes()" class="btn btn-success">Home</button>
          <button @click="getMyRecipes()" class="ms-3 me-3 btn btn-success">My Recipes</button>
          <button @click="getFavorites()" class="btn btn-success">Favorite</button>
        </div>
      </div>
    </section>
    <section class="row mt-4 justify-content-center">
      <div class="col-lg-3 col-10 mt-4 ms-1 me-1" v-for="recipe in recipes">
        <RecipeCard :recipe="recipe"/>
      </div>
    </section>
          <CreateCard/>
  </section>
</template>

<script>
import { computed, onMounted } from 'vue';
import { recipeService } from '../services/RecipeService';
import {AppState} from '../AppState'
import RecipeCard from '../components/RecipeCard.vue';
import CreateCard from '../components/CreateCard.vue';
import { favoriteService } from '../services/FavoriteService';
import {ingredientsService} from '../services/IngredientsService.js'
export default {
  setup() {
    onMounted(()=>{
      getRecipes()
    })

    async function getRecipes(){
      await recipeService.getRecipes()
    }

    async function getMyRecipes(){
      await recipeService.getMyRecipes()
    }

    async function getFavorites(){
      await favoriteService.getFavorites()
    }
    return {
      recipes: computed(()=> AppState.recipes),
      getMyRecipes,
      getRecipes,
      getFavorites
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
  background-color: whitesmoke;
  border-radius: 15px;
  outline: solid 1px black;
  box-shadow: 3px 5px 7px rgba(0, 0, 0, 0.437);
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
