<template>
  <div class="container-fluid">
    <section class="row justify-content-around">
      <div v-for="recipe in recipes" :key="recipe.id" class="col-12 col-md-3 my-3">
        <RecipeComponent :recipe="recipe" />
      </div>
    </section>
    <section class="row">
      <button type="button" class="btn btn-outline-success" data-bs-toggle="modal" data-bs-target="#createRecipe"> +
      </button>
    </section>
  </div>
  <CreateRecipeModal />
</template>

<script>

import { computed, onMounted } from 'vue'
import { recipesService } from '../services/RecipesService'
import Pop from '../utils/Pop'
import { AppState } from '../AppState.js'
import RecipeComponent from '../components/RecipeComponent.vue'
import CreateRecipeModal from '../components/CreateRecipeModal.vue'

export default {
  setup() {
    onMounted(() => {
      getRecipes();
    });
    async function getRecipes() {
      try {
        await recipesService.getRecipes();
      }
      catch (error) {
        Pop.error(error);
      }
    }
    return {
      recipes: computed(() => AppState.recipes)
    };
  },
  components: { RecipeComponent, CreateRecipeModal }
}
</script>

<style scoped lang="scss"></style>
