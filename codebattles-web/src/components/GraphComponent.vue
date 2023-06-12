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
                labels: [ '10/06/2023', '11/06/2023', '12/06/2023' ],
                datasets: [ { data: [40, 20, 12] } ]
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