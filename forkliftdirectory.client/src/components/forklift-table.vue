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
                <tr v-for="(forklift, index) in forklifts" :key="index">
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

<script>
    
export default {
    props: {
        forklifts: {
            type: Array,
            required: true
        }
    },

    data() {
        return {
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