<template>
    <div className="forklift-container">
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
                <tr v-for="(forklift, index) in forklifts" :key="index" :id="`${forklift.forkliftId} ${index}`" 
                @click="selectRow(`${forklift.forkliftId} ${index}`)">
                    <td>{{forklift.forkliftId}}</td>
                    <td>{{forklift.model}}</td>
                    <td>{{forklift.number}}</td>
                    <td>{{ forklift.active }}</td>
                    <td></td>
                    <td>{{ forklift.userName }}</td>
                </tr>
                <tr v-if="extraRow">
                    <td></td>
                    <td><input type="text" placeholder="Марка"/></td>
                    <td><input type="text" placeholder="Номер"/></td>
                    <td><input type="checkbox"/></td>
                    <td><input type="date"/></td>
                    <td><input type="text" placeholder="Имя"/></td>
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
        },
        extraRow: {
            type:Boolean
        },
        selectRow: {
            type:Function
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
    .forklift-container {
        max-height: 90vh;
        margin-top: 12px;
    }
</style>