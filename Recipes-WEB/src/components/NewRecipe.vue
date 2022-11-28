<template>
  <div class="container">
    <form @submit.prevent="addRecipe">

      <div class="mb-3">
        <input type="text" class="form-control" id="exampleFormControlInput1"
          placeholder="Enter your name of your recipe" v-model="recipe.name">
      </div>

      <div class="mb-3">
        <input class="form-control" type="file" id="formFile">
      </div>
      <div class="mb-3">
        <div class="input-group">
          <span class="input-group-text">Description</span>
          <textarea class="form-control" aria-label="With textarea" v-model="recipe.steps" rows="10"></textarea>
        </div>
      </div>
      <div class="mb-3">

        <div class="input-group">
          <span class="input-group-text">Ingredients</span>
          <textarea class="form-control" aria-label="With textarea" v-model="recipe.ingredients" rows="10"></textarea>
        </div>
      </div>
      <div class="mb-3">
        <div class="input-group">
          <span class="input-group-text">Methods</span>
          <textarea class="form-control" aria-label="With textarea" v-model="recipe.steps" rows="10"></textarea>
        </div>
      </div>
      <button type="button" class="btn btn-success" v-on:click="addRecipe()">Save</button>
    </form>
    <div v-for="(r, index) of recipes" :key="r.id">
      <div class="row">
        <h1>{{ r.name }}</h1>
        <h2>Ingredients</h2>
        <hr>
        <div class="content">{{ r.ingredients }}</div>
        <h2>Method</h2>
        <hr>
        <div class="content">{{ r.steps }}</div>
        <button type="button" class="btn btn-danger mb-3" @click="deleteRecipe(index)">delete</button>
      </div>
    </div>
  </div>
</template>
  
<script>
 // import axios from "axios";
import { v4 as uuidv4 } from "uuid";

export default {
  name: "NewRecipe",
  data() {
    return {
      recipe: {
        name: "",
        ingredients: "",
        steps: "",
      },
      recipes: [],
    };
  },
  computed: {
    formValid() {
      const { name, ingredients, steps } = this.recipe;
      return name && ingredients && steps;
    },
  },
  methods: {
    addRecipe() {
      if (!this.formValid) {
        return;
      }
      this.recipes.push({
        id: uuidv4(),
        ...this.recipe,
      });
    },
    deleteRecipe(index) {
      this.recipes.splice(index, 1);
    },
  },
};
</script>
  
<style scoped>
.content {
  white-space: pre-wrap;
}
</style>