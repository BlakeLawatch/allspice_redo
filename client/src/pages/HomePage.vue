<template>
  <div class="container-fluid">
    <section class="row justify-content-around">
      <div v-for="recipe in recipes" :key="recipe.id" class="col-12 col-md-4 my-3">
        <RecipeComponent :recipe="recipe" />
      </div>
    </section>
  </div>
</template>

<script>

import { computed, onMounted } from 'vue'
import { recipesService } from '../services/RecipesService'
import Pop from '../utils/Pop'
import { AppState } from '../AppState.js'
import RecipeComponent from '../components/RecipeComponent.vue'

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
  components: { RecipeComponent }
}
</script>

<style scoped lang="scss"></style>
