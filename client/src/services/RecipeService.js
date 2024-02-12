import { AppState } from "../AppState"
import { Recipes } from "../models/Recipes"
import Pop from "../utils/Pop"
import { api } from "./AxiosService"


class RecipeService{

    async getRecipes(){
        let response = await api.get('api/recipes')
        let allRecipes = await response.data.map(recipe => new Recipes(recipe))
        AppState.recipes = allRecipes
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

    async DeleteRecipe(recipeId){
        let response = await api.delete(`api/recipes/${recipeId}`)
        let recipeIndex = AppState.recipes.findIndex(recipe => recipe.id == recipeId)
        AppState.recipes.splice(recipeIndex, 1)
        let message = response.data
        return message
    }

    async setActiveRecipe(recipeId){
        let response = await api.get(`api/recipes/${recipeId}`)
        let newRecipe = new Recipes(response.data)
        AppState.activeRecipe = newRecipe
        // console.log(newRecipe)
    }

    async editInstructions(instructionData, recipeId){
        let response = await api.put(`api/recipes/${recipeId}`, instructionData)
        let updatedRecipe = new Recipes(response.data)
        AppState.recipes = AppState.recipes.map(recipe => recipe.id !== recipeId ? recipe : updatedRecipe)
    }
}

export const recipeService = new RecipeService()