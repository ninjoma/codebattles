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
            labels: [ 'January', 'February', 'March' ],
            datasets: [ { data: [40, 20, 12] } ]
            },
            chartOptions: {
            responsive: true
            }
        }
    },
    mounted() {
        axios.get("/Rankings")
            .then((response) => {
                this.chartData.labels = response.data.map((user) => { user.username });
                this.chartData.datasets[0].data = response.data.map((user) => {user.battlesWon });
            })
    },
    
}
ChartJS.register(Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale)
</script>