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
                    <SelectInput :data="dbColumns" :col="{0: 'Column', 1: 'ColumnName'}" :variable="'ColumnName'" @emitValue = "getDataFromSelectInput" :defaultValue="formData.ColumnName"></SelectInput>
                </div>
                <div class="umcc-input-content">
                    <input type="text" class="s-input" style="width: 100%" disabled v-if="typeOfInput==0">
                    <input type="text" class="s-input" style="width: 100%" v-if="typeOfInput==1" v-model="formData.ColumnValueString">
                    <SelectInput :data="dataOfSelectInput" :col="col" :variable="'ColumnValueString'" @emitValue = "getDataFromSelectInput" v-if="typeOfInput==2"></SelectInput>
                    <el-date-picker
                        v-if="typeOfInput==3"
                        v-model="formData.ColumnValueString"
                        type="date"
                        format="DD/MM/YYYY"
                        value-format="YYYY-MM-DD"
                        placeholder="DD/MM/YYYY"
                        size="default"
                        style="width: 100%"
                    /> 
                    <ComboboxComponent v-if="typeOfInput==4" :data="dataOfSelectInput" :col="col" :variable="'ColumnValue'+formData.ColumnName" @emitComboboxValue="getValueFromCombobox"/>
                    <input type="checkbox" style="width: 16px; height: 16px;" v-if="typeOfInput==5" isChecked="false" @click="multiUpdateCheckBoxOnClick"/>
                </div>
            </div>
            <div class="umc-footer">
                <button class="s-button-gray" @click="closeOnClick">Hủy bỏ</button>
                <button class="s-button" @click="update" v-if="isActiveUpdateButton">Cập nhật</button>
                <button class="s-button" style="background-color: #B7C3F9" v-if="!isActiveUpdateButton">Cập nhật</button>
            </div>
        </div>
    </div>
</template>

