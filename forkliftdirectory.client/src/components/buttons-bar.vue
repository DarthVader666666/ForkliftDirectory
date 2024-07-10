<template>
    <div className="buttons">
        <div>
            <button @click="addRow()">Добавить</button>
            <button>Изменить</button>
            <button>Удалить</button>
        </div>
        <div>
            <button>Сохранить</button>
            <button>Отменить</button>
        </div>
    </div>    
</template>

<script>
export default {

async created() {
},

components: {
},

props: {
    addRow: {
        type:Function
    }
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
    .buttons {
        display: flex;
        gap:2rem;
        margin: 0.5rem 0;
    }
</style>