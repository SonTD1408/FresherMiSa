<template>
    <div id="content" ref="content">
        <router-view @showToastMessage="showMessage" :searchString="searchString"></router-view>
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
            toastMsgType: 1,
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
    },
}
</script>
<style scoped>
    @import url("../../style/layout/content.css");
</style>