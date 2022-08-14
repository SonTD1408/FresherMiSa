<template>
    <div class="dialog-component" v-if="isShow">
        <div class="dialog-component-container">
            <div class="dcc-box">
                <div class="dcc-close-icon-box" @click="confirm(false)">
                    <div class="dcccib-icon"></div>
                </div>
                <div class="dcc-title-box">Bạn có chắc muốn xóa Tiềm năng này không?</div>
                <div class="dcc-button-box">
                    <button class="s-button-gray" @click="confirm(false)">Hủy bỏ</button>
                    <button class="s-button-red dccbb-delete-button" @click="confirm(true)">Đồng ý</button>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
export default {
    props:{
        isShow: Number
    },
    methods: {
        confirm(value){
            this.$emit("confirm",value);
        }
    },
}
</script>
<style scoped>
@import url("../../style/dialog/dialog.css");
</style>