<template>
    <div class="col-12 selectable recipeCard p-2 text-white">
        <div class="blurFilter rounded-pill text-start p-1">
            <p>{{ recipe.category }}</p>
        </div>
        <div class="blurFilter text-center mx-4 rounded-pill">
            <p class="fw-bold my-1">{{ recipe.title }}</p>
        </div>

    </div>
</template>


<script>
import { computed } from 'vue';
import { AppState } from '../AppState';
import { Recipe } from '../models/Recipe';

export default {
    props: {
        recipe: { name: Recipe, required: true }
    },
    setup(props) {
        return {
            coverImg: computed(() => `url(${props.recipe.img})`),

        }
    }
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