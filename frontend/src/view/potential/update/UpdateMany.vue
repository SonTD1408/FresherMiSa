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
                    <SelectInput :data="dbColumns" :col="{0: 'Column', 1: 'ColumnName'}" :variable="'ColumnName'" @emitValue = "getDataFromSelectInput"></SelectInput>
                </div>
                <div class="umcc-input-content">
                    <input type="text" class="s-input" style="width: 100%" disabled v-if="typeOfInput==0">
                    <input type="text" class="s-input" style="width: 100%" v-if="typeOfInput==1" v-model="formData.ColumnValue">
                    <SelectInput :data="dataOfSelectInput" :col="col" :variable="'ColumnValue'" @emitValue = "getDataFromSelectInput" v-if="typeOfInput==2"></SelectInput>
                </div>
            </div>
            <div class="umc-footer">
                <button class="s-button-gray" @click="closeOnClick">Hủy bỏ</button>
                <button class="s-button" @click="update">Cập nhật</button>
            </div>
        </div>
    </div>
</template>

<script>
import axiosConfig from "../../../script/config/axiosConfig.js"
import SelectInput from "../../../components/common/SelectInput.vue";
export default {
    components:{
    SelectInput
},
    props: {
        isShow: Boolean,
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
                    Column: "FullName",
                    ColumnName: "Họ và tên"
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
                    Column: "TaxCode",
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
                {
                    Column: "NationID",
                    ColumnName: "Quốc gia"
                },
                {
                    Column: "CityID",
                    ColumnName: "Thành phố/Tỉnh"
                },
                {
                    Column: "DistrictID",
                    ColumnName: "Quận/Huyện"
                },
                {
                    Column: "WardID",
                    ColumnName: "Phường/Xã"
                },
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
                    Column: "Gender",
                    ColumnName: "Giới tính"
                },
                {
                    Column: "DateOfBirth",
                    ColumnName: "Ngày sinh"
                },
                {
                    Column: "Facebook",
                    ColumnName: "Facebook"
                },
                {
                    Column: "IsShare",
                    ColumnName: "Dùng chung"
                },
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
            ],
            // data để đưa về lưu tại server 
            formData: {
                ColumnName: "",
                ColumnValue: "",
            },
            // check xem ở ô nhập value là loại input nào 
            typeOfInput: 0,
            // data khi chọn update cột có value là loại input chọn
            dataOfSelectInput: {},
            // tên các cột trong dataOfSelectInput
            col: {},
        }
    },
    methods: {
        /**
         * hàm gọi khi bấm hủy 
         * created by SONTD (06.08.2022)
         */
        closeOnClick(){
            this.$emit("hideShowStatus",false);
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
                else if (me.formData.ColumnName == "SourceID"){url = axiosConfig.Sources}
                else if (me.formData.ColumnName == "DepartmentID"){url = axiosConfig.Departments}
                else if (me.formData.ColumnName == "PositionID"){url = axiosConfig.Positions}
                else if (me.formData.ColumnName == "OrganizationTypeID"){url = axiosConfig.OrganizationTypes}
                else if (me.formData.ColumnName == "TurnoverID"){url = axiosConfig.Turnovers}
    
                axiosConfig.call("get",url,"",function(response){
                    console.log(response.data.Status);
                    if (response.data.Status!=0){
                        me.dataOfSelectInput = response.data.DataList;
                    }
                })
            }catch(error){
                console.log(error);
            }
        },

        update(){
            let me = this;
            console.log(me.formData);
        }
    },
    created(){
    },
}
</script>
<style scoped>
@import url("../../../style/view/potential/update/updateMany.css");
</style>