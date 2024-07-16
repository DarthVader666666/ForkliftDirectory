<template>
    <div v-show="show" className="add-dialog">
      <h2>Проблемы с погрузчиком? опишите</h2>
      <hr>
      <div className="date-fields">
        <div>
            <label>начало</label>
            <input :value="newMalfunction.startTime" @change="(e) => this.startTime = e.target.value" type="datetime-local">
        </div>
        <div>
            <label>окончание</label>
            <input v-model="endTime" type="datetime-local">
        </div>
        </div>
        <h2>Описание инцидента</h2>
        <textarea @change="e => onDescribtionChange(e.target.value)"></textarea>
        <div className="dialog-buttons">
            <button @click="save">Сохранить</button>
            <button className="exit-button" @click="closeModal">Выход</button>
        </div>
    </div>
</template>

<script>
export default {
    async created() {
    },

    props: {
        show: {
          type:Boolean
        },
        closeModal: {
          type:Function
        },
        newMalfunction: {
            type:Object
        },
        addMalfunction: {
            type:Function
        }
    },

    data() {
        return {
            endTime:null,
            describtion:null
        }
    },

    methods: {
        save() {
            this.addMalfunction(this.startTime, this.endTime, this.describtion)
        },

        onDescribtionChange(value) {
            this.describtion = value
        }
    }
}
</script>

<style>
.add-dialog {
  width:650px;
  height: 430px;
  position: fixed;
  top: 20%;
  left: 35%;
  box-shadow: 0 6px 15px 0px black;
  background-color: rgb(228, 228, 228);
  border: 1px solid black;
  border-radius: 5px;
  text-align: center;
}

.dialog-inputs {
    display: flex;
    flex-direction: column;
    align-content: space-around;
}

hr {
    width: 90%;
    border: 2px solid rgb(189, 21, 21);
}

.date-fields {
    display: flex;
    flex-direction: row;
    gap:4rem;
    justify-content: center;
    margin: 15px;
}

.date-fields div input {
    width: 180px;
}

textarea {
    margin: 15px;
    width: 600px;
    height: 200px;
    border-radius: 3%;
}

.exit-button {
    background-color: gray;
    color:black;
}

</style>