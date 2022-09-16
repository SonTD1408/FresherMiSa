<template>
    <div class="select-input-feild-box" ref="selectInputField" @click="selectInputOnClick" v-click-outside="onClickOutside">
        <div class="select-input-defalt">{{defaultValueTxt}}</div>
        <div class="select-input-icon" ref="selectInputFieldIcon"></div>
        <div class="select-input-item-box" ref="selectBox" v-show="isShowSelectBox">
            <div class="select-input-item-box-input-box">
                <input type="text" class="s-input select-input-item-box-input" placeholder="Tìm kiếm" @click.stop>
                <div class="select-input-item-box-input-icon-box">
                    <div class="select-input-item-box-input-icon"></div>
                </div>
            </div>
            <div class="select-input-item-container">
                <div class="select-input-item" @click="itemOnClick" :value="type=='guid'?'00000000-0000-0000-0000-000000000000':null"><div class="select-input-item-value">- Không chọn -</div></div>
                <div class="select-input-item" item="true" @click="itemOnClick" v-for="item in data" :key="item[col['0']]" :value="item[col['0']]">
                    <div class="select-input-item-value">{{item[col['1']]}}</div>
                    <div class="select-input-item-icon"></div>
                </div>
            </div>
            <div class="select-input-item-loading" v-if="isHasLoading && loadingType!=0">
                <LoadingComponent :typeOfLoading="loadingType"/>
            </div>
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
import LoadingComponent from "./LoadingComponent.vue";
export default {
    directives: {
        clickOutside: vClickOutside.directive
    },

    props: {
        // data để bind râ các ô để chọn
        data: {},
        // tên cột
        col: {},
        // tên biến khi trả về 
        variable: String,
        // có disable hay không 
        isActive: {
            type: Boolean,
            default: true
        },
        // default value
        defaultValue: String,
        // loại dữ liệu int hay guid
        type: {
            type: String,
            default: "int"
        },
        // có loading hay không
        loading: {
            type: Boolean,
            default: true,
        }
    },
    data() {
        return {
            // ẩn hiện select box 
            isShowSelectBox: false,
            // default text
            defaultValueTxt: "",
            // biến kiểm trâ xem có hiển thị loading hay không
            isHasLoading: true,
            // loại loading
            loadingType: 0,
        };
    },
    methods: {
        /**
         * xử lí khi chọn vào ô select input
         * createby SONTD (12.08.2022)
         */
        selectInputOnClick() {
            let me = this;
            if (!me.isShowSelectBox) {
                me.$refs.selectInputField.style.border = "1px solid #4262F0";
                me.$refs.selectInputFieldIcon.classList.remove("fa-arrow-down-close");
                me.$refs.selectInputFieldIcon.classList.add("fa-arrow-down-open");
            }
            else {
                this.$refs.selectInputField.style.border = "1px solid #D3D7DE";
                this.$refs.selectInputFieldIcon.classList.remove("fa-arrow-down-open");
                this.$refs.selectInputFieldIcon.classList.add("fa-arrow-down-close");
            }
            this.isShowSelectBox = !this.isShowSelectBox;
        },
        /**
         * binding dữ liệu lên ô input khi chọn
         * created by SONTD(15.09.2022)
         * @param {*} event
         */
        itemOnClick(event) {
            this.$refs.selectInputField.querySelector(".select-input-defalt").innerHTML = event.target.closest(".select-input-item").querySelector(".select-input-item-value").innerHTML;
            if (this.$refs.selectInputField.querySelector(".select-input-defalt").innerHTML == "- Không chọn -") {
                this.$refs.selectInputField.querySelector(".select-input-defalt").style.color = "#99A1B2";
            }
            else {
                this.$refs.selectInputField.querySelector(".select-input-defalt").style.color = "#1F2229";
            }
            if (this.$refs.selectInputField.querySelector(".select-input-item-selected")) {
                this.$refs.selectInputField.querySelector(".select-input-item-selected").classList.remove("select-input-item-selected");
            }
            if (event.target.closest(".select-input-item[item]")) {
                event.target.closest(".select-input-item[item]").classList.add("select-input-item-selected");
            }
            this.$emit("emitValue", event.target.closest(".select-input-item").getAttribute("value"), this.variable);
        },
        /**
         * sự kiện khi click outside
         */
        onClickOutside() {
            this.isShowSelectBox = false;
            this.$refs.selectInputFieldIcon.classList.remove("fa-arrow-down-open");
            this.$refs.selectInputFieldIcon.classList.add("fa-arrow-down-close");
            this.$refs.selectInputField.style.border = "1px solid #D3D7DE";
        }
    },
    created() {
        // nếu chưa có data thì hiện loading
        if(this.data && this.data.length> 0){
            this.loadingType = 0;
        }else{
            this.loadingType = 2;
        }
    },
    mounted() {
        this.defaultValueTxt = "- Không chọn -";
        this.isHasLoading = this.loading;
    },
    watch: {
        // xử lí khi truyền defaultvalue
        "defaultValue": function () {
            let me = this;
            if (me.type == "int") {
                let intTypeValue = parseInt(me.defaultValue);
                me.data.forEach(function (item) {
                    if (item[me.col[0]] == intTypeValue) {
                        me.defaultValueTxt = item[me.col[1]];
                    }
                });
            }
            else {
                if (me.data.length > 0) {
                    me.data.forEach(function (item) {
                        if (item[me.col[0]] == me.defaultValue) {
                            me.defaultValueTxt = item[me.col[1]];
                            me.$refs.selectInputField.querySelector(".select-input-defalt").style.color = "#1F2229";
                        }
                    });
                }
                else {
                    me.defaultValueTxt = "- Không chọn -";
                }
            }
        },
        // xử lí khi truyền data
        "data": function () {
            let me = this;
            if(me.data && me.data.length>0){
                me.loadingType =0;
            }
            if (me.defaultValue) {
                if (me.defaultValue != "00000000-0000-0000-0000-000000000000") {
                    me.data.forEach(function (item) {
                        if (item[me.col[0]] == me.defaultValue) {
                            me.defaultValueTxt = item[me.col[1]];
                            me.$refs.selectInputField.querySelector(".select-input-defalt").style.color = "#1F2229";
                        }
                    });
                }
                else {
                    me.defaultValueTxt = "- Không chọn -";
                }
            }
            else {
                me.defaultValueTxt = "- Không chọn -";
            }
        },
        // kiểm tra xem có loading hay không
        "loading":function(){
            this.isHasLoading = this.loading;
        },
    },
    components: { LoadingComponent }
}
</script>
<style scoped>
@import url("../../style/common/selectInput.css")
</style>