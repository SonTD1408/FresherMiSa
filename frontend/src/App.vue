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
/* css của datepicker element ui  */
:deep(.el-input__wrapper:hover){
    box-shadow: 0 0 0 1px #7C869C inset;
}
:deep(.el-input__wrapper.is-focus){
    box-shadow: 0 0 0 1px #4262F0 inset;
}
:deep(.el-input__wrapper){
    box-sizing: border-box;
    border-radius: 4px;
    font-family: Roboto;
    font-size: 13px;
}
</style>
