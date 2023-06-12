<template>
    <Bar
      id="chart-test"
      :options="chartOptions"
      :data="chartData"
    />
  </template>
  
<script lang="ts">
import { Bar } from 'vue-chartjs'
import axios from 'axios'
import { Chart as ChartJS, Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale } from 'chart.js'
export default {
    name: 'BarChart',
    components: { Bar },
    data() {
        return {
            chartData: {
                labels: [ axios.get("/Rankings").then((response) => { return response.data.map((user) => { user.username }); }) ],
                datasets: [ { data: axios.get("/Rankings").then((response) => { return response.data.map((user) => {user.battlesWon }); }) } ]
            },
            chartOptions: {
                responsive: true
            }
        }
    },
    mounted() {
        
    },
    
}
ChartJS.register(Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale)
</script>