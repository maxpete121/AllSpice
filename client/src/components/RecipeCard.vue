<template>
  <div :style="bgPic" class="recipe-card-home d-flex flex-column justify-content-between" :title="recipe.title">
    <div class="mt-1 ms-1">
      <button @click="setActiveRecipe(), getIngredients()" type="button" data-bs-toggle="modal" :data-bs-target="target" class="btn btn-success">See recipe...</button>
    </div>
    <div class="text-dark recipe-card-child p-2 d-flex justify-content-between">
      <div class="">
        <h5>{{ recipe.title }}</h5>
        <h6>{{ recipe.category }}</h6>
      </div>
      <div class="">
        <button v-if="recipe.favoriteId > 0" @click="removeFavorite()" class="btn btn-secondary me-2">Remove</button>
        <button v-if="recipe.creatorId == account.id && account" @click="DeleteRecipe()" class="btn btn-danger"><i class="mdi mdi-delete"></i></button>
      </div>
    </div>
  </div>
  <!-- Button trigger modal -->
  <!-- Modal -->
  <div class="modal fade" :id="catchModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-xl">
      <div class="modal-content">
        <div class="modal-header">
          <h1 class="modal-title fs-5" id="exampleModalLabel">{{ recipe.title }}</h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <div class="d-flex">
            <div class="w-50 text-center">
              <img class="img-fluid img-resize" :src="recipe.img" alt="image of food.">
            </div>
            <div class="w-50 text-center d-flex flex-column justify-content-between p-2 recipe-info">
              <div>
                <h4 class="text-success fst-italic">Instructions</h4>
                <h6 class="ms-3">{{ recipe.instructions }}</h6>
              </div>
              <form v-if="recipe.creatorId == account.id" class="d-flex flex-column mt-3 ps-4 pe-4">
                <label for="">Edit Instructions</label>
                <textarea name="" id="" cols="25" rows="3"></textarea>
                <div class="mt-2">
                  <button class="btn btn-outline-success">Change</button>
                </div>
              </form>
            </div>
          </div>
          <div class="d-flex mt-3 justify-content-center">
            <div v-if="recipe.creatorId == account.id" class="w-50 text-center">
              <div class="d-flex justify-content-center mt-2">
                <h3 class="text-success fst-italic">Add New Ingredient</h3>
              </div>
              <div id="ingredient-form" class="d-flex justify-content-center">
                <form @submit.prevent="postIngredient()" class="mt-1 w-75">
                  <label for="">Name</label>
                  <input v-model="ingredientData.name" required maxlength="50" type="text" class="form-control">
                  <label for="">How much?</label>
                  <input v-model="ingredientData.quantity" required maxlength="50" type="text" class="form-control">
                  <button class="btn btn-outline-success mt-2">Add</button>
                  <button type="button" class="btn btn-outline-success mt-2 ms-2">Close</button>
                </form>
              </div>
              <div></div>
            </div>
            <div class="w-50 recipe-info pb-4 pt-2 ps-3 pe-3">
              <div class="text-center">
                <h3 class="text-success fst-italic">Ingredients</h3>
              </div>
              <div v-for="ingredient in ingredients">
                <IngredientCard :ingredient="ingredient"/>
              </div>
            </div>
          </div>
        </div>
        <div class="modal-footer">
          <button v-if="recipe.favoriteId == 0" @click="postNewFavorite()" type="button" class="btn btn-secondary">Favorite⭐</button>
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { Recipes } from '../models/Recipes.js';
import { recipeService } from '../services/RecipeService.js'
import Pop from '../utils/Pop';
import { favoriteService } from '../services/FavoriteService.js';
import { ingredientsService } from '../services/IngredientsService.js';
import IngredientCard from './IngredientCard.vue';

export default {
  props: { recipe: { type: Recipes, required: true } },
  setup(props) {
    let ingredientData = ref({})
    async function DeleteRecipe() {
      if (window.confirm(`Would you like to delete ${props.recipe.title}`)) {
        let message = await recipeService.DeleteRecipe(props.recipe.id)
        Pop.success(`${message}`)
      }

    }
    async function postNewFavorite() {
      let newFavoriteData = {"RecipeId": props.recipe.id}
      let addedFavorite = await favoriteService.postNewFavorite(newFavoriteData)
      Pop.success(`Success adding ${addedFavorite.title} to favorites`)
    }

    async function removeFavorite(){
      if (window.confirm(`Would you like to remove ${props.recipe.title} from your favorites?`)) {
        let removedFavorite = await favoriteService.removeFavorite(props.recipe.favoriteId)
      }
    }
    async function postIngredient(){
      ingredientData.value.recipeId = props.recipe.id
      await ingredientsService.postIngredient(ingredientData.value)
      ingredientData.value = {}
    }

    async function getIngredients(){
      await ingredientsService.getIngredients(props.recipe.id)
    }

    async function setActiveRecipe(){
      await recipeService.setActiveRecipe(props.recipe.id)
    }
    return {
      DeleteRecipe,
      postNewFavorite,
      removeFavorite,
      postIngredient,
      getIngredients,
      setActiveRecipe,
      account: computed(() => AppState.account),
      ingredients: computed(()=> AppState.ingredients),
      ingredientData,
      bgPic: computed(() => {
        let string = `background-image: url(${props.recipe.img}); background-size: cover; background-position: center;`
        return string
      }),
      target: computed(() => {
        let addId = props.recipe.id
        let startId = '#modal'
        let newId = startId + addId
        return newId
      }),
      catchModal: computed(() => {
        let catchId = 'modal'
        let startId = props.recipe.id
        let newId = catchId + startId
        return newId
      })
    }
  },
   components: { IngredientCard }
};
</script>


<style lang="scss" scoped>
.recipe-card-home {
  // outline: solid 1px black;
  height: 280px;
  background-position: center;
  background-size: cover;
  border-radius: 5px;
  box-shadow: 3px 6px 6px rgba(0, 0, 0, 0.422);
  overflow: hidden;
}

.recipe-card-home:hover {
  // outline: solid 1px black;
  height: 280px;
  background-position: center;
  background-size: cover;
  transform: scale(1.02);
  overflow: hidden;
  border-radius: 5px;
}

.recipe-card-child {
  backdrop-filter: blur(11px);
  background-color: rgba(255, 255, 255, 0.378);
}

.recipe-info{
  background-color: whitesmoke;
  outline: solid 1px #0cbc87;
  border-radius: 5px;
  box-shadow: -4px 6px 6px rgba(0, 0, 0, 0.529);
}

.img-resize {
  height: 270px;
  box-shadow: -4px 4px 5px rgba(0, 0, 0, 0.577);
}
</style>