<template>
  <div id="content-add">
      <div id="add-topbar">
        <div class="add-topbar-left">
          <div class="al-txt1">Thêm Tiềm năng -</div>
          <div class="al-txt2">Mẫu tiêu chuẩn</div>
          <div class="al-change-construct">Sửa bố cục</div>
        </div>
        <div class="add-topbar-right">
          <router-link to="/"><button class="s-button-gray" tabindex="32" @keydown="customTabIndex">Hủy bỏ</button></router-link>
          <button class="s-button-gray" @click="saveAndAddButtonOnClick" tabindex="33" @keydown="customTabIndex">Lưu và thêm</button>
          <button class="s-button" @click="saveButtonOnClick" tabindex="34" @keydown="customTabIndex">Lưu</button>
        </div>
      </div>
      <div id="add-main-content" ref="addMainContentRef">
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
                <div class="add-select-feild" @click="getFieldData('get', axiosConf.Vocatives, 'vocatives')">
                  <SelectInput FieldSet="VocativeID" @keydown="customTabIndex" tabindex="1" :col="{0:'VocativeID', 1: 'VocativeName'}" :data="vocatives" :variable="'VocativeID'" @emitValue="getValueSelectInput" :type="'guid'"/>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Tên <span style="color: red"> *</span></div>
                <input
                  tabindex="3"
                  @keydown="customTabIndex"
                  type="text"
                  FieldSet="FirstName"
                  class="add-input-feild s-input"
                  v-model="dataForm.Potential['FirstName']"
                  :maxlength="maxLengthInput.NameHalf"
                />
              </div>
              <div class="validate-error" v-if="validate.required.FirstName==0">Tên không được để trống</div>
              <div class="add-item">
                <div class="aib-txt">Phòng ban</div>
                <div class="add-select-feild" @click="getFieldData('get', axiosConf.Departments, 'departments')">
                  <SelectInput tabindex="4" @keydown="customTabIndex" :col="{0:'DepartmentID',1:'DepartmentName'}" :data="departments"  :variable="'DepartmentID'" @emitValue="getValueSelectInput" :type="'guid'"/>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">ĐT di động <div class="add-item-icon" @mouseover="tooltip.PhoneNumber = true" @mouseleave="tooltip.PhoneNumber = false"><ToolTip :msg="'Điện thoại di động'" v-if="tooltip.PhoneNumber" @tooltipClickOutside="tooltipClickOutside('PhoneNumber')"></ToolTip></div></div>
                <input
                  tabindex="6"
                  @keydown="customTabIndex"
                  type="text"
                  v-model="dataForm.Potential['PhoneNumber']"
                  FieldSet="PhoneNumber"
                  class="add-input-feild s-input"
                  :maxlength="maxLengthInput.Phone"
                />
              </div>
              <div class="add-item">
                <div class="aib-txt">Nguồn gốc</div>
                <div class="add-select-feild" @click="getFieldData('get', axiosConf.Sources, 'sources')">
                  <SelectInput tabindex="8" @keydown="customTabIndex" :data="sources" @emitValue="getValueSelectInput" :col="{0:'SourceID', 1: 'SourceName'}" :variable="'SourceID'" :type="'guid'"/>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Zalo</div>
                <input
                  tabindex="10"
                  @keydown="customTabIndex"
                  type="text"
                  v-model="dataForm.Potential['Zalo']"
                  FieldSet="Zalo"
                  class="add-input-feild s-input"
                  :maxlength="maxLengthInput.Name"
                />
              </div>
              <div class="add-item">
                <div class="aib-txt">Email cơ quan</div>
                <input
                  tabindex="12"
                  @keydown="customTabIndex"
                  type="text"
                  FieldSet="OfficeEmail"
                  class="add-input-feild s-input"
                  v-model = "dataForm.Potential['OfficeEmail']"
                  :maxlength="maxLengthInput.Email"
                />
              </div>
              <div class="validate-error" v-if="validate.emailVal.OfficeEmail==1" >Email không hợp lệ</div>
              <div class="add-item">
                <div class="aib-txt">Mã số thuế</div>
                <input
                  tabindex="14"
                  @keydown="customTabIndex"
                  type="text"
                  FieldSet="Taxcode"
                  class="add-input-feild s-input"
                  v-model="dataForm.Potential['Taxcode']"
                  :maxlength="maxLengthInput.Code"
                />
              </div>
            </div>
            <div class="add-items-site">
              <div class="add-item">
                <div class="aib-txt">Họ và tên đệm</div>
                <input class="add-input-feild s-input"
                tabindex="2" 
                @keydown="customTabIndex"
                type="text"
                v-model="dataForm.Potential['LastName']"
                FieldSet="LastName"
                :maxlength="maxLengthInput.NameHalf"/>
              </div>
              <div class="add-item">
                <div class="aib-txt">Họ và tên</div>
                <input class="add-input-feild s-input" 
                disabled 
                v-model="dataForm.Potential.FullName"
                :maxlength="maxLengthInput.Name"/>
              </div>
              <div class="add-item">
                <div class="aib-txt">Chức danh</div>
                <div class="add-select-feild" @click="getFieldData('get', axiosConf.Positions, 'positions')">
                  <SelectInput tabindex="5" @keydown="customTabIndex" :col="{0:'PositionID', 1: 'PositionName'}" :data="positions" :variable="'PositionID'" @emitValue="getValueSelectInput" :type="'guid'"/>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">ĐT cơ quan <div class="add-item-icon" @mouseover="tooltip.OfficePhoneNumber = true" @mouseleave="tooltip.OfficePhoneNumber = false"> <tool-tip :msg="'Điện thoại cơ quan'" v-if="tooltip.OfficePhoneNumber" @tooltipClickOutside="tooltipClickOutside('OfficePhoneNumber')"></tool-tip> </div></div>
                <input
                  tabindex="7"
                  @keydown="customTabIndex"
                  type="text"
                  v-model="dataForm.Potential['OfficePhoneNumber']"
                  FieldSet = "OfficePhoneNumber"
                  class="add-input-feild s-input"
                  :maxlength="maxLengthInput.Phone"
                />
              </div>
              <div class="add-item">
                <div class="aib-txt">Loại tiềm năng</div>
                <div class="add-select-feild" @click="getFieldData('get', axiosConf.PotentialTypes, 'potentialTypes')">
                  <ComboboxComponent tabindex="9" @keydown="customTabIndex" :data="potentialTypes" :col="{0:'PotentialTypeID', 1:'PotentialTypeName'}" :variable="'PotentialTypes'" @emitComboboxValue="getValueFromCombobox"></ComboboxComponent>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Email cá nhân</div>
                <input
                  tabindex="11"
                  @keydown="customTabIndex"
                  type="text"
                  v-model="dataForm.Potential['Email']"
                  FieldSet="Email"
                  class="add-input-feild s-input"
                  :maxlength="maxLengthInput.Email"
                />
              </div>
              <div class="validate-error" v-if="validate.emailVal.Email==1" >Email không hợp lệ</div>
              <div class="add-item">
                <div class="aib-txt">Tổ chức</div>
                <input
                  tabindex="13"
                  @keydown="customTabIndex"
                  type="text"
                  v-model="dataForm.Potential['Organization']"
                  FieldSet="Organization"
                  class="add-input-feild s-input"
                  :maxlength="maxLengthInput.Other"
                />
              </div>
            </div>
          </div>
        </div>
        <div class="add-main-content-org-box">
          <div class="add-section-title">Thông tin tổ chức</div>
          <div class="add-items">
            <div class="add-items-site">
              <div class="add-item">
                <div class="aib-txt">Tài khoản ngân hàng</div>
                <input
                  tabindex="15"
                  @keydown="customTabIndex"
                  type="text"
                  v-model="dataForm.Potential['BankAccount']"
                  FieldSet="BankAccount"
                  class="add-input-feild s-input"
                  :maxlength="maxLengthInput.Other"
                />
              </div>
              <div class="add-item">
                <div class="aib-txt">Ngày thành lập</div>
                <!-- <input type="date"
                  v-model="dataForm.Potential['FoundingDate']"
                  FieldSet="FoundingDate"
                  class="add-input-feild s-input"
                /> -->
                <el-config-provider :locale="lang.vi">
                  <el-date-picker
                  tabindex="17"
                  @keydown="customTabIndex"
                  v-model="dataForm.Potential['FoundingDate']"
                  type="date"
                  format="DD-MM-YYYY"
                  value-format="YYYY-MM-DD"
                  placeholder="DD/MM/YYYY"
                  size="default"
                  style="width: 280px;"
                  />
                </el-config-provider>
              </div>
              <div class="add-item">
                <div class="aib-txt">Lĩnh vực</div>
                <div class="add-select-feild" @click="getFieldData('get', axiosConf.Fields, 'fields')">
                  <ComboboxComponent tabindex="19" @keydown="customTabIndex" :data="fields" :col="{0:'FieldID', 1:'FieldName'}" :variable="'Fields'" @emitComboboxValue="getValueFromCombobox"></ComboboxComponent>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Doanh thu</div>
                <div class="add-select-feild" @click="getFieldData('get', axiosConf.Turnovers, 'turnovers')">
                  <SelectInput tabindex="21" @keydown="customTabIndex" :data="turnovers" :variable="'TurnoverID'" @emitValue="getValueSelectInput" :col="{0: 'TurnoverID' , 1:'TurnoverName'}" :type="'guid'"/>
                </div>
              </div>
            </div>
            <div class="add-items-site">
              <div class="add-item">
                <div class="aib-txt">Ngân hàng</div>
                <input class="add-input-feild s-input" 
                tabindex="16"
                @keydown="customTabIndex"
                type="text"
                FieldSet="BankName"
                v-model="dataForm.Potential['BankName']"
                :maxlength="maxLengthInput.Other"
                />
              </div>
              <div class="add-item">
                <div class="aib-txt">Loại hình</div>
                <div class="add-select-feild" @click="getFieldData('get', axiosConf.OrganizationTypes, 'organizationTypes')">
                  <SelectInput tabindex="18" @keydown="customTabIndex" :data="organizationTypes" :variable="'OrganizationTypeID'" @emitValue="getValueSelectInput" :col="{0: 'OrganizationTypeID' , 1:'OrganizationTypeName'}" :type="'guid'"/>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Ngành nghề</div>
                <div class="add-select-feild" @click="getFieldData('get', axiosConf.Careers, 'careers')">
                  <ComboboxComponent tabindex="20" @keydown="customTabIndex" :data="careers" :col="{0:'CareerID', 1:'CareerName'}" :variable="'Careers'" @emitComboboxValue="getValueFromCombobox"></ComboboxComponent>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="add-main-content-address-box">
          <div class="add-section-title">Thông tin địa chỉ</div>
          <div class="add-items">
            <div class="add-items-site">
              <div class="add-item">
                <div class="aib-txt">Quốc gia</div>
                <div class="add-select-feild" @click="getFieldData('get', axiosConf.Nations, 'nations')">
                  <SelectInput tabindex="22" @keydown="customTabIndex" :data="nations" :col="{0:'NationID', 1:'NationName'}" :variable="'NationID'" @emitValue="getValueSelectInput" :type="'guid'"/>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Quận/Huyện</div>
                <div class="add-select-feild">
                  <SelectInput 
                  tabindex="24"
                  @keydown="customTabIndex"
                  :data="districts" 
                  :col="{0:'DistrictID', 1:'DistrictName'}" 
                  :variable="'DistrictID'" 
                  @emitValue="getValueSelectInput"
                  :isActive="checkIsActiveAddress.district"
                  :type="'guid'"
                  :loading="false"/>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Số nhà, Đường phố</div>
                <input class="add-input-feild s-input" 
                tabindex="26"
                @keydown="customTabIndex"
                type="text"
                v-model="dataForm.Potential['ApartmentNumber']"
                FieldSet="ApartmentNumber"
                :maxlength="maxLengthInput.Name"/>
              </div>
              <div class="add-item add-item-txtarea">
                <div class="aib-txt">Địa chỉ</div>
                <textarea tabindex="28" @keydown="customTabIndex" class="s-input add-txtarea" v-model="dataForm.Potential['Address']" :maxlength="maxLengthInput.Other"></textarea>
              </div>
            </div>
            <div class="add-items-site">
              <div class="add-item">
                <div class="aib-txt">Tỉnh/Thành phố</div>
                <div class="add-select-feild">
                  <SelectInput 
                  tabindex="23"
                  @keydown="customTabIndex"
                  :data="cities" 
                  :col="{0:'CityID', 1:'CityName'}" 
                  :variable="'CityID'" 
                  @emitValue="getValueSelectInput"
                  :isActive="checkIsActiveAddress.city"
                  :type="'guid'"
                  :loading="false"
                  />
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Phường/Xã</div>
                <div class="add-select-feild">
                  <SelectInput
                  tabindex="25"
                  @keydown="customTabIndex"
                  :data="wards" 
                  :col="{0:'WardID', 1:'WardName'}" 
                  :variable="'WardID'" 
                  @emitValue="getValueSelectInput"
                  :isActive="checkIsActiveAddress.ward"
                  :type="'guid'"
                  :loading="false"/>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Mã vùng</div>
                <input class="add-input-feild s-input"
                tabindex="27"
                @keydown="customTabIndex"
                type="text"
                v-model="dataForm.Potential['RegionCode']"
                FieldSet="RegionCode"
                :maxlength="maxLengthInput.Code"/>
              </div>
            </div>
          </div>
        </div>
        <div class="add-main-content-description-box">
           <div class="add-section-title">Thông tin mô tả</div>
            <div class="add-item add-item-des">
              <div class="aib-txt">Mô tả</div>
                <textarea tabindex="29" @keydown="customTabIndex" class="s-input add-txtarea" v-model="dataForm.Potential['PotentialDescription']"></textarea>
            </div>
        </div>
        <div class="add-main-content-system-infor">
          <div class="add-section-title">Thông tin hệ thống</div>
          <div class="add-items">
            <div class="add-items-site">
              <div class="add-item add-item-has-add-input-checkbox">
                <div class="aib-txt">Dùng chung</div>
                <input tabindex="30" @keydown="customTabIndex" type="checkbox" class="add-input-checkbox" FieldSet="IsShare" isSelectedCheckBox="false" @click="isShareCheckboxOnClick"/>
              </div>
              <div class="add-item">
                <div class="aib-txt">Mã tiềm năng</div>
                <input class="add-input-feild s-input" 
                tabindex="31"
                @keydown="customTabIndex"
                type="text"
                FieldSet="PotentialCode"
                v-model="dataForm.Potential['PotentialCode']"
                :maxlength="maxLengthInput.Code"/>
              </div>
              <div class="validate-error" v-if="validate.duplicate.PotentialCode==0">Giá trị của Mã tiềm năng bị trùng. <div class="validate-error-show" @click="isDoing">Xem ngay</div> </div>
            </div>
          </div>
        </div>
      </div>

  </div>
