<template>
    <div v-show="false" className="dialog">
      <h2>Вы уверены?</h2>
      <div className="yes-no-buttons">
        <button>Да</button>
        <button>Нет</button>
      </div>      
    </div>
</template>

<script>
export default {
    

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