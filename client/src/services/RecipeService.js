import { AppState } from "../AppState"
import { Recipes } from "../models/Recipes"
import { api } from "./AxiosService"


class RecipeService{

    async getRecipes(){
        let response = await api.get('api/recipes')
        let allRecipes = await response.data.map(recipe => new Recipes(recipe))
        AppState.recipes = allRecipes
    }
}

export const recipeService = new RecipeService()