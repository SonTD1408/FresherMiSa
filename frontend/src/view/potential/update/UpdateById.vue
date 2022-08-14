<template>
    <div id="potential-content-update">
        <div id="update-topbar">
            <div class="add-topbar-left">
                <div class="al-txt1">Sửa Tiềm năng </div>
                <div class="al-change-construct">Sửa bố cục</div>
            </div>
            <div class="add-topbar-right">
                <router-link to="/"><button class="s-button-gray">Hủy bỏ</button></router-link>
                <button class="s-button-gray">Lưu và thêm</button>
                <button class="s-button" @click="saveButtonOnClick">Lưu</button>
            </div>
      </div>
    </div>
    <div id="update-main-content">
        <div class="add-main-content-img-box">
            <div class="add-section-title">Ảnh tiềm năng</div>
            <div class="aimgb-img-box">
                <div class="aimgb-img"></div>
            </div>
        </div>
        <div class="add-main-content-infor-box">
            <div class="add-section-title">Thông tin chung</div>
            <div class="add-items">
                <div class="add-items-site">
                <div class="add-item">
                    <div class="aib-txt">Xưng hô</div>
                    <div class="add-select-feild">
                    <SelectInput :col="{0:'VocativeID', 1: 'VocativeName'}" :data="vocatives" :variable="'VocativeID'" @emitValue="getValueSelectInput"/>
                    </div>
                </div>
                <div class="add-item">
                    <div class="aib-txt">Tên <span style="color: red">*</span></div>
                    <input
                    FieldSet="FirstName"
                    class="add-input-feild s-input"
                    v-model="Potential['FirstName']"
                    @blur="validateRequired($event)"
                    />
                </div>
                <div class="validate-error" v-if="validate.required.FirstName==0">Tên không được để trống</div>
                <div class="add-item">
                    <div class="aib-txt">Phòng ban</div>
                    <div class="add-select-feild">
                    <SelectInput :col="{0:'DepartmentID',1:'DepartmentName'}" :data="departments"  :variable="'DepartmentID'" @emitValue="getValueSelectInput"/>
                    </div>
                </div>
                <div class="add-item">
                    <div class="aib-txt">ĐT di động <div class="add-item-icon"></div></div>
                    <input
                    v-model="Potential['PhoneNumber']"
                    FieldSet="PhoneNumber"
                    class="add-input-feild s-input"
                    />
                </div>
                <div class="add-item">
                    <div class="aib-txt">ĐT khác <div class="add-item-icon"></div></div>
                    <input
                    v-model="Potential['OtherPhoneNumber']"
                    FieldSet="OtherPhoneNumber"
                    class="add-input-feild s-input"
                    />
                </div>
                <div class="add-item">
                    <div class="aib-txt">Nguồn gốc</div>
                    <div class="add-select-feild">
                    <SelectInput  :data="sources" @emitValue="getValueSelectInput" :col="{0:'SourceID', 1: 'SourceName'}" :variable="'SourceID'"/>
                    </div>
                </div>
                <div class="add-item">
                    <div class="aib-txt">Không gửi Email</div>
                    <input
                    type="checkbox"
                    v-model="Potential['IsSendEmail']"
                    FieldSet="IsSendEmail"
                    class="update-input-checkbox"
                    />
                </div>
                <div class="add-item">
                    <div class="aib-txt">Zalo</div>
                    <input
                    v-model="Potential['Zalo']"
                    FieldSet="Zalo"
                    class="add-input-feild s-input"
                    />
                </div>
                
                <div class="add-item">
                    <div class="aib-txt">Email cơ quan</div>
                    <input
                    FieldSet="OfficeEmail"
                    class="add-input-feild s-input"
                    v-model = "Potential['OfficeEmail']"
                    />
                </div>
                <div class="add-item">
                    <div class="aib-txt">Mã số thuế</div>
                    <input
                    FieldSet="TaxCode"
                    class="add-input-feild s-input"
                    v-model="Potential['TaxCode']"
                    />
                </div>
                </div>
                <div class="add-items-site">
                <div class="add-item">
                    <div class="aib-txt">Họ và tên đệm</div>
                    <input class="add-input-feild s-input" 
                    v-model="Potential['LastName']"
                    FieldSet="LastName"/>
                </div>
                <div class="add-item">
                    <div class="aib-txt">Họ và tên</div>
                    <input class="add-input-feild s-input" 
                    FieldSet="FullName"
                    disabled 
                    v-bind:value="(Potential['LastName']!=undefined? Potential['LastName']:'')+' '+(Potential['FirstName']!=undefined? Potential['FirstName']:'')"
                    />
                </div>
                <div class="add-item">
                    <div class="aib-txt">Chức danh</div>
                    <div class="add-select-feild">
                    <SelectInput :col="{0:'PositionID', 1: 'PositionName'}" :data="positions" :variable="'PositionID'" @emitValue="getValueSelectInput"/>
                    </div>
                </div>
                <div class="add-item">
                    <div class="aib-txt">ĐT cơ quan <div class="add-item-icon"></div></div>
                    <input
                    v-model="Potential['OfficePhoneNumber']"
                    FieldSet = "OfficePhoneNumber"
                    class="add-input-feild s-input"
                    />
                </div>
                <div class="add-item">
                    <div class="aib-txt">Loại tiềm năng</div>
                    <input
                    v-model = "Potential['PotentialType']"
                    FieldSet="PotentialType"
                    class="add-input-feild s-input"
                    />
                </div>
                <div class="add-item">
                    <div class="aib-txt">Không gọi điện</div>
                    <input
                    type="checkbox"
                    v-model = "Potential['IsCall']"
                    FieldSet="IsCall"
                    class="update-input-checkbox"
                    />
                </div>
                <div class="add-item">
                    <div class="aib-txt">Email cá nhân</div>
                    <input
                    v-model="Potential['Email']"
                    FieldSet="Email"
                    class="add-input-feild s-input"
                    />
                </div>
                <div class="add-item">
                    <div class="aib-txt">Tổ chức</div>
                    <input
                    v-model="Potential['Organization']"
                    FieldSet="Organization"
                    class="add-input-feild s-input"
                    />
                </div>
                </div>
            </div>
        </div>
        <div class="add-main-content-personal-infor">
            <div class="add-section-title">Thông tin cá nhân</div>
            <div class="add-items">
                <div class="add-items-site">
                    <div class="add-item">
                        <div class="aib-txt">Giới tính</div>
                        <div class="add-select-feild">
                            <SelectInput :col="{0:'Gender', 1: 'GenderName'}" :data="genders" :variable="'Gender'" @emitValue="getValueSelectInput"/>
                        </div>
                    </div>
                    <div class="add-item">
                        <div class="aib-txt">Facebook</div>
                        <input class="add-input-feild s-input" 
                        FieldSet="Facebook"
                        v-model="Potential['Facebook']"/>
                    </div>
                </div>
                <div class="add-items-site">
                    <div class="add-item">
                        <div class="aib-txt">Ngày sinh</div>
                        <input class="add-input-feild s-input" 
                        type="date"
                        FieldSet="DateOfBirth"
                        v-model="Potential['DateOfBirth']"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import axiosConfig from '@/script/config/axiosConfig';
