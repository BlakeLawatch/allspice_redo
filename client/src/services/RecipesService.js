import { AppState } from "../AppState"
import { Recipe } from "../models/Recipe"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class RecipesService {


    async getRecipes() {
        const res = await api.get(`api/recipes`)
        AppState.recipes = res.data.map(pojo => new Recipe(pojo))
        // logger.log('got recipes FINISH IN THE SERVICE', AppState.recipes)
    }

    setActiveRecipe(recipe) {
        AppState.activeRecipe = recipe
    }
}

export const recipesService = new RecipesService()