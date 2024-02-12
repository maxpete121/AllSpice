<template>
    <div class="ingredient-card mt-3 p-2 d-flex justify-content-between">
        <div>
            <h5>{{ ingredient.name }}</h5>
            <span class="d-flex">
                <h6 class="me-2">Amount:</h6>
                <h6>{{ ingredient.quantity }}</h6>
            </span>
        </div>
        <div>
            <button v-if="activeRecipe.creatorId == account.id" class="btn btn-outline-danger"><i class="mdi mdi-delete"></i></button>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { Ingredients } from '../models/Ingredients.js';
export default {
    props: {ingredient: {type: Ingredients, required: true}},
    setup(){
    return { 
        account: computed(()=> AppState.account),
        activeRecipe: computed(()=> AppState.activeRecipe)
     }
    }
};
</script>


<style lang="scss" scoped>
.ingredient-card{
    background-color: rgb(243, 243, 243);
    box-shadow: -3px 6px 6px rgba(0, 0, 0, 0.427);
}
</style>