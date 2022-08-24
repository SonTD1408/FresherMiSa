<template>
  <div id="header">
    <div class="header-left">
      <div class="hl-tongle-btn"></div>
      <div class="hl-img"></div>
    </div>
    <div class="header-mid">
      <div class="hm-input-box">
        <div class="hm-input-container">
          <input
            type="text"
            class="s-input search-field"
            v-model="searchString"
            placeholder="Tìm kiếm tiềm năng, liên hệ khách hàng"
            v-on:keyup.enter="searchOnEnter"/>
          <div class="hm-input-icon">
          </div>
        </div>
      </div>
    </div>
    <div class="header-right">
      <div class="hr-icon-container">
        <div class="hr-face-icon"></div>
      </div>
      <div class="hr-icon-container">
        <div class="hr-box-icon"></div>
      </div>
      <div class="hr-icon-container">
        <div class="hr-calendar-icon"></div>
      </div>
      <div class="hr-icon-container">
        <div class="hr-notify-icon"></div>
      </div>
      <div class="hr-icon-container">
        <div class="hr-setting-icon"></div>
      </div>
      <div class="hr-icon-container">
        <div class="hr-about-icon"></div>
      </div>
      <div class="hr-avatar-img"></div>
    </div>
  </div>
</template>

<script>
export default {
    components: {
    },
    data() {
        return {
            // biến lưu dl trong ô search 
            searchString: "",
        }
    },
    methods: {
        /**
         * hàm chuyền dl để reload bảng khi ấn enter ở ô search
         * created by SONTD(24.08.2022)
         */
        searchOnEnter(){
            this.$emit("emitSearchString", this.searchString);
        }
    },
}
</script>
<style scoped>
@import url("../../style/layout/header.css");
@import url("../../style/common/input.css");
</style>