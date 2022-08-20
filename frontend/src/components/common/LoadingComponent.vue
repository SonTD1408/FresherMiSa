<template>
    <div class="loading-component-container" v-if="typeOfLoading!=0">
        <div class="loading-component-grid">
            <div class="loading-component-grid-icon"></div>
            <div class="loading-component-grid-title">Đang load dữ liệu</div>
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
</style>