<template>
    <div class="select-input-feild-box " ref="selectInputField" @click="selectInputOnClick" v-click-outside="onClickOutside">
        <div class="select-input-defalt">- Không chọn -</div>
        <div class="select-input-icon" ref="selectInputFieldIcon"></div>
        <div class="select-input-item-box" ref="selectBox" v-if="isShowSelectBox">
            <div class="select-input-item" @click="itemOnClick" value="">- Không chọn -</div>
            <div class="select-input-item" @click="itemOnClick" v-for="item in data" :key="item[col['0']]" :value="item[col['0']]">{{item[col['1']]}}</div>
        </div>

        <div class="select-input-feild-box-inactive" ref="selectInputField" @click="selectInputOnClick" v-if="!isActive">
            <div class="select-input-defalt">- Không chọn -</div>
            <div class="select-input-icon"></div>
        </div>

    </div>
</template>
<script>
//click out side
import vClickOutside from "click-outside-vue3"
export default {
    directives: {
      clickOutside: vClickOutside.directive
    },
    props:{
        data: {},
        col: {},
        variable: String,
        isActive: {
            type: Boolean,
            default: true
        },
    },
    data() {
        return {
            isShowSelectBox: false,
        }
    },
    methods: {
        /**
         * xử lí khi chọn vào ô select input
         * createby SONTD (12.08.2022)
         */
        selectInputOnClick(){
            if (!this.isShowSelectBox){
                this.$refs.selectInputField.style.border= "1px solid #4262F0";
                this.$refs.selectInputFieldIcon.classList.remove("fa-arrow-down-close")
                this.$refs.selectInputFieldIcon.classList.add("fa-arrow-down-open")
            }
            else{
                this.$refs.selectInputField.style.border = "1px solid #D3D7DE";
                this.$refs.selectInputFieldIcon.classList.remove("fa-arrow-down-open")
                this.$refs.selectInputFieldIcon.classList.add("fa-arrow-down-close")

            }
            this.isShowSelectBox = !this.isShowSelectBox;
        },
        
        /**
         *  binding dữ liệu lên ô input khi chọn  
         * @param {*} event 
         */
        itemOnClick(event){
            this.$refs.selectInputField.querySelector(".select-input-defalt").innerHTML = event.target.innerHTML;
            this.$emit("emitValue",event.target.getAttribute("value"), this.variable);
        },

        onClickOutside(){
            this.isShowSelectBox = false;
            this.$refs.selectInputFieldIcon.classList.remove("fa-arrow-down-open")
                this.$refs.selectInputFieldIcon.classList.add("fa-arrow-down-close")
        }
    },
    mounted(){
    }
}
</script>
<style scoped>
@import url("../../style/common/selectInput.css")
</style>