</template>
<script>
import axiosConfig from "../../../script/config/axiosConfig.js";
import SelectInput from "../../../components/common/SelectInput.vue";
import ComboboxComponent from "@/components/common/ComboboxComponent.vue";
import Resource from '@/script/resource.js';
import ToolTip from '../../../components/common/ToolTip.vue';
import MaxLengthInput from "../../../script/maxLengthInput.js";
import vi from "../../../../node_modules/element-plus/es/locale/lang/vi";
import val from "../../../script/validate.js";

export default {
  components: {
    SelectInput,
    ComboboxComponent,
    ToolTip
  },
  data() {
    return {
      // data để lưu về server 
      dataForm: {
        Potential: {
            PotentialID: "00000000-0000-0000-0000-000000000000",
            PotentialCode: "",
            LastName: "",
            FirstName: "",
            FullName: "",
            PhoneNumber: "",
            OfficePhoneNumber: "",
            OtherPhoneNumber: "",
            Email: "",
            OfficeEmail: "",
            TaxCode: "",
            Zalo: "",
            Organization: "",
            BankAccount: "",
            BankName: "",
            FoundingDate: null,
            Address: "",
            NationID: "00000000-0000-0000-0000-000000000000",
            CityID: "00000000-0000-0000-0000-000000000000",
            DistrictID: "00000000-0000-0000-0000-000000000000",
            WardID: "00000000-0000-0000-0000-000000000000",
            ApartmentNumber: "",
            RegionCode: "",
            PotentialDescription: "",
            IsCall: null,
            IsSendEmail: null,
            Gender: null,
            DateOfBirth: null,
            Facebook: "",
            IsShare: null,
            VocativeID: "00000000-0000-0000-0000-000000000000",
            DepartmentID: "00000000-0000-0000-0000-000000000000",
            PositionID: "00000000-0000-0000-0000-000000000000",
            SourceID: "00000000-0000-0000-0000-000000000000",
            OrganizationTypeID: "00000000-0000-0000-0000-000000000000",
            TurnoverID: "00000000-0000-0000-0000-000000000000",
            CreatedDate: null,
            CreatedBy: "",
            ModifiedDate: null,
            ModifiedBy: "",
        }
      },
      // biến đánh dấu validate 
      // 1: đã validate xong,
      // 0: mới validate blur
      // -1: chưa validate
      validate:{
        required: {
          FirstName : -1,
        },
        duplicate: {
          PotentialCode: -1,
        },
        emailVal:{
          Email: 0,
          OfficeEmail: 0,
        }
      },
      // biến lưu cách xưng hô lấy từ db
      vocatives: {},
      // biến lưu phòng ban từ db
      departments: {},
      // biến lưu chức vụ lây từ db
      positions: {},
      // biến lưu nguồn gốc
      sources: {},
      // loại tổ chức 
      organizationTypes: {},
      // doanh thu 
      turnovers: {},
      // quốc gia 
      nations: {},
      // huyện
      districts: {},
      // thành phố 
      cities: {},
      // phường xã 
      wards: {},
      // loại tiềm năng 
      potentialTypes: {},
      // ngành nghề
      careers: {},
      // lĩnh vực
      fields:{},
      // kiểm tra xem đã được nhập chưa 
      checkIsActiveAddress: {
        city: true,
        district: true,
        ward: true,
      },
      // biến ẩn hiện tooltip
      tooltip: {
        PhoneNumber: false,
        OfficePhoneNumber: false,
      },
      // max length các ô input 
      maxLengthInput: MaxLengthInput,
      // language của element plus
      lang: {
        vi: vi,
      },
      // axiosConfig
      axiosConf: axiosConfig,
    };
  },
  methods: {
    /**
     * hàm lấy dữ liệu newCode
     * created by SONTD(16.09.2022)
     */
    init(){
        let me = this;
        try{
          axiosConfig.call("get", axiosConfig.Potentials+"/newCode", "", function(response){
              if (response.data){
                me.dataForm.Potential.PotentialCode = response.data.Data;
              }
          });
        }catch(error){
            console.log(error);
        }
    },

    /**
     * hàm lấy dữ liệu xưng hô từ server
     * created by SONTD(15.09.2022)
     */
     getFieldData(method, url, variable){
        try{
            let me = this;
            if(!me[variable].length){
                axiosConfig.call(method, url, "", function(response){
                    if (response.data){
                        me[variable] = response.data.DataList;
                    }
                });
            }
        }catch(error){
            console.log(error);
        }
    },

    /**
     * lấy tên huyện từ server
     * Created by SonTD (08.08.2022)
     */
    getDistrictFromServer(){
      let me = this,
          url = `?cityID=${me.dataForm.Potential.CityID}`
      try{
        axiosConfig.call("get", axiosConfig.Districts+url , "", function(response){
          if (response.data){
                me.districts = response.data.DataList;
              }
        })
      }catch(error){
        console.log(error);
      }
    },
    /**
     * lấy tên thành phố từ server
     * Created by SonTD (08.08.2022)
     */
    getCityFromServer(){
      let me = this,
          url = `?nationID=${me.dataForm.Potential.NationID}`
      try{

        axiosConfig.call("get", axiosConfig.Cities+url , "", function(response){
          if (response.data){
                me.cities = response.data.DataList;
              }
        })
      }catch(error){
        console.log(error);
      }
    },
    /**
     * lấy tên xã từ server
     * Created by SonTD (08.08.2022)
     */
    getWardFromServer(){
      let me = this,
          url = `?districtID=${me.dataForm.Potential.DistrictID}`
      try{

        axiosConfig.call("get", axiosConfig.Wards+url , "", function(response){
          if (response.data){
                me.wards = response.data.DataList;
              }
        })
      }catch(error){
        console.log(error);
      }
    },

    /**
     * sự kiện ấn vào nút save
     * Created by SONTD (12.08.2022)
     */
    saveButtonOnClick(){
        let me =this;
        let val = me.checkValidate();
        if (val){
          try{
            me.axios
              .post("http://localhost:5091/api/Potential", me.dataForm)
              .then((response) => {
                  if (response.status==201){
                    if (response.data && response.data.StatusMsg == Resource.ResponseStatus.SuccessMsg){
                      me.$emit("showToastMessage",3,"Thêm mới thành công");
                      me.$router.push("/");
                    }else if (response.data && response.data.StatusMsg == Resource.ResponseStatus.PotentialCodeDuplicate){
                      me.validateDuplicate("PotentialCode");
                      me.$emit("showToastMessage",2,"Trùng mã tiềm năng");
                    }else{
                      console.log(response);
                    }
                  }
                  else{
                    me.$emit("showToastMessage",4,"");
                  }
              })
              .catch(function(error){
                  me.$emit("showToastMessage",4,"");
                  console.log(error);
              });
          }catch(error){
              console.log(error);
          }
        }
    },

    /**
     * sự kiện ấn vào nút lưu và thêm
     * Created by SONTD (24.08.2022)
     */
    saveAndAddButtonOnClick(){
        let me =this;
        let val = me.checkValidate();
        if (val){
          try{
            me.axios
              .post("http://localhost:5091/api/Potential", me.dataForm)
              .then((response) => {
                  if (response.status==201){
                    if (response.data && response.data.StatusMsg == Resource.ResponseStatus.SuccessMsg){
                      me.$emit("showToastMessage",3,"Thêm mới thành công");
                      me.$emit("resetComponent");
                    }else if (response.data && response.data.StatusMsg == Resource.ResponseStatus.PotentialCodeDuplicate){
                      me.validateDuplicate("PotentialCode");
                      me.$emit("showToastMessage",2,"Trùng mã tiềm năng");
                    }
                  }
                  else{
                    me.$emit("showToastMessage",4,"");
                  }
              })
              .catch(function(error){
                  me.$emit("showToastMessage",4,"");
                  console.log(error);
              });
          }catch(error){
              console.log(error);
          }
        }else{
          me.$emit("showToastMessage",2,"Tên không được để trống");
        }
    },

    /**
     * trức khi lưu check lại xem có hàng nào dính validate không, nếu có thì chưa được lưu
     * created by SONTD (12.08.2022)
     */
    checkValidate(){
      try{
        let me = this,
            checkVal = true;
        // validate tên 
        me.dataForm.Potential.FirstName = me.dataForm.Potential.FirstName.trim();
        if(!me.dataForm.Potential.FirstName){
          me.$refs.addMainContentRef.querySelector(`[FieldSet=FirstName]`).classList.add("input-validate-error");
          me.$refs.addMainContentRef.querySelector(`[FieldSet=FirstName]`).focus();
          me.$emit("showToastMessage",2,"Tên không được để trống");
          checkVal = false;
          me.validate.required.FirstName=0;
        }else{
          me.$refs.addMainContentRef.querySelector(`[FieldSet=FirstName]`).classList.remove("input-validate-error");
          me.validate.required.FirstName=1;
        }
        // validate email 
        if(me.dataForm.Potential.Email && !val.Email(me.dataForm.Potential.Email)){
          me.$refs.addMainContentRef.querySelector(`[FieldSet=Email]`).classList.add("input-validate-error");
          if(checkVal){
            me.$refs.addMainContentRef.querySelector(`[FieldSet=Email]`).focus();
            me.$emit("showToastMessage",2,"Email không hợp lệ");
          }
          me.validate.emailVal.Email=1;
          checkVal = false;
        }else{
          me.$refs.addMainContentRef.querySelector(`[FieldSet=Email]`).classList.remove("input-validate-error");
          me.validate.emailVal.Email=0;
        }
        // validate office email 
        if(me.dataForm.Potential.OfficeEmail && !val.Email(me.dataForm.Potential.OfficeEmail)){
          me.$refs.addMainContentRef.querySelector(`[FieldSet=OfficeEmail]`).classList.add("input-validate-error");
          if(checkVal){
            me.$refs.addMainContentRef.querySelector(`[FieldSet=OfficeEmail]`).focus();
            me.$emit("showToastMessage",2,"Email không hợp lệ");
          }
          me.validate.emailVal.OfficeEmail=1;
          checkVal = false;
        }else{
          me.$refs.addMainContentRef.querySelector(`[FieldSet=OfficeEmail]`).classList.remove("input-validate-error");
          me.validate.emailVal.OfficeEmail=0;
        }
        return checkVal;
      }catch(error){
        console.log(error);
      }
    },

    /**
     * hàm thêm class và hiện validate khi bị trũng mã tiền năng
     * created by SONTD(22.08.2022)
     */
    validateDuplicate(field){
      let me = this;
      me.validate.duplicate[field] = 0;
      me.$refs.addMainContentRef.querySelector(`[FieldSet=${field}]`).classList.add("input-validate-error");
      me.$refs.addMainContentRef.querySelector(`[FieldSet=${field}]`).focus();
    },

    /**
     * lấy gia trị từ select input component
     * createdby SONTD (08.08.2022)
     * @param {*} vocative 
     */
    getValueSelectInput(val, variable){
      this.dataForm.Potential[variable] = val;
    },

    /**
     * lấy giá trị từ combobox component
     * created by SONTD(20.08.2022)
     */
    getValueFromCombobox(variable, val){
      this.dataForm.Potential[variable] =val;
    },

    /**
     * xử lí khi ấn vào checkbox của trường dùng chung
     * created by SONTD(21.08.2022)
     */
    isShareCheckboxOnClick(event){
        let me = this;
        if (event.target.getAttribute("isSelectedCheckBox")=="true"){
            event.target.setAttribute("isSelectedCheckBox","false");
            me.dataForm.Potential.IsShare = 0;
        }else{
            event.target.setAttribute("isSelectedCheckBox","true");
            me.dataForm.Potential.IsShare = 1;
        }
    },

    /**
     * hàm thực hiện khi ấn ra ngoài toottip, dùng để ẩn tooltip
     * @param {*} tooltipName 
     */
    tooltipClickOutside(tooltipName){
        let me = this;
        me.tooltip[tooltipName] = false;
    },

    /**
     * thực hiện khi ấn tab ở các trường input
     * created by SONTD(11.09.2022)
     */
    customTabIndex(event){
      let me = this,
          currentIndex = event.target.getAttribute("tabindex");
      // quay vòng index
      if(currentIndex=="34"){
        if(event.keyCode==9){
          let nextField = me.$refs.addMainContentRef.querySelector("[tabindex='1']");
          if(nextField){
            nextField.focus();
          }
        }
      }
      else{
        if(event.keyCode == 9){
            if(currentIndex){
                let nextIndex = parseInt(currentIndex)+1,
                    nextField = me.$refs.addMainContentRef.querySelector(`[tabindex='${nextIndex}']`);
                if(nextField){
                    nextField.click();
                    if(nextField.getAttribute("type") == "checkbox"){
                        nextField.click();
                    }
                }
            }
        }else if(event.keyCode == 13){
            event.target.click();
        }
      }
    },

    /**
     * chức năng đang thi công
     * created by SONTD(19.08.2022)
     */
    isDoing(){
        alert("chức năng đang thi công.");
    }
  },
  created() {
    // khởi tạo các giá trị ban đầu cho màn add 
    this.init();
  },
  mounted() {
    // thêm icon delete vào ô input
    let me = this;
    if (me.$refs.addMainContentRef.querySelectorAll("input[FieldSet][type=text]")){
        me.$refs.addMainContentRef.querySelectorAll("input[FieldSet][type=text]").forEach(function(item){
            // tạo DOM cho delete icon
            let div = document.createElement("div");
            div.classList.add("add-item-delete-all-icon-box");
            div.addEventListener("click",function(){
                div.closest(".add-item")
                if(div.closest(".add-item") && div.closest(".add-item").querySelector("input[type=text]")){
                    let field = div.closest(".add-item").querySelector("input[type=text]").getAttribute("FieldSet");
                    if(field){
                        me.dataForm.Potential[field] = "";
                    }
                    div.closest(".add-item").querySelector("input[type=text]").focus();
                }
            }); 
            let childDiv = document.createElement("div");
            childDiv.classList.add("add-item-delete-all-icon");
            div.appendChild(childDiv);
            // thêm div vào element cha
            if(item.closest(".add-item")){
                item.closest(".add-item").appendChild(div);
            }
      })
    }
    me.$refs.addMainContentRef.querySelector("[FieldSet=VocativeID]").focus();
  },
  computed:{
    //computed fullname
    FullNameComputed: function(){
        let me = this,
            fn = (me.dataForm.Potential.FirstName)? me.dataForm.Potential.FirstName:"",
            ln = (me.dataForm.Potential.LastName)? me.dataForm.Potential.LastName:"";
        return ln+" "+fn;
    },

    //compute address
    AddressComputed: function(){
        let me = this,
            nationString = "",
            cityString = "",
            districtString = "",
            wardString = "";
        //lấy tên quốc gia
        if(me.nations && me.nations.length>0){
            me.nations.forEach(function(na){
                if (na.NationID == me.dataForm.Potential.NationID){
                    nationString = na.NationName;
                }
            })
        }
        // lấy tên tỉnh
        if(me.cities && me.cities.length>0){
            me.cities.forEach(function(ci){
                if (ci.CityID == me.dataForm.Potential.CityID){
                    cityString = ci.CityName;
                }
            })
        }
        //lấy tên huyện
        if(me.districts && me.districts.length>0){
            me.districts.forEach(function(di){
                if (di.DistrictID == me.dataForm.Potential.DistrictID){
                    districtString = di.DistrictName;
                }
            })
        }
        // lấy tên phường
        if(me.wards && me.wards.length>0){
            me.wards.forEach(function(ward){
                if (ward.WardID == me.dataForm.Potential.WardID){
                    wardString = ward.WardName;
                }
            })
        }
        let resultString = wardString+ ((wardString)?", ":"") + districtString+((districtString)?", ":"")+cityString+((cityString)?", ":"")+nationString;
        if (resultString){
            resultString = me.dataForm.Potential.ApartmentNumber+((me.dataForm.Potential.ApartmentNumber)?", ":"")+resultString;
        }else{
            resultString = me.dataForm.Potential.ApartmentNumber;
        }
        return resultString;
    },
  },
  watch: {
      //cập nhật address
      'AddressComputed':function(newValue){
          this.dataForm.Potential.Address = newValue;
      },
      // cập nhật full name 
      'FullNameComputed':function(newValue){
          this.dataForm.Potential.FullName = newValue;
      },
      //check sự thay đổi của quốc gia
      'dataForm.Potential.NationID':function(newValue){
         if (newValue!=null && newValue!="" && newValue!=undefined){
            // khởi tạo lại id của tỉnh, huyện, xã
            this.dataForm.Potential.CityID ="00000000-0000-0000-0000-000000000000";
            this.dataForm.Potential.DistrictID ="00000000-0000-0000-0000-000000000000";
            this.dataForm.Potential.WardID ="00000000-0000-0000-0000-000000000000";
            // khởi tạo lại giá trị của tỉnh huyện xã 
            this.cities ={};
            this.districts = {};
            this.wards ={};

            this.checkIsActiveAddress.city=true;
            this.getCityFromServer();
         }
         else{
            this.dataForm.Potential.NationID="00000000-0000-0000-0000-000000000000"
         }
      },
      //check tỉnh thay đổi
      'dataForm.Potential.CityID':function(newValue){
          if (newValue!=null && newValue!="" && newValue!=undefined){
              // khởi tạo lại id của huyện, xã
              this.dataForm.Potential.DistrictID ="00000000-0000-0000-0000-000000000000";
              this.dataForm.Potential.WardID ="00000000-0000-0000-0000-000000000000";
              // khởi tạo lại giá trị của huyện xã 
              this.districts = {};
              this.wards ={};
              this.checkIsActiveAddress.district=true;
              this.getDistrictFromServer();
          }
          else{
              this.dataForm.Potential.CityID="00000000-0000-0000-0000-000000000000"
          }
      },
      //check huyện thay đổi
      'dataForm.Potential.DistrictID':function(newValue){
          if (newValue!=null && newValue!="" && newValue!=undefined){
              // khởi tạo lại id của xã
              this.dataForm.Potential.WardID ="00000000-0000-0000-0000-000000000000";
              // khởi tạo lại giá trị của xã 
              this.wards ={};
              this.checkIsActiveAddress.ward=true;
              this.getWardFromServer();
          }
          else{
              this.dataForm.Potential.CityID="00000000-0000-0000-0000-000000000000";
          }
      },
      // check phường thay đổi 
      'dataForm.Potential.WardID':function(newValue){
          if (newValue==null || newValue== "" || newValue==undefined){
              this.dataForm.Potential.WardID="00000000-0000-0000-0000-000000000000";
          }
      },
      // kiểm tra thay đổi biến LastName
      'dataForm.Potential.LastName':function(newValue){
          let me = this,
              input = me.$refs.addMainContentRef.querySelector("[FieldSet=LastName]");
          if (newValue){
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="visible";
              } 
          }else{
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="hidden";
              } 
          }
      },
      // kiểm tra validate required cho biến FisrtName
      'validate.required.FirstName':function(newValue){
          let me = this;
          if(newValue == 0 ){
              me.$refs.addMainContentRef.querySelector("[FieldSet=FirstName]").classList.add("input-validate-error");
          }else{
            me.$refs.addMainContentRef.querySelector("[FieldSet=FirstName]").classList.remove("input-validate-error");
          }
      },
      // kiểm tra thay đổi biến FirstName
      'dataForm.Potential.FirstName':function(newValue){
          let me = this,
              input = me.$refs.addMainContentRef.querySelector("[FieldSet=FirstName]");
          if (newValue){
              me.validate.required.FirstName = 1;
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="visible";
              } 
          }else{
              me.validate.required.FirstName = 0;
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="hidden";
              } 
          }
      },
      // kiểm tra thay đổi biến PhoneNumber
      'dataForm.Potential.PhoneNumber':function(newValue){
          let me = this,
              input = me.$refs.addMainContentRef.querySelector("[FieldSet=PhoneNumber]");
          if (newValue){
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="visible";
              } 
          }else{
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="hidden";
              } 
          }
      },
      // kiểm tra thay đổi biến OfficePhoneNumber
      'dataForm.Potential.OfficePhoneNumber':function(newValue){
          let me = this,
              input = me.$refs.addMainContentRef.querySelector("[FieldSet=OfficePhoneNumber]");
          if (newValue){
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="visible";
              } 
          }else{
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="hidden";
              } 
          }
      },
      // kiểm tra thay đổi biến Zalo
      'dataForm.Potential.Zalo':function(newValue){
          let me = this,
              input = me.$refs.addMainContentRef.querySelector("[FieldSet=Zalo]");
          if (newValue){
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="visible";
              } 
          }else{
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="hidden";
              } 
          }
      },
      // kiểm tra thay đổi biến Email
      'dataForm.Potential.Email':function(newValue){
          let me = this,
              input = me.$refs.addMainContentRef.querySelector("[FieldSet=Email]");
          if (newValue){
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="visible";
              } 
          }else{
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="hidden";
              } 
          }

          //validate 
          if((newValue && val.Email(newValue)) || !newValue){
              input.classList.remove("input-validate-error");
              me.validate.emailVal.Email=0;
          }
      },
      // kiểm tra thay đổi biến OfficeEmail
      'dataForm.Potential.OfficeEmail':function(newValue){
          let me = this,
              input = me.$refs.addMainContentRef.querySelector("[FieldSet=OfficeEmail]");
          if (newValue){
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="visible";
              } 
          }else{
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="hidden";
              } 
          }
          //validate 
          if((newValue && val.Email(newValue)) || !newValue){
              input.classList.remove("input-validate-error");
              me.validate.emailVal.OfficeEmail=0;
          }
      },
      // kiểm tra thay đổi biến Organization
      'dataForm.Potential.Organization':function(newValue){
          let me = this,
              input = me.$refs.addMainContentRef.querySelector("[FieldSet=Organization]");
          if (newValue){
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="visible";
              } 
          }else{
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="hidden";
              } 
          }
      },
      // kiểm tra thay đổi biến Taxcode
      'dataForm.Potential.Taxcode':function(newValue){
          let me = this,
              input = me.$refs.addMainContentRef.querySelector("[FieldSet=Taxcode]");
          if (newValue){
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="visible";
              } 
          }else{
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="hidden";
              } 
          }
      },
      // kiểm tra thay đổi biến BankAccount
      'dataForm.Potential.BankAccount':function(newValue){
          let me = this,
              input = me.$refs.addMainContentRef.querySelector("[FieldSet=BankAccount]");
          if (newValue){
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="visible";
              } 
          }else{
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="hidden";
              } 
          }
      },
      // kiểm tra thay đổi biến BankName
      'dataForm.Potential.BankName':function(newValue){
          let me = this,
              input = me.$refs.addMainContentRef.querySelector("[FieldSet=BankName]");
          if (newValue){
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="visible";
              } 
          }else{
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="hidden";
              } 
          }
      },
      // kiểm tra thay đổi biến ApartmentNumber
      'dataForm.Potential.ApartmentNumber':function(newValue){
          let me = this,
              input = me.$refs.addMainContentRef.querySelector("[FieldSet=ApartmentNumber]");
          if (newValue){
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="visible";
              } 
          }else{
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="hidden";
              } 
          }
      },
      // kiểm tra thay đổi biến RegionCode
      'dataForm.Potential.RegionCode':function(newValue){
          let me = this,
              input = me.$refs.addMainContentRef.querySelector("[FieldSet=RegionCode]");
          if (newValue){
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="visible";
              } 
          }else{
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="hidden";
              } 
          }
      },
      // kiểm tra thay đổi biến PotentialCode
      'dataForm.Potential.PotentialCode':function(newValue){
          let me = this,
              input = me.$refs.addMainContentRef.querySelector("[FieldSet=PotentialCode]");
          if (newValue){
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="visible";
              } 
          }else{
              if(input && input.closest(".add-item") && input.closest(".add-item").querySelector(".add-item-delete-all-icon-box")){
                  input.closest(".add-item").querySelector(".add-item-delete-all-icon-box").style.visibility="hidden";
              } 
          }
      },
  }
};
</script>
<style scoped>
@import url("../../../style/view/potential/add/addPotential.css");
@import url("../../../style/view/potential/add/addTopbar.css");
@import url("../../../style/view/potential/add/addMainContent.css");

</style>