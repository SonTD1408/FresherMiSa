<template>
    <div id="filterbar-left" v-if="isShowFilterbarLeft" ref="potentialFilter">
        <div class="filter-saved">
            <div class="fs-txt">BỘ LỌC ĐÃ LƯU</div>
            <div class="fs-icon"></div>
        </div>
        <div class="filter-search-box">
            <div class="fsb-container">
                <div class="fsbc-txt">LỌC TIỀM NĂNG THEO</div>
                <div class="fsbc-icon"></div>
            </div>
            <div class="fsb-item-box">
                <div class="fsb-item" v-for="(item,index) in column" :key="index" :indexOfItem="index" @click="filterItemOnClick">
                    <div class="fsb-item-filter-column">
                        <input type="checkbox" class="fsbi-icon" :isChecked="false"  @click="checkboxOnClick">
                        <div class="fsbi-label">{{item.VietnameseName}}</div>
                    </div>
                    <div class="fsb-item-filter-type" v-if="item.isShowFilterType">
                        <SelectInput :data="item.types" :col="{0: 'TypeID', 1: 'TypeName'} " :variable="index.toString()" @emitValue="getValueSelectInput"></SelectInput>
                    </div>
                    <div class="fsb-item-filter-value" v-if="item.isShowFilterValue">
                        <input class="s-input" type="text" v-model="item.ColumnValue"/>
                    </div>
                </div>
                <div class="fsb-item-add" style="height: 52px; background-color: red" v-if="isShowConfirmBox"></div>
            </div>
        </div>
        <div class="fsb-confirm-box" v-if="isShowConfirmBox">
            <button class="s-button-gray" @click="removeFilter">Bỏ lọc</button>
            <button class="s-button" @click="confirmOnClick">Áp dụng</button>
        </div>
      </div>
