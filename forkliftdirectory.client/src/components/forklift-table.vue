<template>
    <div className="forklift-container">
        <ButtonsBar 
                :addRow="addRowForklift" 
                :modifyRow="modifySelectedForklift"
                :save="saveForklifts"
                :cancel="cancel"
                :openDeleteModal="openDeleteModal"
                >
        </ButtonsBar>
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
                        @click="selectForkliftRow(forklift)">

                    <td>{{forklift.forkliftId}}</td>

                    <td v-if="forklift.modify">
                        <input v-model="modifiedForklift.model" type="text" placeholder="Марка"/></td>
                    <td v-else>{{forklift.model}}</td>

                    <td v-if="forklift.modify">
                        <input  v-model="modifiedForklift.number" type="text" placeholder="Номер"/></td>
                    <td v-else>{{forklift.number}}</td>

                    <td v-if="forklift.modify">
                        <input v-model="modifiedForklift.active" type="checkbox" :value=value /></td>
                    <td v-else><span v-if="forklift.active">✔️</span><span v-else>❌</span></td>

                    <td>{{ forklift.lastEndTime }}</td>

                    <td v-if="forklift.modify">
                        <select v-model="modifiedForklift.userId">
                            <option v-for="user in users" :key="user.userId" :value="user.userId">
                                {{ user.userName }}
                            </option>
                        </select>
                    </td>
                    <td v-else>{{ forklift.userName }}</td>
                </tr>
                <tr v-if="this.extraRowForForklift">
                    <td></td>
                    <td><input v-model="this.addedForklift.model" type="text" placeholder="Марка"/></td>
                    <td><input v-model="this.addedForklift.number" type="text" placeholder="Номер"/></td>
                    <td><input v-model="this.addedForklift.active" type="checkbox"/></td>
                    <td style="text-align:center">NA</td>
                    <td>
                        <select v-model="this.addedForklift.userId">
                            <option v-for="user in users" :key="user.userId" :value="user.userId">
                                {{ user.userName }}
                            </option>
                        </select>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <DeleteModal 
        :show="shallDelete" 
        :deleteForklift="deleteForklift" 
        :closeDeleteModal="closeDeleteModal"
        >
    </DeleteModal>    
</template>

<script>
import ButtonsBar from './buttons-bar.vue'
import DeleteModal from './delete-modal.vue'
import { watch } from 'vue';

export default {
    async created() {
        this.users = await this.getUsers();
    },
    components: {
        ButtonsBar,
        DeleteModal
    },
    props: {
        setMalfunctions: {
            type:Function
        },
        setForklifts: {
            type:Function
        },
        url: {
            type:String
        },
        malfunctionsForForklift: {
            type:Array
        },
        forklifts: {
            type:Array
        }
    },

    data() {
        return {
            users:[],
            addedForklift: null,
            modifiedForklift: null,
            extraRowForForklift:false,
            selectedForklift: null,
            shallDelete: false,
        }
    },

    setup(props) {
        watch(() => props, () => {

        }
            
        );
        return {};
    },

    methods: {
        addRowForklift() {
            this.addedForklift = {
                userId:null,
                model:null,
                number:null,
                active:false,
                modify:false,
            };

            this.forklifts.forEach(x => x.modify = false);
            this.extraRowForForklift = true;
        },

        modifySelectedForklift() {
            this.extraRowForForklift = false;
            this.modifiedForklift = this.selectedForklift;
            const id = this.modifiedForklift.forkliftId;

            if(id) {
                this.forklifts.forEach(x => {
                    if(Number(x.forkliftId) === Number(id)) {
                        x.modify = true
                    }
                    else {
                        x.modify = false
                    }
                });
            }
        },

        async saveForklifts() {
            console.log(this.modifiedForklift)

            if(this.addedForklift) {
                fetch(`${this.url}/Forklifts/Insert/`,
                    {
                        method: 'POST',
                        body: JSON.stringify(this.addedForklift),
                        headers: {
                            'Content-Type' : 'application/json',
                        }
                    }
                )                
            }

            if(this.modifiedForklift) {
                fetch(`${this.url}/Forklifts/Update/`,
                    {
                        method: 'PUT',
                        body: JSON.stringify(this.modifiedForklift),
                        headers: {
                            'Content-Type' : 'application/json',
                        }
                    }
                )
            }

            this.resetAll();
        },

        getUsers() {
            return fetch(`${this.url}/Users/GetList`,
                {
                    method: 'GET',                
                }
              ).then(response => response.json()).then(data => data)
        },

        selectForkliftRow(forklift) {
            if(this.selectedForklift) {
                const elementId = `${this.selectedForklift.forkliftId} ${this.selectedForklift.number}`;
                document.getElementById(elementId).style.setProperty('background-color', 'white');
            }

            this.selectedForklift = forklift;
            const id = `${this.selectedForklift.forkliftId} ${this.selectedForklift.number}`;
            document.getElementById(id).style.setProperty('background-color', 'lightgray');

            this.setMalfunctions(this.selectedForklift.forkliftId);
        },

        async deleteForklift() {
            if(this.selectedForklift) {
                const hasRelations = this.malfunctionsForForklift.length > 0;

                if(hasRelations) {
                    alert("У погрузчика имеются зарегистрированные простои – удаление запрещено ");
                    this.closeDeleteModal();
                    return;
                }

                fetch(`${this.url}/Forklifts/Delete?forkliftId=` + this.selectedForklift.forkliftId,
                    {
                      method: 'DELETE'
                    });

                this.selectedForklift = null;
                this.closeDeleteModal();

                this.resetAll();
            }
        },

        async resetAll() {
            this.setForklifts();
            // this.extraRowForForklift = false;
            // this.forklifts.forEach(x => x.modify = false); 
            // this.extraRowForForklift = false;       

            // if(this.selectedForklift) {
            //     const id = `${this.selectedForklift.forkliftId} ${this.selectedForklift.number}`;
            //     document.getElementById(id).style.setProperty('background-color', 'white');
            // }

            // this.selectedForklift = null;
            // this.addedForklift = null;

            window.document.location.reload();
        },

        async cancel() {
            this.resetAll();
            this.setForklifts();
        },

        openDeleteModal() {
            this.shallDelete = true;
        },

        closeDeleteModal() {
            this.shallDelete = false;
        }
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
    .forklift-container table {
        width:700px;
    }
</style>