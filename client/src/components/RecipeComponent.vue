<template>
    <div v-if="recipe" @click="setActiveRecipe()" class="col-12 selectable recipeCard p-2 text-white">
        <div class="col-4  blurFilter rounded-pill text-center p-2">
            <p class="mb-0">{{ recipe.category }}</p>
        </div>
        <div class="blurFilter text-center mx-4 rounded-pill">
            <p class="fw-bold my-4 p-2">{{ recipe.title }}</p>
        </div>

    </div>
    <ActiveRecipeCard />
</template>


<script>
import { computed } from 'vue';
import { Recipe } from '../models/Recipe';
import { recipesService } from '../services/RecipesService.js'
import { Modal } from 'bootstrap';
import ActiveRecipeCard from './ActiveRecipeCard.vue';

export default {
    props: {
        recipe: { name: Recipe, required: true }
    },
    setup(props) {
        return {
            coverImg: computed(() => `url(${props.recipe.img})`),
            setActiveRecipe() {
                recipesService.setActiveRecipe(props.recipe);
                Modal.getOrCreateInstance('#activeRecipe').show();
            }
        };
    },
    components: { ActiveRecipeCard }
};
</script>


<style lang="scss" scoped>
.recipeCard {
    background-image: v-bind(coverImg);
    background-position: center;
    background-size: cover;
    height: 20dvh;
}

.blurFilter {
    backdrop-filter: blur(15px);
}
</style>