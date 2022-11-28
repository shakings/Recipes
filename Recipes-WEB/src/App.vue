<template> 
  <UserLogin />
  <RecipesLayout/>
  <NewRecipe />
</template>

<script>
import UserLogin from './components/UserLogin.vue'
import RecipesLayout from './components/RecipesLayout.vue'
import NewRecipe from './components/NewRecipe.vue'

export default {
  name: 'App',
  components: {
      UserLogin,
      RecipesLayout,
      NewRecipe
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

body {
    background: #fffefe;
    font-family: 'Roboto', sans-serif;
}

</style>
