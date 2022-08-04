<template>
    <div class="body">
        <TheHeader></TheHeader>
        <TheNavigation></TheNavigation>
        <TheContent></TheContent>
    </div>
</template>

<script>
import TheHeader from "./components/layout/TheHeader.vue"
import TheNavigation from "./components/layout/TheNavigation.vue"
import TheContent from "./components/layout/TheContent.vue"
export default {
  name: 'App',
  components: {
    TheHeader,
    TheNavigation,
    TheContent,
  }
}
</script>

<style scoped>
@import url("./style/main.css");
@import url("./style/common/scrollBar.css");
@import url("./style/common/combobox.css");

</style>
