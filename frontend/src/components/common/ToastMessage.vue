<template>
    <div class="toast-message" ref="ToastMessage">
        <div class="toast-message-box tmb-infor" v-if="typeMsg==1">
            <div class="toast-message-icon tmb-infor-icon"></div>
            <div class="toast-message-txt">Thông tin</div>
            <div class="toast-message-close"></div>
        </div>
        <div class="toast-message-box tmb-warning" v-if="typeMsg==2">
            <div class="toast-message-icon tmb-warning-icon"></div>
            <div class="toast-message-txt">Cảnh báo</div>
            <div class="toast-message-close"></div>
        </div>
        <div class="toast-message-box tmb-success" v-if="typeMsg==3">
            <div class="toast-message-icon tmb-success-icon"></div>
            <div class="toast-message-txt">Thành công</div>
            <div class="toast-message-close"></div>
        </div>
        <div class="toast-message-box tmb-error" v-if="typeMsg==4">
            <div class="toast-message-icon tmb-error-icon"></div>
            <div class="toast-message-txt">Lỗi</div>
            <div class="toast-message-close"></div>
        </div>
    </div>
</template>
<script>
export default {
    props: {
        typeMsg: {
            type: Number,
            default: 0
        }
    },
    methods: {

    },
}
</script>
<style scoped>
    @import url("../../style/common/toastMessage.css");
</style>