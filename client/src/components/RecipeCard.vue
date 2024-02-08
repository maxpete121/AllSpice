<template>
    <div>
        <div class="text-dark recipe-card-home">
            <h5>{{ recipe.title }}</h5>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { Recipes } from '../models/Recipes';
export default {
    props: {recipe: {type: Recipes, required: true}},
    setup(){
    return {  }
    }
};
</script>


<style lang="scss" scoped>
.recipe-card-home{
    outline: solid 2px black;
}
</style>