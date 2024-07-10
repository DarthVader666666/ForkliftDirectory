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
                >
            </ButtonsBar>
        </div>        
        <div class="tables">
            <ForkliftTable 
                :extraRow="extraRowForForklifts" 
                :forklifts="forklifts"
                :selectRow="selectForkliftRow"
                ></ForkliftTable>
            <Idle :malfunctions="malfunctions"></Idle>
        </div>        
    </div>
    
</template>

<script>
import ForkliftTable from './forklift-table.vue'
import ButtonsBar from './buttons-bar.vue'
import Idle from './idle-table.vue'

export default {

async created() {
    this.forklifts = await this.getForklifts();
},

components: {
    ForkliftTable,
    ButtonsBar,
    Idle
},

props: {
},

methods: {
    onSearchInput(value) {
        this.searchNumber = value;
    },

    async findForkliftsByNumber(searchNumber)
    {
        this.forklifts = await fetch(
            'https://localhost:7139/Forklifts/Find?number=' + searchNumber,
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
                'https://localhost:7139/Forklifts/GetList/',
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
                'https://localhost:7139/Malfunctions/Find?forkliftId=' + this.selectedForkliftRow.forkliftId,
                {
                  method: 'GET',
                  headers: {
                    'Content-Type' : 'application/json',
                  }
                }
              ).then(response => response.json()).then(data => data);
    },

    addRowForklift() {
        this.extraRowForForklifts = true;
    },

    async selectForkliftRow(id) {
        if(this.selectedForkliftRow.forkliftId && this.selectedForkliftRow.rowId) {
            const elementId = `${this.selectedForkliftRow.forkliftId} ${this.selectedForkliftRow.rowId}`;
            document.getElementById(elementId).style.setProperty('background-color', 'white');
        }
        
        const stringArray = id.split(" ");
        this.selectedForkliftRow = { forkliftId:stringArray[0], rowId:stringArray[1], modify:false}
        document.getElementById(id).style.setProperty('background-color', 'lightgray');

        this.malfunctions = await this.findMalfunctionsByForkliftId()
    },

    modifySelectedForklift() {
        const id = this.selectedForkliftRow['forkliftId'];

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
    }
},

data() {
    return {
            searchNumber:'',
            forklifts:[],
            malfunctions:[],
            extraRowForForklifts:false,
            extraRowForIdle:false,
            selectedForkliftRow: { forkliftId:null ,rowId:null, modify:false }
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