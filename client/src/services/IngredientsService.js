import { AppState } from "../AppState"
import { Ingredients } from "../models/Ingredients"
import { api } from "./AxiosService"



class IngredientsService{
    async postIngredient(ingredientData){
        let response = await api.post('api/ingredients', ingredientData)
        let newIngredient = new Ingredients(response.data)
        AppState.ingredients.unshift(newIngredient)
    }

    async getIngredients(recipeId){
        let response = await api.get(`api/recipes/${recipeId}/ingredients`)
        let allIngredients = await response.data.map(ingredient => new Ingredients(ingredient))
        AppState.ingredients = allIngredients
        // console.log(allIngredients)
    }

    async deleteIngredient(ingredientId){
        let response = await api.delete(`api/ingredients/${ingredientId}`)
        let ingredientIndex = AppState.ingredients.findIndex(ingredient => ingredient.id == ingredientId)
        AppState.ingredients.splice(ingredientIndex, 1)
    }
}

export const ingredientsService = new IngredientsService()