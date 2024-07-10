<template>
    <div className="container">
        <h3>Справочник погрузчиков</h3>
        <div className="task-bar">
            <label>Номер погрузчика</label>
            <input type="text"/>
            <button>🔍 Искать</button>
            <a><span>❌</span>Очистить фильтр</a>
            <button>Изменить</button>
        </div>
        <div className="task-bar">
            <ButtonsBar></ButtonsBar>
        </div>        
        <div class="tables">
            <MalfunctionTable></MalfunctionTable>
            <Idle></Idle>
        </div>        
    </div>
    
</template>

<script>
import MalfunctionTable from './malfunction-table.vue'
import ButtonsBar from './buttons-bar.vue'
import Idle from './idle-table.vue'

export default {
components: {
    MalfunctionTable,
    ButtonsBar,
    Idle
},

props: {
},

methods: {
},
data() {
return {
    }
}
}
</script>
    
<style>
    .container {
        background-color: rgb(233, 230, 230);
        width: 85%;
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