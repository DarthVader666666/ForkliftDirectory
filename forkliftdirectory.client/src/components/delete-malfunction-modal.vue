<template>
    <div v-show="show" className="dialog">
      <h2>Удалить информацию о простое? Вы уверены?</h2>
      <div className="yes-no-buttons">
        <button @click="deleteMalfunction">Да</button>
        <button @click="closeModal">Нет</button>
      </div>      
    </div>
</template>

<script>
export default {
    props: {
      show: {
        type:Boolean
      },
      deleteMalfunction: {
        type:Function
      },
      closeModal: {
        type:Function
      }
    }
}
</script>

<style>
.dialog {
  width:400px;
  height: 200px;
  position: fixed;
  top: 30%;
  left: 40%;
  box-shadow: 0 6px 5px -5px black;
  background-color: white;
  border: 1px solid black;
  border-radius: 5px;
  display: flex;
  flex-direction: column;
  gap:40%;
  align-items: center;
}

.yes-no-buttons {
  display: flex;
  justify-content: center;
  gap: 100%;
}

.yes-no-buttons button {
  width: 100px;
}
</style>