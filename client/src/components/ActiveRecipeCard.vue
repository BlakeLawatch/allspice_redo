<template>
    <div v-if="recipe" class="modal fade" id="activeRecipe" tabindex="-1" aria-labelledby="exampleModalLabel"
        aria-hidden="true">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">




                <div class="modal-body">
                    <section class="row">
                        <div class="col-12 d-flex">
                            <div class="col-4">
                                <img class="img-fluid" :src="recipe.img" alt="">
                            </div>
                            <div class="col-4 p-2">
                                <div>
                                    <h2>{{ recipe.title }}</h2>
                                    <p class="border-style mb-0 fw-bold bg-success text-light fs-3 text-center">Recipe Steps
                                    </p>
                                </div>
                            </div>
                            <div class="col-4">
                            </div>
                            <div class="col-4">

                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { computed } from 'vue';
import { AppState } from '../AppState';

export default {
    setup() {
        return {
            recipe: computed(() => AppState.activeRecipe)
        }
    }
};
</script>


<style lang="scss" scoped>
.border-style {
    border-radius: 10px 10px 0px 0px;
}
</style>