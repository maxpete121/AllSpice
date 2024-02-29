import { AppState } from "../AppState"
import { Favorites } from "../models/Favorites"
import { Recipes } from "../models/Recipes"
import { api } from "./AxiosService"


class FavoriteService{
    async postNewFavorite(newFavoriteData){
        let response = await api.post('api/favorites', newFavoriteData)
        let recipeAdded = AppState.recipes.find(recipes => recipes.id == newFavoriteData.RecipeId)
        let newFavorite = new Recipes(response.data)
        AppState.favoriteCheck.unshift(newFavorite)
        return recipeAdded
    }

    async getFavorites(){
        let response = await api.get('account/favorites')
        let allFavorites = await response.data.map(favorite => new Recipes(favorite))
        AppState.recipes = allFavorites
    }

    async removeFavorite(favoriteId){
        let response = await api.delete(`api/favorites/${favoriteId}`)
        let favoriteIndex = AppState.recipes.findIndex(recipe => recipe.favoriteId == favoriteId)
        AppState.recipes.splice(favoriteIndex, 1)
        let favoriteCheckIndex = AppState.favoriteCheck.findIndex(favorite => favorite.id == favoriteId)
        AppState.favoriteCheck.splice(favoriteCheckIndex, 1)
    }

    async favoriteCheck(){
        let response = await api.get('account/favorites')
        let allFavorites = await response.data.map(favorite => new Recipes(favorite))
        AppState.favoriteCheck = allFavorites
    }
}

export const favoriteService = new FavoriteService()