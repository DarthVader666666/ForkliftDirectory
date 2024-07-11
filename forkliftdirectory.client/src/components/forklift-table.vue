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
                <tr v-for="forklift in forklifts" 
                        :key="`${forklift.forkliftId}`" 
                        :id="`${forklift.forkliftId} ${forklift.number}`" 
                        @click="selectRow(forklift)">

                    <td>{{forklift.forkliftId}}</td>

                    <td v-if="forklift.modify">
                        <input type="text" placeholder="Марка"/></td>
                    <td v-else>{{forklift.model}}</td>

                    <td v-if="forklift.modify">
                        <input type="text" placeholder="Номер"/></td>
                    <td v-else>{{forklift.number}}</td>

                    <td v-if="forklift.modify">
                        <input type="checkbox"/></td>
                    <td v-else>{{ forklift.active }}</td>

                    <td>{{ forklift.lastEndTime }}</td>

                    <td v-if="forklift.modify">
                        <input type="text" placeholder="Имя"/></td>
                    <td v-else>{{ forklift.userName }}</td>
                </tr>
                <tr v-if="extraRow">
                    <td></td>
                    <td><input v-model="this.addedForklift.model" type="text" placeholder="Марка"/></td>
                    <td><input v-model="this.addedForklift.number" type="text" placeholder="Номер"/></td>
                    <td><input v-model="this.addedForklift.active" type="checkbox"/></td>
                    <td></td>
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
            addedForklift: {
                forkliftId:null,
                userId:null,
                model:null,
                number:null,
                active:false
            }
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
    .forklift-container input {
        max-width:85px;
    }
</style>