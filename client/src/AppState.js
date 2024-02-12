import { reactive } from 'vue'
import { Recipes } from './models/Recipes.js'
import { Favorites } from './models/Favorites.js'
import { Ingredients } from './models/Ingredients.js'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},

  /**@type {Recipes[]} */
  recipes: [],
/**@type {Favorites[]} */
  favoriteRecipes: [],
/**@type {Recipes} */
  activeRecipe: {},
/**@type {Ingredients[]} */
  ingredients: []
})
