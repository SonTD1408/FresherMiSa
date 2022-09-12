<template>
    <div class="combobox-component-container" @click="hideShowSelectBox" ref="combobox" v-click-outside="onClickOutside">
        <div class="combobox-component-defalt" v-if="isResultNull" >- Không chọn -</div>

        <div class="combobox-component-box" v-if="!isResultNull">
            <div class="combobox-component-tag" v-for="(item,index) in result" :key="index" :idTag="item[col[0]]">
                <div class="combobox-component-tag-content">{{item[col[1]]}}</div>
                <div class="combobox-component-tag-delete-icon-box" @click.stop @click="deleteBtnOnClick($event)">
                    <div class="combobox-component-tag-delete-icon"></div>
                </div>
            </div>
        </div>
        <div class="combobox-component-item-box" v-show="isShowSelectBox" @click.stop ref="comboboxItemBox">
            <div class="combobox-component-item" @click="noSelectedItem">- Không chọn -</div>
            <div class="combobox-component-item" v-for="(item,index) in data" :key="index" :idRow="item[col['0']]" @click="rowOnClick(item, $event)" >
                <div class="combobox-component-item-content">{{item[col['1']]}}</div>
                <div class="combobox-component-item-icon" style="visibility: hidden"></div>
            </div>
        </div>
    </div>
</template>
<script>
import vClickOutside from "click-outside-vue3";

