<template>
    <div className="buttons">
        <button @click="add()">Добавить</button>
        <button @click="modify()">Изменить</button>
        <button @click="open()">Удалить</button>
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
    add: {
        type:Function
    },
    modify: {
        type:Function
    },
    cancel: {
        type:Function
    },
    open: {
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