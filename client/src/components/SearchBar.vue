<template>
    <div class="search-box">
        <form @submit.prevent="searchRecipe()" class="d-flex align-items-center">
            <input v-model="searchData" class="search-bar" type="text" maxlength="40" required>
            <button class="search-button">Search</button>
        </form>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import {recipeService} from '../services/RecipeService.js';
export default {
    setup(){
        let searchData = ref('')
        async function searchRecipe(){
            await recipeService.searchRecipe(searchData.value)
        }
    return { 
        searchRecipe,
        searchData,
     }
    }
};
</script>


<style lang="scss" scoped>

.search-bar{
    all: unset;
    border-bottom-left-radius: 15px;
    border-top-left-radius: 15px;
    height: 28px;
    padding: 5px;
    padding-left: 8px;
    background-color: rgb(235, 235, 235);
    outline: solid 1px #0cbc87;
}

.search-bar:focus{
    all: unset;
    border-bottom-left-radius: 12px;
    border-top-left-radius: 12px;
    height: 24px;
    padding: 5px;
    padding-left: 8px;
    background-color: rgb(235, 235, 235);
    outline: dashed 2px #009f6f;
}
.search-button{
    all: unset;
    padding: 5px;
    border-bottom-right-radius: 13px;
    border-top-right-radius: 13px;
    background-color: rgb(235, 235, 235);
    outline: solid 1px #0cbc87;
}

.search-button:hover{
    all: unset;
    padding: 5px;
    border-bottom-right-radius: 13px;
    border-top-right-radius: 13px;
    outline: solid 1px #0cbc87;
    background-color: rgb(230, 230, 230);
    cursor: pointer;
}


</style>