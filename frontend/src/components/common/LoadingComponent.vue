<template>
    <div class="loading-component-container" v-if="typeOfLoading!=0">
        <div class="loading-component-grid" v-if="typeOfLoading==1">
            <div class="loading-component-grid-icon"></div>
            <div class="loading-component-grid-title">Đang tải dữ liệu</div>
        </div>
        <div class="loading-component-combobox" v-if="typeOfLoading==2">
            <div class="loading-component-combobox-icon"></div>
            <!-- <div class="loading-component-grid-title">Đang tải dữ liệu</div> -->
        </div>
    </div>
</template>
<script>
export default{
    props:{
        /**
         * loại loading
         * 0: không hiện loading
         * 1: loading dữ liệu
         */
        typeOfLoading: {
            type: Number,
            default: 0
        }
    }
}
</script>
<style scoped>
    .loading-component-container{
        position: absolute;
        top: 0; right: 0; bottom: 0; left: 0;
        background-color: #fff;
        display: flex;
        justify-content: center;
        align-items: center;
    }

    /* loading cho grid  */
    .loading-component-grid{
        display: flex;
        flex-direction: column;
        align-items: center;
    }
    .loading-component-grid-icon{
        width: 52px;
        height: 52px;
        background: url("../../assets/img/loadding.svg") no-repeat -14px -19px;
    }

    /* loading cho combobox  */
    .loading-component-combobox{
        display: flex;
        flex-direction: column;
        align-items: center;
    }
    .loading-component-combobox-icon{
        width: 16px; height: 16px;
        border-radius: 50%;
        border: 2px solid #ccc;
        border-top: 2px solid #fff;
        -webkit-animation: spin .5s linear infinite;
        animation: spin .5s linear infinite;
    }
    @-webkit-keyframes spin {
        0% { -webkit-transform: rotate(0deg); }
        100% { -webkit-transform: rotate(360deg); }
    }
    @keyframes spin {
        0% { transform: rotate(0deg); }
        100% { transform: rotate(360deg); }
    }
</style>