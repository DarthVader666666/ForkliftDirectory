<template>
    <div className="malfunction-container">
        <label>Простои по погрузчику</label><span>{{ this.forkliftNumber }}</span>     
        <ButtonsBar
            :add="showModal" 
            :cancel="closeModal"
            >
        </ButtonsBar>
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
    <AddMalfunctionModal 
        :show="show"
        :closeModal="closeModal"
        :newMalfunction="newMalfunction"
        :addMalfunction="addMalfunction"
        ></AddMalfunctionModal>
</template>

<script>
import ButtonsBar from './buttons-bar.vue'
import AddMalfunctionModal from './add-malfunction-modal.vue'

export default {
    components: {
        ButtonsBar,
        AddMalfunctionModal
    },

    props: {
        malfunctions: {
            type: Array
        },
        forkliftNumber: {
            type:String
        },
        forkliftId: {
            type:Number
        },
        url: {
            type:String
        }
    },

    data() {
        return {
            selectedMalfunction: null,
            show:false,
            newMalfunction: {
                forkliftId:null,
                startTime:null,
                endTime:null,
                describtion:null,
            },
        }
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

        async showModal() {
            this.show = true;

            this.newMalfunction.startTime = await fetch(`${this.url}/malfunctions/gettime`,
                {
                    method: 'GET'
                }).then(response => response.json()).then(data => data.startTime);
        },

        closeModal() {
            this.show = false;
        },

        async addMalfunction(startTime, endTime, describtion) {
            this.newMalfunction.forkliftId = this.forkliftId;

            if(startTime) {
                this.newMalfunction.startTime = startTime;
            }

            this.newMalfunction.endTime = endTime;
            this.newMalfunction.describtion = describtion;

            await fetch(`${this.url}/malfunctions/insert`,
                {
                    method: 'POST',
                    body: JSON.stringify(this.newMalfunction),
                    headers: {
                        'Content-Type' : 'application/json'
                    }
                }
            )

            window.location.reload();
        }
    }
}
</script>

<style>
    .malfunction-container {
        max-height: 90vh;
        margin-top: 12px;
    }

    .malfunction-container table {
        height: 70%;
        width:100%;
    }

    label {
        font-size: large;
        font-weight: bold;
    }

    .malfunction-container button {
        min-width: 100px;
        height: 28px;
        margin-left: 10px;
        border-radius: 6px;
        border: 1px;
        color: #FFF;
        background-color: rgb(189, 21, 21);
    }

    .malfunction-container span {
        margin-left: 10px;
    }
</style>