<template>
    <div class="ingredient-card mt-4 p-2 d-flex justify-content-between">
        <div>
            <h5>{{ ingredient.name }}</h5>
            <span class="d-flex">
                <h6 class="me-2 fst-italic">Amount:</h6>
                <h6>{{ ingredient.quantity }}</h6>
            </span>
        </div>
        <div>
            <button @click="deleteIngredient()" v-if="activeRecipe.creatorId == account.id" class="btn btn-outline-danger rounded-circle"><i class="mdi mdi-delete"></i></button>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { Ingredients } from '../models/Ingredients.js';
import {ingredientsService} from '../services/IngredientsService.js'
import Pop from '../utils/Pop';
export default {
    props: {ingredient: {type: Ingredients, required: true}},
    setup(props){
        async function deleteIngredient(){
            if(window.confirm(`Would you like to remove ${props.ingredient.name} from your ingredients?`)){
                await ingredientsService.deleteIngredient(props.ingredient.id)
                Pop.success(`${props.ingredient.name} removed.`)
            }
        }
    return { 
        account: computed(()=> AppState.account),
        activeRecipe: computed(()=> AppState.activeRecipe),
        deleteIngredient,
     }
    }
};
</script>


<style lang="scss" scoped>
.ingredient-card{
    background-color: rgb(243, 243, 243);
    box-shadow: -3px 6px 6px rgba(0, 0, 0, 0.427);
    border-top: solid 1px rgba(0, 0, 0, 0.575);
    
}
</style>