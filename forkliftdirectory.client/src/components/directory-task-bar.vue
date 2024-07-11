<template>
    <div className="container">
        <h3>Справочник погрузчиков</h3>
        <div className="task-bar">
            <label>Номер погрузчика</label>
            <input @input="event => onSearchInput(event.target.value)" type="text"/>
            <button @click="findForkliftsByNumber(this.searchNumber)">🔍 Искать</button>
            <a><span>❌</span>Очистить фильтр</a>
            <button>Изменить</button>
        </div>
        <div className="task-bar">
            <ButtonsBar 
                :addRow="addRowForklift" 
                :modifyRow="modifySelectedForklift"
                :cancel="cancel"
                :openDeleteModal="openDeleteModal"
                >
            </ButtonsBar>
        </div>        
        <div class="tables">
            <ForkliftTable 
                :extraRow="extraForklift" 
                :forklifts="forklifts"
                :selectRow="selectForkliftRow"
                ></ForkliftTable>
            <Idle :malfunctions="malfunctions"></Idle>
        </div>
    </div>
    <DeletegModal :show="shallDelete" :deleteForklift="deleteForklift" :closeDeleteModal="closeDeleteModal"></DeletegModal>
    
</template>

<script>
import ForkliftTable from './forklift-table.vue'
import ButtonsBar from './buttons-bar.vue'
import Idle from './idle-table.vue'
import DeletegModal from './delete-modal.vue'

export default {

async created() {
    this.forklifts = await this.getForklifts();
},

components: {
    ForkliftTable,
    ButtonsBar,
    Idle,
    DeletegModal
},

props: {
},

methods: {
    onSearchInput(value) {
        this.resetAll();
        this.searchNumber = value;
    },

    async findForkliftsByNumber(searchNumber)
    {
        this.forklifts = await fetch(
            `https://localhost:443/Forklifts/Find?number=` + searchNumber,
            {
              method: 'GET',              
              headers: {
                'Content-Type' : 'application/json',
              }
            }
          ).then(response => response.json()).then(data => data);
    },

    getForklifts() {
            return fetch(
                `https://localhost:443/Forklifts/GetList/`,
                {
                  method: 'GET',
                  headers: {
                    'Content-Type' : 'application/json',
                  }
                }
              ).then(response => response.json()).then(data => data);
    },

    findMalfunctionsByForkliftId() {
            return fetch(
                `https://localhost:443/Malfunctions/Find?forkliftId=` + this.selectedForklift.forkliftId,
                {
                  method: 'GET',
                  headers: {
                    'Content-Type' : 'application/json',
                  }
                }
              ).then(response => response.json()).then(data => data);
    },

    addRowForklift() {
        this.forklifts.forEach(x => x.modify = false);
        this.extraForklift = true;
        
    },

    async selectForkliftRow(forklift) {
        if(this.selectedForklift && this.selectedForklift.forkliftId && this.selectedForklift.number) {
            const elementId = `${this.selectedForklift.forkliftId} ${this.selectedForklift.number}`;
            document.getElementById(elementId).style.setProperty('background-color', 'white');
        }
        
        this.selectedForklift = forklift;
        const id = `${this.selectedForklift.forkliftId} ${this.selectedForklift.number}`;
        document.getElementById(id).style.setProperty('background-color', 'lightgray');

        this.malfunctions = await this.findMalfunctionsByForkliftId()
    },

    modifySelectedForklift() {
        this.extraForklift = false;
        const id = this.selectedForklift['forkliftId'];

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

    async cancel() {
        this.resetAll();
        this.forklifts = await this.getForklifts();
    },

    deleteForklift() {
        if(this.selectedForklift) {
            const hasRelations = this.malfunctions.some(x => 
                x.forkliftId === this.selectedForklift.forkliftId);

            if(hasRelations) {
                alert("У погрузчика имеются зарегистрированные простои – удаление запрещено ");
                this.closeDeleteModal();
                return;
            }

            const index = this.forklifts.indexOf(this.selectedForklift);
            this.forklifts.splice(index, 1);

            fetch(`https://localhost:443/Forklifts/Delete?forkliftId=` + this.selectedForklift.forkliftId,
                {
                  method: 'DELETE'
                });

            this.selectedForklift = null;
            this.closeDeleteModal();
        }
    },

    openDeleteModal() {
        this.shallDelete = true;
    },

    closeDeleteModal() {
        this.shallDelete = false;
    },

    resetAll() {
        this.extraForklift = false;
        this.forklifts.forEach(x => x.modify = false); 
        this.extraForklift = false;       

        if(this.selectedForklift) {
            const id = `${this.selectedForklift.forkliftId} ${this.selectedForklift.number}`;
            document.getElementById(id).style.setProperty('background-color', 'white');
        }
        
        this.selectedForklift = null;
    },

    save() {
    }
},

data() {
    return {
            searchNumber:'',
            forklifts:[],
            malfunctions:[],
            extraForklift:false,
            extraRowForIdle:false,
            selectedForklift: null,
            addedForklift: null,
            shallDelete: false,
            hostPort: 443
        }
    }
}
</script>
    
<style>
    .container {
        background-color: rgb(233, 230, 230);
        width: 90%;
        height: 90vh;
        margin: 12px 12px 0 0;
        padding-left: 20px;
        border-radius: 10px;
    }

    .container input {
        width: 120px;
        height: 20px;
        margin-left: 10px;
        border-radius: 8px;
        border: 1px;
        padding: 4px;
    }

    table {
        background-color: #FFF;
        border-collapse: collapse;
        border: solid 1px gray;
        height: 70%;
    }

    tr {
        max-height: 10px;
    }

    tr:hover {
        cursor: pointer;
    }

    th {
        border: solid 1px lightgray;
        padding: 4px;
    }

    td {
        border: solid 1px lightgray;
    }

    button {
        margin-left: 10px;
        border-radius: 6px;
        border: 1px;
        color: #FFF;
        background-color: rgb(189, 21, 21);
    }

    .task-bar button {
        width: 120px;
        height: 28px;        
    }

    .task-bar {
        display: flex;
        gap: 8px;
        padding: 5px 0 5px 0;
    }

    a {
        align-content: center;
        text-decoration: underline;
    }

    a:hover, button:hover {
        cursor: pointer;
    }

    .tables {
        display: flex;
        gap: 1rem;
    }
</style>