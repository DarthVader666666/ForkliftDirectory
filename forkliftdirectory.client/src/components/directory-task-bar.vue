<template>
    <div className="container">
        <h3>Справочник погрузчиков</h3>
        <div className="task-bar">
            <label>Номер погрузчика</label>
            <input @input="event => onSearchInput(event.target.value)" type="search"/>
            <button @click="searchForkliftsByNumber()">🔍 Искать</button>
            <span>❌</span><a @click="(e) => onClearFilter(e.target.value)">Очистить фильтр</a>
            <button>Изменить</button>
        </div>
        <div className="task-bar">            
            <ForkliftTable 
                :setMalfunctions="setMalfunctionsForForklift"
                :malfunctions="malfunctionsForForklift"
                :setForklifts="setForklifts"
                :forklifts="forklifts"
                :url="url"
                >
            </ForkliftTable>
            <MalfunctionsTable 
                :malfunctions="malfunctionsForForklift"
                :forkliftNumber="forkliftNumber"
                :forkliftId="forkliftId"
                :url="url"
                >
            </MalfunctionsTable>
        </div>
    </div>

</template>

<script>
import ForkliftTable from './forklift-table.vue'
import MalfunctionsTable from './malfunctions-table.vue'

export default {

async created() {
    this.url = import.meta.env.VITE_API_URL;
    await this.setForklifts();
},

components: {
    ForkliftTable,
    MalfunctionsTable
},

props: {
},

methods: {    
    onSearchInput(value) {
        this.searchNumber = value;
    },

    async searchForkliftsByNumber()
    {
        this.forklifts = await fetch(
            `${this.url}/Forklifts/Find?forkliftNumber=` + this.searchNumber,
            {
              method: 'GET'
            }
          ).then(response => response.json()).then(data => data);
    },

    async setForklifts() {
        this.forklifts = await fetch(
            `${this.url}/Forklifts/GetList/`,
            {
              method: 'GET'
            }
          ).then(response => response.json()).then(data => data);
    },

    getForklift(forklifId) {
        return fetch(
            `${this.url}/Forklifts/Get/${forklifId}`,
            {
              method: 'GET'
            }
          ).then(response => response.json()).then(data => data);
    },

    async setMalfunctionsForForklift(forkliftId) {
        this.malfunctionsForForklift = await fetch(
            `${this.url}/Malfunctions/Find?forkliftId=` + forkliftId,
            {
                method: 'GET'
            }
          ).then(response => response.json()).then(data => data);
        
        this.forklifts.forEach(x => { 
            if(x.forkliftId === forkliftId) {
                this.forkliftId = forkliftId;
                this.forkliftNumber = x.number;
                return;
            }
        });
    },

    onClearFilter() {
        window.document.location.reload();
    }
},

data() {
    return {
            searchNumber: null,
            malfunctionsForForklift: [],            
            extraRowForIdle: false,
            addedForklift: null,
            url: null,
            forklifts: [],
            forkliftNumber: null,
            forkliftId: null
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