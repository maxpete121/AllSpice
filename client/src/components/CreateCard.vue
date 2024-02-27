<template>
  <div v-if="account.id" class="sticky-bottom sticky-top d-flex justify-content-start me-4 mb-2 w-25">
    <div title="Create new recipe!" type="button" data-bs-toggle="modal" data-bs-target="#modalCreate" class="rounded-circle create-card bg-success p-2 sticky-bottom d-flex justify-content-center align-items-center mb-2 me-4">
        <i class="mdi mdi-plus add-button"></i>
    </div>
  </div>
        <div class="modal fade" id="modalCreate" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header text-center">
            <h1 class="modal-title fs-5" id="exampleModalLabel">Create a new recipe...</h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body d-flex justify-content-center">
            <form @submit.prevent="postRecipe()" class="d-flex flex-column align-items-center">
              <div class="w-75 text-center">
                <label for="">Recipe Title...</label>
                <input v-model="newRecipeData.Title" class="form-control" maxlength="40" type="text" required>
              </div>
              <div class="d-flex mt-2 flex-column align-items-center p-1">
                <div class=" text-center">
                  <label for="">Category...</label>
                  <select v-model="newRecipeData.Category" name="category" id="category-select" class="form-control">
                    <option selected disabled>Select one..</option>
                    <option  value="Cheese">Cheese</option>
                    <option value="Italian">Italian</option>
                    <option value="Soup">Soup</option>
                    <option value="Mexican">Mexican</option>
                    <option value="Specialty Coffee">Specialty Coffee</option>
                  </select>
                </div>
                <div class="text-center d-flex flex-column align-items-center">
                <label for="">Image url of food...</label>
                <input v-model="newRecipeData.Img" class="form-control" type="url" required maxlength="500">
              </div>
              </div>
              <div class="mt-2 d-flex flex-column text-center">
                <label for="">Instructions...</label>
                <textarea v-model="newRecipeData.Instructions" name="" id="" cols="37" rows="4" required></textarea>
              </div>
              <button class="btn btn-secondary mt-2">Create!</button>
            </form>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
          </div>
        </div>
      </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import {recipeService} from '../services/RecipeService.js'
export default {
    setup(){
      let newRecipeData = ref({})
      async function postRecipe(){
        await recipeService.postRecipe(newRecipeData.value)
        newRecipeData.value = {}
      }
    return { 
      newRecipeData,
      postRecipe,
      account: computed(()=> AppState.account),
     }
    }
};
</script>


<style lang="scss" scoped>

@media screen and (min-width: 576px){
  .create-card{
      height: 110px;
      width: 110px;
      outline: solid 1px black;
      box-shadow: 2px 3px 5px rgba(0, 0, 0, 0.523);
  }
  .create-card:hover{
      height: 110px;
      width: 110px;
      outline: solid 1px black;
      box-shadow: 2px 6px 6px rgba(0, 0, 0, 0.523);
      transform: scale(1.03);
      cursor: pointer;
  }
  .add-button{
    font-size: 60px;
    justify-self: center;
    align-self: center;
}
}

@media screen and (max-width: 576px){
  .create-card{
      height: 50px;
      width: 50px;
      outline: solid 1px black;
      
  }
  .add-button{
    font-size: x-large;
}
}
</style>