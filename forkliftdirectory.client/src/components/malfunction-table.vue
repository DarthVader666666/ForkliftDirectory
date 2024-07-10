<template>
    <div className="malfunction-container">
        <table>
            <thead>
                <th>
                    Код записи
                </th>
                <th>
                    Марка
                </th>
                <th>
                    Номер
                </th>
                <th>
                    Активен
                </th>
                <th>
                    Время и Дата изменения
                </th>
                <th>
                    Пользователь
                </th>
            </thead>
            <tbody>
                <tr v-for="(forklift, index) in initialForklifts" :key="index">
                    <td>{{forklift.forkliftId}}</td>
                    <td>{{forklift.model}}</td>
                    <td>{{forklift.number}}</td>
                    <td>{{ forklift.active }}</td>
                    <td></td>
                    <td>{{ forklift.userName }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script setup>
    import { onMounted } from 'vue';
    import { ref } from 'vue'

    let initialForklifts = ref([]);

    onMounted(async () => {initialForklifts.value = await getForklifts()});

    function getForklifts() {
        return fetch(
            'https://localhost:7139/Forklifts/GetList/',
            {
              method: 'GET',              
              headers: {
                'Content-Type' : 'application/json',
              }
            }
          ).then(response => response.json()).then(data => data);
    }
</script>

<script>

export default {
    data() {
        return {
            forklift: []
        }
    },

    methods: {

  }
}


</script>

<style>
    .malfunction-container {
        max-height: 90vh;
        margin-top: 12px;
    }
</style>