<template>
    <div id="potential-content-update">
        <div id="update-topbar">
            <div class="update-topbar-left">
                <div class="ul-txt1">Sửa Tiềm năng </div>
                <div class="ul-change-construct">Sửa bố cục</div>
            </div>
            <div class="update-topbar-right">
                <router-link to="/"><button class="s-button-gray">Hủy bỏ</button></router-link>
                <button class="s-button-gray">Lưu và thêm</button>
                <button class="s-button" @click="saveButtonOnClick">Lưu</button>
            </div>
      </div>
    </div>
    <div id="update-main-content">
        <div class="update-main-content-img-box">
            <div class="update-section-title">Ảnh tiềm năng</div>
            <div class="uimgb-img-box">
                <div class="uimgb-img"></div>
            </div>
        </div>
        <div class="update-main-content-infor-box">
            <div class="update-section-title">Thông tin chung</div>
            <div class="update-items">
                <div class="update-items-site">
                <div class="update-item">
                    <div class="uib-txt">Xưng hô</div>
                    <div class="update-select-feild">
                    <SelectInput :col="{0:'VocativeID', 1: 'VocativeName'}" :data="vocatives" :variable="'VocativeID'" @emitValue="getValueSelectInput"/>
                    </div>
                </div>
                <div class="update-item">
                    <div class="uib-txt">Tên <span style="color: red">*</span></div>
                    <input
                    FieldSet="FirstName"
                    class="update-input-feild s-input"
                    v-model="Potential['FirstName']"
                    @blur="validateRequired($event)"
                    />
                </div>
                <div class="validate-error" v-if="validate.required.FirstName==0">Tên không được để trống</div>
                <div class="update-item">
                    <div class="uib-txt">Phòng ban</div>
                    <div class="update-select-feild">
                    <SelectInput :col="{0:'DepartmentID',1:'DepartmentName'}" :data="departments"  :variable="'DepartmentID'" @emitValue="getValueSelectInput"/>
                    </div>
                </div>
                <div class="update-item">
                    <div class="uib-txt">ĐT di động <div class="update-item-icon"></div></div>
                    <input
                    v-model="Potential['PhoneNumber']"
                    FieldSet="PhoneNumber"
                    class="update-input-feild s-input"
                    />
                </div>
                <div class="update-item">
                    <div class="uib-txt">ĐT khác <div class="update-item-icon"></div></div>
                    <input
                    v-model="Potential['OtherPhoneNumber']"
                    FieldSet="OtherPhoneNumber"
                    class="update-input-feild s-input"
                    />
                </div>
                <div class="update-item">
                    <div class="uib-txt">Nguồn gốc</div>
                    <div class="update-select-feild">
                    <SelectInput  :data="sources" @emitValue="getValueSelectInput" :col="{0:'SourceID', 1: 'SourceName'}" :variable="'SourceID'"/>
                    </div>
                </div>
                <div class="update-item">
                    <div class="uib-txt">Không gửi Email</div>
                    <input
                    type="checkbox"
                    v-model="Potential['IsSendEmail']"
                    FieldSet="IsSendEmail"
                    class="update-input-checkbox"
                    />
                </div>
                <div class="update-item">
                    <div class="uib-txt">Zalo</div>
                    <input
                    v-model="Potential['Zalo']"
                    FieldSet="Zalo"
                    class="update-input-feild s-input"
                    />
                </div>
                
                <div class="update-item">
                    <div class="uib-txt">Email cơ quan</div>
                    <input
                    FieldSet="OfficeEmail"
                    class="update-input-feild s-input"
                    v-model = "Potential['OfficeEmail']"
                    />
                </div>
                <div class="update-item">
                    <div class="uib-txt">Mã số thuế</div>
                    <input
                    FieldSet="TaxCode"
                    class="update-input-feild s-input"
                    v-model="Potential['TaxCode']"
                    />
                </div>
                </div>
                <div class="update-items-site">
                <div class="update-item">
                    <div class="uib-txt">Họ và tên đệm</div>
                    <input class="update-input-feild s-input" 
                    v-model="Potential['LastName']"
                    FieldSet="LastName"/>
                </div>
                <div class="update-item">
                    <div class="uib-txt">Họ và tên</div>
                    <input class="update-input-feild s-input" 
                    FieldSet="FullName"
                    disabled 
                    v-bind:value="(Potential['LastName']!=undefined? Potential['LastName']:'')+' '+(Potential['FirstName']!=undefined? Potential['FirstName']:'')"
                    />
                </div>
                <div class="update-item">
                    <div class="uib-txt">Chức danh</div>
                    <div class="update-select-feild">
                    <SelectInput :col="{0:'PositionID', 1: 'PositionName'}" :data="positions" :variable="'PositionID'" @emitValue="getValueSelectInput"/>
                    </div>
                </div>
                <div class="update-item">
                    <div class="uib-txt">ĐT cơ quan <div class="update-item-icon"></div></div>
                    <input
                    v-model="Potential['OfficePhoneNumber']"
                    FieldSet = "OfficePhoneNumber"
                    class="update-input-feild s-input"
                    />
                </div>
                <div class="update-item">
                    <div class="uib-txt">Loại tiềm năng</div>
                    <input
                    v-model = "Potential['PotentialType']"
                    FieldSet="PotentialType"
                    class="update-input-feild s-input"
                    />
                </div>
                <div class="update-item">
                    <div class="uib-txt">Không gọi điện</div>
                    <input
                    type="checkbox"
                    v-model = "Potential['IsCall']"
                    FieldSet="IsCall"
                    class="update-input-checkbox"
                    />
                </div>
                <div class="update-item">
                    <div class="uib-txt">Email cá nhân</div>
                    <input
                    v-model="Potential['Email']"
                    FieldSet="Email"
                    class="update-input-feild s-input"
                    />
                </div>
                <div class="update-item">
                    <div class="uib-txt">Tổ chức</div>
                    <input
                    v-model="Potential['Organization']"
                    FieldSet="Organization"
                    class="update-input-feild s-input"
                    />
                </div>
                </div>
            </div>
        </div>
        <div class="add-main-content-personal-infor">
            <div class="add-section-title">Thông tin cá nhân</div>
            <div class="update-items">
                <div class="update-items-site">
                    <div class="update-item">
                        <div class="uib-txt">Giới tính</div>
                        <div class="update-select-feild">
                            <SelectInput :col="{0:'Gender', 1: 'GenderName'}" :data="genders" :variable="'Gender'" @emitValue="getValueSelectInput"/>
                        </div>
                    </div>
                    <div class="update-item">
                        <div class="uib-txt">Facebook</div>
                        <input class="update-input-feild s-input" 
                        FieldSet="Facebook"
                        v-model="Potential['Facebook']"/>
                    </div>
                </div>
                <div class="update-items-site">
                    <div class="update-item">
                        <div class="uib-txt">Ngày sinh</div>
                        <input class="update-input-feild s-input" 
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
    props: {
        PotentialID: String,
    },
    data() {
        return {
            // biến lưu thông tin id của dòng đã chọn để sửa 
            idRow: "",
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
                let getPotentialByIdUrl= "/" + me.idRow;
            try{
                // lấy tiềm năng bằng id từ server
                axiosConfig.call("get", axiosConfig.Potentials+getPotentialByIdUrl, "", function(response){
                    console.log(response);
                    if (response.data.Status==2){
                        me.Potential = response.data.Data;
                        console.log(me.Potential);
                    }
                })
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
         * trức khi lưu check lại xem có hàng nào dính validate không, nếu có thì chưa được lưu
         * created by SONTD (12.08.2022)
         */
        checkValidate(){
            let me = this;
            for (let key in me.validate.required){
                if (me.validate.required[key]==0 || me.validate.required[key]==-1 ||me.validate.required[key]==undefined){
                    document.querySelector(`[FieldSet=${key}]`).classList.add("input-validate-error");
                    document.querySelector(`[FieldSet=${key}]`).focus();
                    me.validate.required[key]=0;
                    return false;
                }else{
                    document.querySelector(`[FieldSet=${key}]`).classList.remove("input-validate-error");
                }
            }
            return true;
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
            let me =this,
                val = me.checkValidate();
            if (val){
                try {
                    let url = "/" + me.idRow;
                    axiosConfig.call("put", axiosConfig.Potentials + url, me.Potential, function(response){
                        console.log(response);
                        if (response.data.Status!=0){
                            me.$router.push({path: "/"});
                            me.$emit("showToastMessage",3);
                        }else{
                            me.$emit("showToastMessage",4);
                        }
                    })
                } catch (error) {
                    console.log(error);
                }
            }
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
        // lấy id của tiềm năng từ url
        me.idRow = me.$route.query.PotentialID;
        // khởi tạo page lấy data cần thiết từ server
        me.init();
        
    },
}
</script>
<style scoped>
    @import url("../../../style/view/potential/update/updateTopbar.css");
    @import url("../../../style/view/potential/update/updateMainContent.css")
</style>