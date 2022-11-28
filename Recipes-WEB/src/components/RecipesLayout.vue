<template>
    <h1>BRAAI RECIPES</h1>
    <div class="switchableLayout">
        <div class="container">
            <!-- top bar -->
            <div class="bar">
                <div class="btnHolder">
                    <button :class="{ barActive: layout === 'list' }" @click="layout = 'list'">
                        <i class="fas fa-list"></i> List of Recipes
                    </button>
                    <button :class="{ barActive: layout === 'grid' }" @click="layout = 'grid'">
                        <i class="fas fa-th"></i> New Recipes
                    </button>
                </div>
            </div>
            <!-- content -->
            <div class="">
                <!-- grid view -->
                <ul v-if="layout === 'grid'" class="grid">
                    
                </ul>
                <!-- list view -->
                <ul v-if="layout === 'list'" class="list">
                    <li v-for="content in contents" :key="content.id">
                        <img :src="content.image" />
                        <div class="listContent">

                            <h2>{{ content.recipeName }}</h2>
                            <h8>Author: {{ content.author }} - </h8>
                            <label>Uploaded Date: {{ content.created }}</label>
                            <hr>
                            <p>{{ content.description }}</p>
                            <hr>
                            <div class="container">
                                <div class="row">
                                    <div class="col-6 col-md-3">
                                        <h2>INGREDIENTS</h2>
                                            <li v-for="ingredient in content.ingredients" :key="ingredient.id">
                                                {{ ingredient.description }}
                                            </li>
                                     </div>
                                </div>
                            </div>
                        </div>
                    </li>
                </ul>    
            </div>
        </div>
    </div>
</template>
    
<script>
import axios from "axios";
export default {
    name: "RecipesLayout",
    data() {
        return {
            layout: "list",
            contents: null,
            isAdmin: 0
        };
    },
    created: function () {
        axios
            .get("https://localhost:44347/api/RecipesContent/GetAll")
            .then((res) => {
                this.contents = res.data;
            });
    },
};
</script>
<style>
.invisible {
    visibility: hidden;
}
</style>