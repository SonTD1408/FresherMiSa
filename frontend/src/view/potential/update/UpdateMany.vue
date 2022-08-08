<template>
    <div id="updateMany" v-if="isShow==true">
        <div class="updateMany-container">
            <div class="umc-header">
                <div class="umch-title">Cập nhật thông tin</div>
                <div class="umch-button-box">
                    <div class="umchbb-about-box">
                        <div class="umchbb-about"></div>
                    </div>
                    <div class="umchbb-close-box" @click="closeOnClick">
                        <div class="umchbb-close"></div>
                    </div>
                </div>
            </div>
            <div class="umc-content">
                <div class="umcc-selectField">
                    <SelectInputField></SelectInputField>
                </div>
                <div class="umcc-input-content">
                    <input type="text" class="s-input" style="width: 100%" disabled>
                </div>
            </div>
            <div class="umc-footer">
                <button class="s-button-gray" @click="closeOnClick">Hủy bỏ</button>
                <button class="s-button">Cập nhật</button>
            </div>
        </div>
    </div>
</template>

<script>
import SelectInputField from "../../../components/common/SelectInput.vue"
export default {
    components:{
        SelectInputField
    },
    props: {
        isShow: Boolean,
    },
    methods: {
        /**
         * hàm gọi khi bấm hủy 
         * created by SONTD (06.08.2022)
         */
        closeOnClick(){
            this.$emit("hideShowStatus",false);
        }
    }
}
</script>
<style scoped>
@import url("../../../style/view/potential/update/updateMany.css");
</style>