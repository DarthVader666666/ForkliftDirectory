<template>
    <div className="malfunction-container">
        <label>Простои по погрузчику</label><span>{{ this.forkliftNumber }}</span>     
        <ButtonsBar
            :add="showAddModal"
            :modify="showModifyModal"
            :cancel="closeModal"
            :open="openDeleteModal"
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
        :show="showAdd"
        :closeModal="closeModal"
        :malfunction="newMalfunction"
        :addMalfunction="addMalfunction"
    ></AddMalfunctionModal>
    <ModifyMalfunctionModal 
        :show="showModify"
        :closeModal="closeModal"
        :malfunction="selectedMalfunction"
        :modifyMalfunction="modifyMalfunction"
    ></ModifyMalfunctionModal>
    <DeleteMalfunctionModal
        :show="showDelete"
        :closeModal="closeDeleteModal"
        :deleteMalfunction="deleteMalfunction"
    ></DeleteMalfunctionModal>
</template>

<script>
import ButtonsBar from './buttons-bar.vue'
import AddMalfunctionModal from './add-malfunction-modal.vue'
import ModifyMalfunctionModal from './modify-malfunction-modal.vue'
import DeleteMalfunctionModal from './delete-malfunction-modal.vue'

export default {
    components: {
        ButtonsBar,
        AddMalfunctionModal,
        ModifyMalfunctionModal,
        DeleteMalfunctionModal
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
            selectedMalfunction:  {
                malfunctionId:null,
                forkliftId:null,
                startTime:null,
                endTime:null,
                describtion:null,
            },
            newMalfunction: {
                forkliftId:null,
                startTime:null,
                endTime:null,
                describtion:null,
            },
            showAdd:false,
            showModify:false,
            showDelete:false
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

        async showAddModal() {
            this.showAdd = true;

            this.newMalfunction.startTime = await fetch(`${this.url}/malfunctions/gettime`,
                {
                    method: 'GET'
                }).then(response => response.json()).then(data => data.startTime);
        },

        async showModifyModal() {
            if(this.selectedMalfunction.malfunctionId) {
                this.showModify = true;
            }
        },

        closeModal() {
            this.showAdd = false;
            this.showModify = false;
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

            this.closeModal();
            window.location.reload();
        },

        async modifyMalfunction(startTime, endTime, describtion) {
            this.selectedMalfunction.forkliftId = this.forkliftId;

            if(startTime) {
                this.selectedMalfunction.startTime = startTime;
            }

            this.selectedMalfunction.endTime = endTime;
            this.selectedMalfunction.describtion = describtion;

            await fetch(`${this.url}/malfunctions/update`,
                {
                    method: 'PUT',
                    body: JSON.stringify(this.selectedMalfunction),
                    headers: {
                        'Content-Type' : 'application/json'
                    }
                }
            )

            this.closeModal();
            window.location.reload();
        },

        async deleteMalfunction() {
            await fetch(`${this.url}/malfunctions/delete/${this.selectedMalfunction.malfunctionId}`,
                {
                    method: 'DELETE'
                }
            );

            this.closeModal();
            window.location.reload();
        },

        openDeleteModal() {
            if(this.selectedMalfunction.malfunctionId) {
                this.showDelete = true;
            }            
        },

        closeDeleteModal() {
            this.showDelete = false;
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