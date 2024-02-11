import { AppState } from "../AppState"
import { Favorites } from "../models/Favorites"
import { Recipes } from "../models/Recipes"
import { api } from "./AxiosService"


class FavoriteService{
    async postNewFavorite(newFavoriteData){
        let response = await api.post('api/favorites', newFavoriteData)
    }

    async getFavorites(){
        let response = await api.get('account/favorites')
        let allFavorites = await response.data.map(favorite => new Recipes(favorite))
        AppState.recipes = allFavorites
        console.log(allFavorites)
    }
}

export const favoriteService = new FavoriteService()