import Resource from "../../../script/resource.js";
import SelectInput from "../../../components/common/SelectInput.vue";
export default {
    emits: ["showToastMessage"],
    components: {
        SelectInput
    },
    data() {
        return {
            // biến lưu thông tin về tiềm năng để gửi về server 
            Potential: {},
            // biến lưu thông tin validate 
            validate:{
                required: {
                    FirstName : -1,
                }
            },
            // dữ liệu xưng hô 
            vocatives: {},
            // dữ liệu lấy từ bảng chưc danh 
            positions: {},
            // dữ liệu lấy từ bảng phòng ban
            departments: {},
            // dữ liệu lấy từ bảng nguồn gốc 
            sources: {},
            // dữ liệu giới tính
            genders: Resource.Gender,
        }
    },
    methods: {
        /**
         * hàm khởi tạo lấy các giá trị cho ô select input
         * created by SONTD(14.08.2022)
         */
        init(){
            let me = this;
            try{
                // lấy dữ liệu vocative
                axiosConfig.call("get", axiosConfig.Vocatives, "", function(response){
                    if (response.data){
                        me.vocatives = response.data.DataList;
                    }
                });
                // lây dữ liệu phòng ban 
                axiosConfig.call("get", axiosConfig.Departments, "", function(response){
                    if (response.data){
                        me.departments = response.data.DataList;
                    }
                });
                // lấy dữ liệu chức vụ
                axiosConfig.call("get", axiosConfig.Positions, "", function(response){
                    if (response.data){
                        me.positions = response.data.DataList;
                    }
                });
                // lấy dữ liệu nguồn gốc
                axiosConfig.call("get", axiosConfig.Sources, "", function(response){
                    if (response.data){
                        me.sources = response.data.DataList;
                    }
                });
            }catch(error){
                console.log(error);
            }
        },

        /**
         * check validate của các hàng có blur validateRequire()
         * created by SONTD(14.08.2022)
         */
        validateRequired(event){
            let me = this;
            if (!event.target.value){
                event.target.classList.add("input-validate-error");
                me.validate.required[event.target.getAttribute("FieldSet")] = 0;
            }else{
                event.target.classList.remove("input-validate-error");
                me.validate.required[event.target.getAttribute("FieldSet")] = 1;
            }
        },

        /**
         * hàm thực hiện khi ấn nút lưu
         * created by SONTD (14.08.2022)
         */
        saveButtonOnClick(){
            let me =this;
            me.$emit("showToastMessage",3);
            console.log(me.Potential);
        },

        /**
         * lấy gia trị từ select input component
         * createdby SONTD (14.08.2022)
         * @param {*} val 
         * @param {*} variable 
         */
        getValueSelectInput(val, variable){
            let me = this;
            me.Potential[variable] = val;
        },
    },
    created() {
        let me = this;
        me.init();
    },
}
</script>
<style scoped>
    @import url("../../../style/view/potential/update/updateTopbar.css");
    @import url("../../../style/view/potential/update/updateMainContent.css")
</style>