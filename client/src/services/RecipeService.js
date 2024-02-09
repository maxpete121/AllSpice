import { AppState } from "../AppState"
import { Recipes } from "../models/Recipes"
import { api } from "./AxiosService"


class RecipeService{

    async getRecipes(){
        let response = await api.get('api/recipes')
        let allRecipes = await response.data.map(recipe => new Recipes(recipe))
        AppState.recipes = allRecipes.reverse()
    }

    async postRecipe(recipeData){
        let response = await api.post('api/recipes', recipeData)
        let newDish = new Recipes(response.data)
        AppState.recipes.unshift(newDish)
    }

    async getMyRecipes(){
        let response = await api.get('account/recipes')
        let myRecipes = await response.data.map(recipe => new Recipes(recipe))
        AppState.recipes = myRecipes.reverse()
    }
}

export const recipeService = new RecipeService()