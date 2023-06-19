<template>
  <img alt="Vue logo" src="./assets/logo.png">
  <HelloWorld msg="Welcome to Your Vue.js App"/>
  <StandartList/>
  <MaterialList/>
</template>

<script>
import HelloWorld from './components/HelloWorld.vue';
import StandartList from './components/StandartList.vue';
import MaterialList from './components/MaterialList.vue'

export default {
  name: 'App',
  components: {
    HelloWorld, 
    StandartList,
    MaterialList
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
  margin-top: 60px;
}
</style>
