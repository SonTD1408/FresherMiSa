<template>
    <div class="body">
        <TheHeader @emitSearchString="getSearchStringFromHeader"></TheHeader>
        <TheNavigation></TheNavigation>
        <TheContent :searchString="searchString"></TheContent>
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
  },
  data() {
    return {
        // lưu dữ liệu search
        searchString: "",  
    }
  },
  methods: {
      // hàm lấy dl searchString 
      getSearchStringFromHeader(searchString){
          this.searchString = searchString;
      } 
  },
}
</script>

<style scoped>
@import url("./style/main.css");
@import url("./style/common/scrollBar.css");

</style>
