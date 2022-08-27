<template>
    <div id="content" ref="content">
        <router-view v-if="regenderComponent==1" @showToastMessage="showMessage" :searchString="searchString" @resetComponent="resetComponent"></router-view>
        <ToastMessage :typeMsg="toastMsgType"></ToastMessage>
    </div>
</template>
<script>
import ToastMessage from "../common/ToastMessage.vue"
export default {
    props:{
        // lấy dữ liệu ô search ở header 
        searchString: String,
    },
    components:{
        ToastMessage
    },
    data() {
        return {
            // cờ đánh dấu kiểu message
            toastMsgType: 1,
            // biến đánh dấu reset component
            regenderComponent: 1,
        }
    },
    methods: {
        /**
         * hàm show thông báo khi thêm thành công
         */
        showMessage(value){
            let me = this;
            me.toastMsgType =value;
            me.$refs.content.querySelector(".toast-message").animate(
                [
                    {transform: 'translateY(0)'},
                    {transform: 'translateY(100px)'},
                    {transform: 'translateY(100px)'},
                    {transform: 'translateY(100px)'},
                    {transform: 'translateY(100px)'},
                    {transform: 'translateY(100px)'},
                    {transform: 'translateY(100px)'},
                    {transform: 'translateY(100px)'},
                    {transform: 'translateY(100px)'},
                    {transform: 'translateY(100px)'},
                    {transform: 'translateY(-100px)'},
                ],
                {duration: 3000}
            )
            
            // console.log(me.toastMsgType);
        },
        /**
         * hàm reset component
         * created by SONTD(27.08.2022)
         */
        resetComponent(){
            this.regenderComponent =0;
            setTimeout(()=>{this.regenderComponent =1;} , 1);
        },
    },
}
</script>
<style scoped>
    @import url("../../style/layout/content.css");
</style>