</template>
<script>
import SelectInput from "../../../components/common/SelectInput.vue";
export default{
    components:{
        SelectInput
    },  
    props:{
        isShowFilterbarLeft: Boolean,
    },
    data() {
        return {
            // tên column
            column: [
                {ColumnName: 'PotentialCode', VietnameseName: 'Mã tiềm năng', ColumnValue: "", isShowFilterType: false, isShowFilterValue: false, types:[{TypeID: 0, TypeName: "Chứa"}, {TypeID: 1, TypeName: "Không chứa"}, {TypeID: 2, TypeName: "Là"}, {TypeID: 3, TypeName:"Không là"}]},
                {ColumnName: 'VocativeName', VietnameseName: 'Xưng hô', ColumnValue: "", isShowFilterType: false, isShowFilterValue: false, types:[{TypeID: 0, TypeName: "Chứa"}, {TypeID: 1, TypeName: "Không chứa"}, {TypeID: 2, TypeName: "Là"}, {TypeID: 3, TypeName:"Không là"}]},
                {ColumnName: 'FullName', VietnameseName: 'Họ và tên', ColumnValue: "", isShowFilterType: false, isShowFilterValue: false, types:[{TypeID: 0, TypeName: "Chứa"}, {TypeID: 1, TypeName: "Không chứa"}, {TypeID: 2, TypeName: "Là"}, {TypeID: 3, TypeName:"Không là"}]},
                {ColumnName: 'PositionName', VietnameseName: 'Thẻ', ColumnValue: "", isShowFilterType: false, isShowFilterValue: false, types:[{TypeID: 0, TypeName: "Chứa"}, {TypeID: 1, TypeName: "Không chứa"}, {TypeID: 2, TypeName: "Là"}, {TypeID: 3, TypeName:"Không là"}]},
                {ColumnName: 'PhoneNumber', VietnameseName: 'ĐT di động', ColumnValue: "", isShowFilterType: false, isShowFilterValue: false, types:[{TypeID: 0, TypeName: "Chứa"}, {TypeID: 1, TypeName: "Không chứa"}, {TypeID: 2, TypeName: "Là"}, {TypeID: 3, TypeName:"Không là"}]},
                {ColumnName: 'OfficePhoneNumber', VietnameseName: 'ĐT cơ quan', ColumnValue: "", isShowFilterType: false, isShowFilterValue: false, types:[{TypeID: 0, TypeName: "Chứa"}, {TypeID: 1, TypeName: "Không chứa"}, {TypeID: 2, TypeName: "Là"}, {TypeID: 3, TypeName:"Không là"}]},
                {ColumnName: 'OfficeEmail', VietnameseName: 'Email cơ quan', ColumnValue: "", isShowFilterType: false, isShowFilterValue: false, types:[{TypeID: 0, TypeName: "Chứa"}, {TypeID: 1, TypeName: "Không chứa"}, {TypeID: 2, TypeName: "Là"}, {TypeID: 3, TypeName:"Không là"}]},
                {ColumnName: 'Email', VietnameseName: 'Email cá nhân', ColumnValue: "", isShowFilterType: false, isShowFilterValue: false, types:[{TypeID: 0, TypeName: "Chứa"}, {TypeID: 1, TypeName: "Không chứa"}, {TypeID: 2, TypeName: "Là"}, {TypeID: 3, TypeName:"Không là"}]},
                {ColumnName: 'Organization', VietnameseName: 'Tổ chức', ColumnValue: "", isShowFilterType: false, isShowFilterValue: false, types:[{TypeID: 0, TypeName: "Chứa"}, {TypeID: 1, TypeName: "Không chứa"}, {TypeID: 2, TypeName: "Là"}, {TypeID: 3, TypeName:"Không là"}]},
                {ColumnName: 'Address', VietnameseName: 'Địa chỉ', ColumnValue: "", isShowFilterType: false, isShowFilterValue: false, types:[{TypeID: 0, TypeName: "Chứa"}, {TypeID: 1, TypeName: "Không chứa"}, {TypeID: 2, TypeName: "Là"}, {TypeID: 3, TypeName:"Không là"}]},
                {ColumnName: 'CityName', VietnameseName: 'Tỉnh/Thành phố', ColumnValue: "", isShowFilterType: false, isShowFilterValue: false, types:[{TypeID: 0, TypeName: "Chứa"}, {TypeID: 1, TypeName: "Không chứa"}, {TypeID: 2, TypeName: "Là"}, {TypeID: 3, TypeName:"Không là"}]},
                {ColumnName: 'DistrictName', VietnameseName: 'Quận/Huyện', ColumnValue: "", isShowFilterType: false, isShowFilterValue: false, types:[{TypeID: 0, TypeName: "Chứa"}, {TypeID: 1, TypeName: "Không chứa"}, {TypeID: 2, TypeName: "Là"}, {TypeID: 3, TypeName:"Không là"}]},
                {ColumnName: 'WardName', VietnameseName: 'Phường/Xã', ColumnValue: "", isShowFilterType: false, isShowFilterValue: false, types:[{TypeID: 0, TypeName: "Chứa"}, {TypeID: 1, TypeName: "Không chứa"}, {TypeID: 2, TypeName: "Là"}, {TypeID: 3, TypeName:"Không là"}]},
                {ColumnName: 'SourceName', VietnameseName: 'Nguồn gốc', ColumnValue: "", isShowFilterType: false, isShowFilterValue: false, types:[{TypeID: 0, TypeName: "Chứa"}, {TypeID: 1, TypeName: "Không chứa"}, {TypeID: 2, TypeName: "Là"}, {TypeID: 3, TypeName:"Không là"}]},
                {ColumnName: 'OrganizationTypeName', VietnameseName: 'Loại hình', ColumnValue: "", isShowFilterType: false, isShowFilterValue: false, types:[{TypeID: 0, TypeName: "Chứa"}, {TypeID: 1, TypeName: "Không chứa"}, {TypeID: 2, TypeName: "Là"}, {TypeID: 3, TypeName:"Không là"}]},
                {ColumnName: 'Fields', VietnameseName: 'Lĩnh vực', ColumnValue: "", isShowFilterType: false, isShowFilterValue: false, types:[{TypeID: 0, TypeName: "Chứa"}, {TypeID: 1, TypeName: "Không chứa"}, {TypeID: 2, TypeName: "Là"}, {TypeID: 3, TypeName:"Không là"}]},
                {ColumnName: 'PotentialDescription', VietnameseName: 'Mô tả', ColumnValue: "", isShowFilterType: false, isShowFilterValue: false, types:[{TypeID: 0, TypeName: "Chứa"}, {TypeID: 1, TypeName: "Không chứa"}, {TypeID: 2, TypeName: "Là"}, {TypeID: 3, TypeName:"Không là"}]},
                {ColumnName: 'no1', VietnameseName: 'Bố cục', ColumnValue: "", isShowFilterType: false, isShowFilterValue: false, types:[{TypeID: 0, TypeName: "Chứa"}, {TypeID: 1, TypeName: "Không chứa"}, {TypeID: 2, TypeName: "Là"}, {TypeID: 3, TypeName:"Không là"}]},
                {ColumnName: 'no2', VietnameseName: 'Chủ sở hữu', ColumnValue: "", isShowFilterType: false, isShowFilterValue: false, types:[{TypeID: 0, TypeName: "Chứa"}, {TypeID: 1, TypeName: "Không chứa"}, {TypeID: 2, TypeName: "Là"}, {TypeID: 3, TypeName:"Không là"}]},
                {ColumnName: 'ComeoverName', VietnameseName: 'Doanh thu', ColumnValue: "", isShowFilterType: false, isShowFilterValue: false, types:[{TypeID: 0, TypeName: "Chứa"}, {TypeID: 1, TypeName: "Không chứa"}, {TypeID: 2, TypeName: "Là"}, {TypeID: 3, TypeName:"Không là"}]},
                {ColumnName: 'IsShare', VietnameseName: 'Dùng chung', ColumnValue: "", isShowFilterType: false, isShowFilterValue: false, types:[{TypeID: 0, TypeName: "Chứa"}, {TypeID: 1, TypeName: "Không chứa"}, {TypeID: 2, TypeName: "Là"}, {TypeID: 3, TypeName:"Không là"}]},
                {ColumnName: 'Facebook', VietnameseName: 'Facebook', ColumnValue: "", isShowFilterType: false, isShowFilterValue: false, types:[{TypeID: 0, TypeName: "Chứa"}, {TypeID: 1, TypeName: "Không chứa"}, {TypeID: 2, TypeName: "Là"}, {TypeID: 3, TypeName:"Không là"}]},
            ],
            // filter value
            filterValue: [
            ],
            // ẩn hiện comfirmbox
            isShowConfirmBox: false,
        }
    },
    methods: {
        /**
         * hàm update trạng thái của filter
         * created by SONTD(28.08.2022)
         */
        updateFilterStatus(){
            let me = this,
                checkShowConfirmBox = false,
            // ẩn hiện ô nhạp loại filter 
                inputs = me.$refs.potentialFilter.querySelectorAll("input[type=checkbox]");
            if (inputs.length > 0){
                inputs.forEach(function(input){
                    let index = input.closest(".fsb-item").getAttribute("indexOfItem");
                    if (input.getAttribute("isChecked")=="true"){
                        me.column[index].isShowFilterType = true;
                    }else{
                        me.column[index].isShowFilterType = false;
                        me.column[index].FilterType = null
                    }
                });
            }
            //ẩn hiện ô nhập value
            me.column.forEach(function(item){
                if (item.FilterType != null && item.FilterType<4 && item.FilterType>=0){
                    item.isShowFilterValue = true;
                    checkShowConfirmBox = true;
                }else{
                    item.isShowFilterValue = false;
                    item.ColumnValue  = "";
                }
            })
            me.isShowConfirmBox = checkShowConfirmBox;
            me.$emit("emitValue", me.column);
        },
        /**
         * hàm sự kiện click vào 1 dòng filter
         * created by SONTD(28.08.2022)
         */
        checkboxOnClick(event){
            let me= this,
                item = event.target;
            if (item && item.getAttribute("ischecked")=='true'){
                item.setAttribute("ischecked",false);
                item.closest(".fsb-item").classList.remove("fsb-item-selected");
            }else{
                item.setAttribute("ischecked",true);
                if (me.$refs.potentialFilter.querySelector(".fsb-item-selected")){
                    me.$refs.potentialFilter.querySelector(".fsb-item-selected").classList.remove("fsb-item-selected");
                }
                item.closest(".fsb-item").classList.add("fsb-item-selected");
            }
            me.updateFilterStatus();
        },

        /**
         * hàm lấy dữ liệu từ ô select input
         * created by SONTD(28.08.2022)
         */
        getValueSelectInput(value, variable){
            let me = this;
            if (value){
                me.column[variable].FilterType = parseInt(value);
            }else{
                me.column[variable].FilterType = null;
            }
            me.updateFilterStatus();
        },

        /**
         * hàm xóa filter 
         * created by SONTD(28.08.2022)
         */
        removeFilter(){
            let me = this,
                filterInput = me.$refs.potentialFilter.querySelectorAll(".fsb-item")
            if (filterInput.length>0 ){
                filterInput.forEach(function(input){
                    if (input.querySelector("input[type=checkbox]").getAttribute("isChecked")=='true'){
                        input.querySelector("input[type=checkbox]").click();
                    }
                })
            }
            me.updateFilterStatus();
            me.$emit("confirmFilterPotential", me.column);
        },

        /**
         * hàm thực hiện khi nhấp nút áp dụng
         * created by SONTD(29.08.200)
         */
        confirmOnClick(){
            let me = this;
            me.$emit("emitValue", me.column);
            me.$emit("confirmFilterPotential", me.column);
        },

        /**
         * hàm thực hiện khi ấn vào 1 dòng trong form filter
         * created by SONTD(30.08.2022)
         */
        filterItemOnClick(event){
            let me  =this;
            if(me.$refs.potentialFilter.querySelector(".fsb-item-selected")){
                me.$refs.potentialFilter.querySelector(".fsb-item-selected").classList.remove("fsb-item-selected");
            }
            if (event.target.closest(".fsb-item")){
                event.target.closest(".fsb-item").classList.add("fsb-item-selected");
            }
        }
    },
}
</script>
<style scoped>
@import url("../../../style/view/potential/show/filterbarLeft.css");
</style>