<template>
    <div v-show="show" className="add-dialog">
      <h2>Проблемы с погрузчиком? опишите</h2>
      <hr>
      <div>
        <label>начало</label><input type="datetime-local">
        <label>окончание</label><input type="datetime-local">
      </div>
      <hr>
      <div>
        <textarea></textarea>
      </div>
      <div>
        <button @click="deleteForklift">Сохранить</button>
        <button @click="closeModal">Выход</button>
      </div>      
    </div>
</template>

<script>
export default {
    props: {
      show: {
        type:Boolean
      },
      close: {
        type:Function
      },
      
    }
}
</script>

<style>
.add-dialog {
  width:500px;
  height: 400px;
  position: fixed;
  top: 20%;
  left: 35%;
  box-shadow: 0 6px 15px 0px black;
  background-color: rgb(183, 183, 183);
  border: 1px solid black;
  border-radius: 5px;
  align-items: center;
  display: flex;
  flex-direction: column;
}
</style>