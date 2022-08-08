<template>
    <div class="combobox-feild-box " ref="selectInputField" @click="selectInputOnClick">
        <div class="combobox-defalt">- Không chọn -</div>
        <div class="combobox-icon"></div>
        <div class="combobox-item-box" ref="selectBox" v-if="isShowSelectBox">
            <div class="combobox-item" @click="itemOnClick" value="">- Không chọn -</div>
            <div class="combobox-item" @click="itemOnClick" v-for="item in data" :key="item[col['0']]" :value="item[col['0']]">{{item[col['1']]}}</div>
        </div>

        <div class="combobox-feild-box-inactive" ref="selectInputField" @click="selectInputOnClick" v-if="!isActive">
            <div class="combobox-defalt">- Không chọn -</div>
            <div class="combobox-icon"></div>
        </div>

    </div>
</template>
<script>
export default {
    props:{
        data: {},
        col: {},
        variable: String,
        isActive: {
            type: Boolean,
            default: false
        },
    },
    data() {
        return {
            isShowSelectBox: false,
        }
    },
    methods: {
        selectInputOnClick(){
            console.log(this.isActive);
            if (!this.isShowSelectBox){
                this.$refs.selectInputField.style.border= "1px solid #4262F0";
            }
            else{
                this.$refs.selectInputField.style.border = "1px solid #D3D7DE"
            }
            this.isShowSelectBox = !this.isShowSelectBox;
        },
        itemOnClick(event){
            this.$refs.selectInputField.querySelector(".combobox-defalt").innerHTML = event.target.innerHTML;
            this.$emit("emitValue",event.target.getAttribute("value"), this.variable);
        }
    },
}
</script>
<style scoped>
@import url("../../style/common/selectInput.css")
</style>