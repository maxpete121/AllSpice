<template>
    <div class="ingredient-card mt-3 p-2">
        <h5>{{ ingredient.name }}</h5>
        <h6>{{ ingredient.quantity }}</h6>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { Ingredients } from '../models/Ingredients.js';
export default {
    props: {ingredient: {type: Ingredients, required: true}},
    setup(){
    return {  }
    }
};
</script>


<style lang="scss" scoped>
.ingredient-card{
    background-color: rgb(243, 243, 243);
    box-shadow: -3px 6px 6px rgba(0, 0, 0, 0.427);
}
</style>