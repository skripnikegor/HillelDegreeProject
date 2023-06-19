    <template>
      <div>
        <h1>{{ standarts }}</h1>

      <input  v-model="standart.Name"/>
      <button @click="postStandart">post</button>
      </div>
    </template>
  
  <script>
    import axios from 'axios';
    const url = "https://localhost:7202/api/standart"

  export default {
    name: 'StandartList',

    data(){
        return{
            standarts : [],
            standart : {
              Id : 0,
              Name : " ",
              CodeResourse : "3",
              NameResourse : "3",
              Unit : "m",
              UnitAmount : 1,
              LaborCostHour : 2,
              LaborCostMachine : 2
            },

        }
    },
    methods: {
      getStandarts(){
        axios.get(url)
        .then(res => this.standarts = res.data)
            .catch(error => {
                console.error('Error fetching standarts:', error);
            });
      },
      postStandart(){
        axios.post(url, this.standart)
              .then(res => 
               console.log(res.data))
              .catch((error) => {
                console.error(error)
              });
      }
    },
    
    mounted() {
        this.getStandarts();
    }

  };
   </script>

   <style scoped>
   
   </style>
  
  
  