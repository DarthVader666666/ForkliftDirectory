<template>
    <div className="buttons">
        <button @click="addRow()">Добавить</button>
        <button @click="modifyRow()">Изменить</button>
        <button @click="openDeleteModal()">Удалить</button>
        <button @click="save()">Сохранить</button>
        <button @click="cancel()">Отменить</button>
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
        margin: 0.5rem 0;
    }
</style>