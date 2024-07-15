<template>
    <div className="idle-container">
        <label>Простои по погрузчику</label><span>{{ this.number }}</span>     
        <ButtonsBar></ButtonsBar>
        <table>
            <thead>
                <th>
                    Код записи
                </th>
                <th>
                    Начало
                </th>
                <th>
                    Окончание
                </th>
                <th>
                    Время простоя
                </th>
                <th>
                    Причина
                </th>
            </thead>
            <tbody>
                <tr v-for="mal in this.malfunctions" 
                :id="`${mal.malfunctionId} ${mal.forkliftId}`" 
                 @click="selectMalfunctionRow(mal)"
                :key="mal.malfunctionId">
                    <td>{{mal.malfunctionId}}</td>
                    <td>{{mal.startTime}}</td>
                    <td>{{mal.endTime}}</td>
                    <td>{{mal.timeSpan}}</td>
                    <td>{{mal.describtion}}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import ButtonsBar from './buttons-bar.vue'
import { watch } from 'vue';

export default {
    components: {
        ButtonsBar
    },

    props: {
        malfunctions: {
            type: Array
        },
        number: {
            type:String
        }
    },

    data() {
        return {
            selectedMalfunction: null,
        }
    },

    setup(props) {
        watch(() => props.malfunctions, (oldValue, newValue) => {
            // if(oldValue != null)
            //     this.selectedMalfunction = null;
        });
        return {};
    },

    methods: {
        selectMalfunctionRow(malfunction) {
            if(this.selectedMalfunction) {
                const elementId = `${this.selectedMalfunction.malfunctionId} ${this.selectedMalfunction.forkliftId}`;
                const element = document.getElementById(elementId);

                if(element) {
                    element.style.setProperty('background-color', 'white');
                }
            }

            this.selectedMalfunction = malfunction;
            const id = `${this.selectedMalfunction.malfunctionId} ${this.selectedMalfunction.forkliftId}`;
            document.getElementById(id).style.setProperty('background-color', 'lightgray');
        },
    }
}
</script>

<style>
    .idle-container {
        max-height: 90vh;
        margin-top: 12px;
    }

    .idle-container table {
        height: 70%;
        width:100%;
    }

    label {
        font-size: large;
        font-weight: bold;
    }

    .idle-container button {
        min-width: 100px;
        height: 28px;
        margin-left: 10px;
        border-radius: 6px;
        border: 1px;
        color: #FFF;
        background-color: rgb(189, 21, 21);
    }

    .idle-container span {
        margin-left: 10px;
    }
</style>