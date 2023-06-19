<template>
    <div>
      <h1>{{ materials }}</h1>

    <input  v-model="material.Name"/>
    <button @click="postMaterial">postMat</button>
    </div>
</template>

<script>
  import axios from 'axios';
  const url = "https://localhost:7202/api/material"

export default {
  name: 'MaterialList',

  data(){
      return{
          materials : [],
          material : {
            Name : " ",
            Price : 3.2,
            Amount : 2,
            ElementCode: "m",
            WorkCode : "fff",
            StandartCode : "ujhf",
            Unit : "bghbg"
          }
      }
  },
  methods: {
    getMaterials(){
      axios.get(url)
      .then(res => this.materials = res.data)
          .catch(error => {
              console.error('Error fetching standarts:', error);
          });
    },
    postMaterial(){
      axios.post(url, this.material)
            .then(res => 
             console.log(res.data))
            .catch((error) => {
              console.error(error)
            });
    }
  },
  
  mounted() {
      this.getMaterials();
  }

};
 </script>

 <style scoped>
 
 </style>