<script>
import axiosConfig from "../../../script/config/axiosConfig.js"
import SelectInput from "../../../components/common/SelectInput.vue";
import Resource from "../../../script/resource.js"
import ComboboxComponent from "../../../components/common/ComboboxComponent.vue"
export default {
    components:{
        SelectInput,
        ComboboxComponent
    },
    props: {
        // biến ẩn hiện compontent 
        isShow: Boolean,
        // lưu mảng các id của những bản ghi cần update 
        idList: Array,
    },
    data() {
        return {
            // cột được dùng để cho vào ô chọn cột dể update 
            dbColumns: [
                {
                    Column: "PotentialCode",
                    ColumnName: "Mã tiềm năng"
                },
                {
                    Column: "LastName",
                    ColumnName: "Họ và đệm"
                },
                {
                    Column: "FirstName",
                    ColumnName: "Tên"
                },
                {
                    Column: "PhoneNumber",
                    ColumnName: "SĐT cá nhân"
                },
                {
                    Column: "OfficePhoneNumber",
                    ColumnName: "SĐT cơ quan"
                },
                {
                    Column: "OtherPhoneNumber",
                    ColumnName: "SĐT khác"
                },
                {
                    Column: "Email",
                    ColumnName: "Email cá nhân"
                },
                {
                    Column: "OfficeEmail",
                    ColumnName: "Email cơ quan"
                },
                {
                    Column: "Taxcode",
                    ColumnName: "Mã số thuế"
                },
                {
                    Column: "Zalo",
                    ColumnName: "Zalo"
                },
                {
                    Column: "BankAccount",
                    ColumnName: "Tài khoản ngân hàng"
                },
                {
                    Column: "BankName",
                    ColumnName: "Tên ngân hàng"
                },
                {
                    Column: "FoundingDate",
                    ColumnName: "Ngày thành lập"
                },
                // {
                //     Column: "NationID",
                //     ColumnName: "Quốc gia"
                // },
                // {
                //     Column: "CityID",
                //     ColumnName: "Thành phố/Tỉnh"
                // },
                // {
                //     Column: "DistrictID",
                //     ColumnName: "Quận/Huyện"
                // },
                // {
                //     Column: "WardID",
                //     ColumnName: "Phường/Xã"
                // },
                {
                    Column: "ApartmentNumber",
                    ColumnName: "Số nhà"
                },
                {
                    Column: "RegionCode",
                    ColumnName: "Mã vùng"
                },
                {
                    Column: "PotentialDescription",
                    ColumnName: "Mô tả"
                },
                {
                    Column: "IsCall",
                    ColumnName: "Cho phép gọi"
                },
                {
                    Column: "IsSendEmail",
                    ColumnName: "Cho phép gửi Email"
                },
                {
                    Column: "DateOfBirth",
                    ColumnName: "Ngày sinh"
                },
                {
                    Column: "Facebook",
                    ColumnName: "Facebook"
                },
                // {
                //     Column: "IsShare",
                //     ColumnName: "Dùng chung"
                // },
                {
                    Column: "VocativeID",
                    ColumnName: "Xưng hô"
                },
                {
                    Column: "DepartmentID",
                    ColumnName: "Phòng ban"
                },
                {
                    Column: "PositionID",
                    ColumnName: "Chức vụ"
                },
                {
                    Column: "SourceID",
                    ColumnName: "Nguồn gốc"
                },
                {
                    Column: "OrganizationTypeID",
                    ColumnName: "Loại hình tổ chức"
                },
                {
                    Column: "TurnoverID",
                    ColumnName: "Doanh thu"
                },
                {
                    Column: "Organization",
                    ColumnName: "Tổ chức"
                },
                {
                    Column: "Address",
                    ColumnName: "Địa chỉ"
                },
                {
                    Column: "Careers",
                    ColumnName: "Nghề nghiệp"
                },
                {
                    Column: "Fields",
                    ColumnName: "Lĩnh vực"
                },
                {
                    Column: "PotentialTypes",
                    ColumnName: "Loại tiềm năng"
                },
            ],
            // data để đưa về lưu tại server 
            formData: {
                ColumnName: "",
                ColumnValueString: "",
            },
            formDatadefault: {
                ColumnName: "",
                ColumnValueString: "",
            },
            // check xem ở ô nhập value là loại input nào 
                // 0: disable
                // 1: input field
                // 2: dropdown
                // 3: date
                // 4: dropdown
            typeOfInput: 0,
            // data khi chọn update cột có value là loại input chọn
            dataOfSelectInput: {},
            // tên các cột trong dataOfSelectInput
            col: {},
            // kiểu của select input trả về là string hay int
            typeOfSelectInput: "",
            // đánh dâu xem có active button update hay không
            isActiveUpdateButton: false,
        }
    },
    methods: {
        /**
         * hàm gọi khi bấm hủy 
         * created by SONTD (06.08.2022)
         */
        closeOnClick(){
            this.$emit("hideShowStatus",false);
            this.typeOfInput = 0;
            this.formData.ColumnName = "";
            this.formData.ColumnValueString="";
        },

        /**
         * hàm lấy data từ ô loại column, xem mình update cột nào
         * created by SONTD(15.08.2022)
         */
        getDataFromSelectInput(value, variable){
            let me = this;
            me.formData[variable]=value;
            me.getTypeOfInput();
        },

        /**
         * lấy giá trị từ combobox component
         * created by SONTD(20.08.2022)
         */
        getValueFromCombobox(variable, val){
        this.formData[variable] =val;
        },

        /**
         * hàm set type cho input :
         * 0 là disabled
         * 1 lầ input text
         * 2 là input select
         * created by SonTD (15.08.2022)
         */
        getTypeOfInput(){
            let me =this;
            if (me.formData.ColumnName=="" || me.formData.ColumnName==null){
                me.typeOfInput = 0;
            }
            else if (me.formData.ColumnName == "VocativeID"
                        || me.formData.ColumnName == "DepartmentID"
                        || me.formData.ColumnName == "PositionID"
                        || me.formData.ColumnName == "SourceID"
                        || me.formData.ColumnName == "OrganizationTypeID"
                        || me.formData.ColumnName == "TurnoverID"){
                me.typeOfInput =2;
                me.getDataForColumnValue();
            }
            else if(me.formData.ColumnName == "FoundingDate"
                    || me.formData.ColumnName == "DateOfBirth"){
                me.typeOfInput = 3;
            }
            else if(me.formData.ColumnName == "Fields" 
                    || me.formData.ColumnName == "Careers"
                    || me.formData.ColumnName == "PotentialTypes"){
                me.typeOfInput = 4;
                me.getDataForColumnValue();
            }else if(me.formData.ColumnName == "IsSendEmail"
                    || me.formData.ColumnName == "IsCall"){
                me.typeOfInput = 5;
            }
            else{
                me.typeOfInput =1;
            }
        },

        /**
         * lấy data cho ColumnValue khi chọn update cột có giá trị selectinput
         * created by SONTD(15.08.2022)
         */
        getDataForColumnValue(){
            let me = this,
                url = "";
            try{
                if (me.formData.ColumnName == "VocativeID"){url = axiosConfig.Vocatives; me.col[0]='VocativeID'; me.col[1]='VocativeName'}
                else if (me.formData.ColumnName == "SourceID"){url = axiosConfig.Sources; me.col[0]='SourceID'; me.col[1]='SourceName'}
                else if (me.formData.ColumnName == "DepartmentID"){url = axiosConfig.Departments; me.col[0]='DepartmentID'; me.col[1]='DepartmentName'}
                else if (me.formData.ColumnName == "PositionID"){url = axiosConfig.Positions; me.col[0]='PositionID'; me.col[1]='PositionName'}
                else if (me.formData.ColumnName == "OrganizationTypeID"){url = axiosConfig.OrganizationTypes; me.col[0]='OrganizationTypeID'; me.col[1]='OrganizationTypeName'}
                else if (me.formData.ColumnName == "TurnoverID"){url = axiosConfig.Turnovers; me.col[0]='TurnoverID'; me.col[1]='TurnoverName'}
                else if (me.formData.ColumnName == "Careers"){url = axiosConfig.Careers; me.col[0]='CareerID'; me.col[1]='CareerName'}
                else if (me.formData.ColumnName == "Fields"){url = axiosConfig.Fields; me.col[0]='FieldID', me.col[1]='FieldName'}
                else if (me.formData.ColumnName == "PotentialTypes"){url = axiosConfig.PotentialTypes; me.col[0]='PotentialTypeID', me.col[1]='PotentialTypeName'}
    
                axiosConfig.call("get",url,"",function(response){
                    if (response.data.Status!=0){
                        me.dataOfSelectInput = response.data.DataList;
                    }
                })
            }catch(error){
                console.log(error);
            }
        },

        /**
         * hàm sự kiện khi bấm vào nút update
         * created by SONTD(18.08.2022)
         */
        update(){
            let me = this;
            me.formData.ListPotentialID = me.idList;
            try{
                axiosConfig.call("put",axiosConfig.Potentials,me.formData,function(response){
                    if (response.data.Status && response.data.Status == Resource.ResponseStatus.SuccessData){
                        me.$emit("confirmMultiUpdate",true);
                    }else{
                        me.$emit("confirmMultiUpdate",false);
                    }
                })
            }catch(error){
                me.$emit("confirmMultiUpdate",false);
                console.log(error);
            }
            me.formData = me.formDatadefault;
            me.typeOfInput=0;
        },

        /**
         * cập nhập giá trị của column value khi ấn check box
         * created by SONTD(10.09.2022)
         */
        multiUpdateCheckBoxOnClick(event){
            let me = this;
            if(event.target.getAttribute("isChecked") == "true"){
                me.formData.ColumnValueNumber = 0;
                event.target.setAttribute("isChecked","false");
            }else{
                me.formData.ColumnValueNumber = 1;
                event.target.setAttribute("isChecked","true");
            }
        }
    },
    watch:{
        'formData.ColumnName':function(newValue){
            if(newValue){
                this.isActiveUpdateButton = true;
            }else{
                this.isActiveUpdateButton = false;
            }
        },
    }
}
</script>
<style scoped>
@import url("../../../style/view/potential/update/updateMany.css");
</style>