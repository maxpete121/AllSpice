import { AppState } from "../AppState"
import { Ingredients } from "../models/Ingredients"
import { api } from "./AxiosService"



class IngredientsService{
    async postIngredient(ingredientData){
        let response = await api.post('api/ingredients', ingredientData)
        console.log(response)
    }

    async getIngredients(recipeId){
        let response = await api.get(`api/recipes/${recipeId}/ingredients`)
        let allIngredients = await response.data.map(ingredient => new Ingredients(ingredient))
        AppState.ingredients = allIngredients
    }
}

export const ingredientsService = new IngredientsService()