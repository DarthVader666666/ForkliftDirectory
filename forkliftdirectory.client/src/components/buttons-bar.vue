<template>
    <div className="buttons">
        <div>
            <button @click="addRow()">Добавить</button>
            <button @click="modifyRow()">Изменить</button>
            <button @click="openDeleteModal()">Удалить</button>
        </div>
        <div>
            <button @click="save()">Сохранить</button>
            <button @click="cancel()">Отменить</button>
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
    },
    modifyRow: {
        type:Function
    },
    cancel: {
        type:Function
    },
    openDeleteModal: {
        type:Function
    },
    save: {
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