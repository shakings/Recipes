<template>
  <div class="container">
    <form>
      <div class="mb-3">
        <label for="userName" class="form-label">UserName</label>
        <input type="text" class="form-control" id="userName" aria-describedby="emailHelp">      
      </div>
      <div class="mb-3">
        <label for="password" class="form-label">Password</label>
        <input type="password" class="form-control" id="password">
      </div>      
      <button type="submit" class="btn btn-primary" v-on:click="IsUserLoggedOn()">Login</button>
    </form>
  </div>
</template>

<script>

export default {
  name: "UserLogin",
  data() {
    return {
      userSession: {
        sessionId: "",
        userId: "",
        IsAdmin: "",
      },
      recipes: [],
    };
  },
  methods: {
     IsUserLoggedOn(){
         alert('hello...')
     }
  },
};
</script>

<style scoped>
.content {
  white-space: pre-wrap;
}
</style>