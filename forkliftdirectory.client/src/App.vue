<template>
  <header>
    <button>Профиль</button>
  </header>
  <main>
    <aside>
      <p>Пользователи</p>
      <p>Уведомления и напоминания</p>
      <p>Настройки АИС ОГПА</p>
      <p>Справочник погрузчиков</p>
      <p>Резервное копирование и восстановление</p>
      <p>Справочники</p>
    </aside>
    <Directory></Directory>

  </main>
</template>

<script>
  import Directory from './components/directory-task-bar.vue'

  export default {
    components: {
      Directory
    }
  }
</script>

<style scoped>
  header {
    background-color: rgb(189, 21, 21);
    height: 60px;
    width: 100%;
    border-radius: 10px;
    display: flex;
    align-items: center;
    justify-content: end;
}

header button {
  background-color: #FFF;
  font-weight: bold;
  height: 30px;
  width: 120px;
  border-radius: 10px;
  margin-right: 10px;
}

aside {
  background-color: rgb(189, 21, 21);
  height: 90vh;
  width: 15%;
  margin: 12px 12px 0 0;
  background-color: rgb(233, 230, 230);
  border-radius: 10px;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: start;
}

aside p {
  margin-left: 10%;
}

main {
  display: flex;
}
</style>