export default{
    directives: {
        clickOutside: vClickOutside.directive
    },
    props:{
        // data của select box
        data: {},
        // tên những column cần lấy trong data 
        col: {},
        // biến lưu tên biến khi trả về
        variable: String,
        // giá trị đầu vào của combobox 
        defaultValue: String,
    },
    data() {
        return {
            // đánh dấu xem xem value trả về có null hay không
            isResultNull: true,
            // data để return về
            result: [],
            // biến để ẩn hiện select box
            isShowSelectBox: false,
            // biến check xem trước đó id này đã được check chưa
            isRowSelected: {},
        }
    },
    methods: {
        /**
         * hàm ẩn hiện selectbox khi ấn vào combobox
         * created by SONTD(20.08.2022)
         */
        hideShowSelectBox(){
            let me = this;
            me.isShowSelectBox = !me.isShowSelectBox;
        },

        /**
         * hàm xử lí khi chọn 1 item trong select box
         * created by SONTD(20.08.2022)
         * @param {*} item 
         * @param {*} event 
         */
        rowOnClick(item, event){
            let me = this;
            let rowSelected = event.target.closest(".combobox-component-item");
            if (!me.isRowSelected[rowSelected.getAttribute("idRow")]){
                me.isRowSelected[rowSelected.getAttribute("idRow")] = true;
            }else{
                me.isRowSelected[rowSelected.getAttribute("idRow")] = false;
            }
            me.updateStatusCombobox();
        },

        /**
         * cập nhật trạng thái của combobox
         * created by SONTD(20.08.2022)
         */
        updateStatusCombobox(){
            let me = this;
            // khởi tạo lại result 
            me.result =[];
            me.isResultNull = true;
            me.$refs.combobox.querySelectorAll(".combobox-component-item[idRow]").forEach(function(item){
                if (me.isRowSelected[item.getAttribute("idRow")]){
                    // cập nhật lại màu cho những dòng đã được chọn
                    item.querySelector(".combobox-component-item-content").classList.add("combobox-component-item-content-selected");
                    // hiện icon đã chọn
                    item.querySelector(".combobox-component-item-icon").style.visibility="visible";
                    // cập nhật lại biến check xem result có null hay không
                    me.isResultNull = false;
                    // thêm id và name vào biến kết quả result
                    let res = {};
                    res[me.col[0]] = item.getAttribute("idRow");
                    res[me.col[1]] = item.querySelector(".combobox-component-item-content").textContent;
                    me.result.push(res);
                }else{
                    item.querySelector(".combobox-component-item-content").classList.remove("combobox-component-item-content-selected");
                    item.querySelector(".combobox-component-item-icon").style.visibility="hidden";
                }
            })
            this.$emit("emitComboboxValue",me.variable, me.result);
        },

        /**
         * hàm xứ lí sự kiện bấm xóa 1 tag khỏi combobox
         * created by SONTD(20.08.2022)
         */
        deleteBtnOnClick(event){
            let me = this,
                // biến chứa id của hàng mình đang muốn xóa
                idTag = event.target.closest(".combobox-component-tag").getAttribute("idTag");
            // sử lại attribute isSelected để chuẩn bị update
            // me.$refs.combobox.querySelector(`[idRow='${idTag}']`).setAttribute("isSelected","false");
            me.isRowSelected[idTag] = false;
            // update lại combobox
            me.updateStatusCombobox();
        },

        /**
         * hàm xử lí sự kiện khi click ra ngoài combobox
         * created by SONTD(20.08.2022)
         */
        onClickOutside(){
            this.isShowSelectBox = false;
        },

        /**
         * xử lí khi ấn không chọn của combobox 
         * created by SONTD(21.08.2022)
         */
        noSelectedItem(){
            let me = this;
            me.data.forEach(function(item){
                me.isRowSelected[item[me.col[0]]] = false;
            })
            me.updateStatusCombobox();
            me.isShowSelectBox = false;
        }
    },
    watch: {
        // xử lí khi data đầu vào thay đổi
        'data':function(){
            let me = this;
            if(me.data && me.data.length>0){
                me.data.forEach(function(item){
                    if (!me.isRowSelected[item[me.col[0]]]){
                        me.isRowSelected[item[me.col[0]]] = false;
                    }
                }),
                setTimeout(function(){
                        me.updateStatusCombobox();
                }, 100);
            }
        },
        // xử lí giá trị dầu vào
        'defaultValue':function(){
            let me = this,
                defaultObj = JSON.parse(me.defaultValue);
            if (defaultObj){

                defaultObj.forEach(function(item){
                    me.isRowSelected[item[me.col[0]]] = true;
                    me.isResultNull = false;
                })
            }
        }
    },
}
</script>
<style scoped>
    .combobox-component-container{
        font-size: 13px;
        position: relative;
        width: 100%;
        min-height: 32px;
        max-height: 62px;
        border-radius: 4px;
        border: 1px solid #D3D7DE;
        cursor: pointer;
        display: flex;
        align-items: center;
        justify-content: center;
        box-sizing: border-box;
        outline: none;
    }
    .combobox-component-container:focus{
        border-color: #4262F0;
    }
    .combobox-component-defalt{
        width: 100%;
        height: 32px;
        display: flex;
        align-items: center;
        padding-left: 12px;
    }
    .combobox-component-box{
        overflow-y: auto;
        width: 100%;
        min-height: 32px;
        max-height: 62px;
        display: flex;
        flex-wrap: wrap;
        align-items: center;
        padding: 3px 8px 3px 16px;
    }
    .combobox-component-tag{
        background-color: #E2E4E9;
        border-radius: 3px;
        padding: 0 8px;
        height: 22px;
        display: flex;
        align-items: center;
        margin: 2px 4px 2px 0;
    }
    .combobox-component-tag-delete-icon-box{
        width: 17px;
        height: 17px;
        border-radius: 50%;
        display: flex;
        align-items: center;
        justify-content: center;
        margin-left: 8px;
    }
    .combobox-component-tag-delete-icon-box:hover{
        background-color: #fff;
    }
    .combobox-component-tag-delete-icon{
        width: 10px;
        height: 10px;
        background: url("../../assets/img/icon_collection.svg") no-repeat -67px -19px;
    }
    .combobox-component-item-box{
        width: 100%;
        padding: 8px 0;
        position: absolute;
        z-index: 11;
        top: 110%;
        left: 0;
        background-color: #fff;
        max-height: 144px;
        border-radius: 4px;
        box-shadow: 0 3px 6px rgba(0, 0, 0, 0.5);
        overflow: auto;
        animation: growDown 200ms ease-in-out forwards;
    }
    @keyframes growDown {
        0% {
        transform: scaleY(0)
        }
        80% {
        transform: scaleY(1.1)
        }
        100% {
        transform: scaleY(1)
        }
    }
    .combobox-component-item{
        height: 32px;
        padding: 0 12px;
        display: flex;
        align-items: center;
        justify-content: space-between;
        cursor: pointer;
    }
    .combobox-component-item:hover{
        background-color: #ddd;
    }
    .combobox-component-item-icon{
        width: 16px;
        height: 16px;
        background: url("../../assets/img/icon_collection.svg") no-repeat -208px -257px;
    }

    /* class màu cho dòng được chọn  */
    .combobox-component-item-content-selected{
        color: #4262F0;
    }
</style>