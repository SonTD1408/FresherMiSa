<template>
  <div id="content-add">
      <div id="add-topbar">
        <div class="add-topbar-left">
          <div class="al-txt1">Thêm Tiềm năng -</div>
          <div class="al-txt2">Mẫu tiêu chuẩn</div>
          <div class="al-change-construct">Sửa bố cục</div>
        </div>
        <div class="add-topbar-right">
          <router-link to="/"><button class="s-button-gray">Hủy bỏ</button></router-link>
          <button class="s-button-gray" @click="saveAndAddButtonOnClick">Lưu và thêm</button>
          <button class="s-button" @click="saveButtonOnClick">Lưu</button>
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
                <div class="add-select-feild">
                  <SelectInput :col="{0:'VocativeID', 1: 'VocativeName'}" :data="vocatives" :variable="'VocativeID'" @emitValue="getValueSelectInput" :type="'guid'"/>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Tên <span style="color: red">*</span></div>
                <input
                  FieldSet="FirstName"
                  class="add-input-feild s-input"
                  v-model="dataForm.Potential['FirstName']"
                  @blur="validateRequired($event)"
                />
              </div>
              <div class="validate-error" v-if="validate.required.FirstName==0">Tên không được để trống</div>
              <div class="add-item">
                <div class="aib-txt">Phòng ban</div>
                <div class="add-select-feild">
                  <SelectInput :col="{0:'DepartmentID',1:'DepartmentName'}" :data="departments"  :variable="'DepartmentID'" @emitValue="getValueSelectInput" :type="'guid'"/>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">ĐT di động <div class="add-item-icon"></div></div>
                <input
                  v-model="dataForm.Potential['PhoneNumber']"
                  FieldSet="PhoneNumber"
                  class="add-input-feild s-input"
                />
              </div>
              <div class="add-item">
                <div class="aib-txt">Nguồn gốc</div>
                <div class="add-select-feild">
                  <SelectInput  :data="sources" @emitValue="getValueSelectInput" :col="{0:'SourceID', 1: 'SourceName'}" :variable="'SourceID'" :type="'guid'"/>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Zalo</div>
                <input
                  v-model="dataForm.Potential['Zalo']"
                  FieldSet="Zalo"
                  class="add-input-feild s-input"
                />
              </div>
              <div class="add-item">
                <div class="aib-txt">Email cơ quan</div>
                <input
                  FieldSet="OfficeEmail"
                  class="add-input-feild s-input"
                  v-model = "dataForm.Potential['OfficeEmail']"
                />
              </div>
              <div class="add-item">
                <div class="aib-txt">Mã số thuế</div>
                <input
                  FieldSet="Taxcode"
                  class="add-input-feild s-input"
                  v-model="dataForm.Potential['Taxcode']"
                />
              </div>
            </div>
            <div class="add-items-site">
              <div class="add-item">
                <div class="aib-txt">Họ và tên đệm</div>
                <input class="add-input-feild s-input" 
                v-model="dataForm.Potential['LastName']"
                FieldSet="LastName"/>
              </div>
              <div class="add-item">
                <div class="aib-txt">Họ và tên</div>
                <input class="add-input-feild s-input" 
                disabled 
                v-bind:value="(dataForm.Potential['LastName']? dataForm.Potential['LastName']:'')+' '+(dataForm.Potential['FirstName']? dataForm.Potential['FirstName']:'')"/>
              </div>
              <div class="add-item">
                <div class="aib-txt">Chức danh</div>
                <div class="add-select-feild">
                  <SelectInput :col="{0:'PositionID', 1: 'PositionName'}" :data="positions" :variable="'PositionID'" @emitValue="getValueSelectInput" :type="'guid'"/>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">ĐT cơ quan <div class="add-item-icon"></div></div>
                <input
                  v-model="dataForm.Potential['OfficePhoneNumber']"
                  FieldSet = "OfficePhoneNumber"
                  class="add-input-feild s-input"
                />
              </div>
              <div class="add-item">
                <div class="aib-txt">Loại tiềm năng</div>
                <div class="add-select-feild">
                  <ComboboxComponent :data="potentialTypes" :col="{0:'PotentialTypeID', 1:'PotentialTypeName'}" :variable="'PotentialTypes'" @emitComboboxValue="getValueFromCombobox"></ComboboxComponent>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Email cá nhân</div>
                <input
                  v-model="dataForm.Potential['Email']"
                  FieldSet="Email"
                  class="add-input-feild s-input"
                />
              </div>
              <div class="add-item">
                <div class="aib-txt">Tổ chức</div>
                <input
                  v-model="dataForm.Potential['Organization']"
                  FieldSet="OrganizationName"
                  class="add-input-feild s-input"
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
                  v-model="dataForm.Potential['BankAccount']"
                  FieldSet="BankAccount"
                  class="add-input-feild s-input"
                />
              </div>
              <div class="add-item">
                <div class="aib-txt">Ngày thành lập</div>
                <input type="date"
                  v-model="dataForm.Potential['FoundingDate']"
                  FieldSet="FoundingDate"
                  class="add-input-feild s-input"
                />
              </div>
              <div class="add-item">
                <div class="aib-txt">Lĩnh vực</div>
                <div class="add-select-feild">
                  <ComboboxComponent :data="fields" :col="{0:'FieldID', 1:'FieldName'}" :variable="'Fields'" @emitComboboxValue="getValueFromCombobox"></ComboboxComponent>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Doanh thu</div>
                <div class="add-select-feild">
                  <SelectInput :data="turnovers" :variable="'TurnoverID'" @emitValue="getValueSelectInput" :col="{0: 'TurnoverID' , 1:'TurnoverName'}" :type="'guid'"/>
                </div>
              </div>
            </div>
            <div class="add-items-site">
              <div class="add-item">
                <div class="aib-txt">Ngân hàng</div>
                <input class="add-input-feild s-input" 
                FieldSet="BankName"
                v-model="dataForm.Potential['BankName']"
                />
              </div>
              <div class="add-item">
                <div class="aib-txt">Loại hình</div>
                <div class="add-select-feild">
                  <SelectInput :data="organizationTypes" :variable="'OrganizationTypeID'" @emitValue="getValueSelectInput" :col="{0: 'OrganizationTypeID' , 1:'OrganizationTypeName'}" :type="'guid'"/>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Ngành nghề</div>
                <div class="add-select-feild">
                  <ComboboxComponent :data="careers" :col="{0:'CareerID', 1:'CareerName'}" :variable="'Careers'" @emitComboboxValue="getValueFromCombobox"></ComboboxComponent>
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
                <div class="add-select-feild">
                  <SelectInput :data="nations" :col="{0:'NationID', 1:'NationName'}" :variable="'NationID'" @emitValue="getValueSelectInput" :type="'guid'"/>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Quận/Huyện</div>
                <div class="add-select-feild">
                  <SelectInput 
                  :data="districts" 
                  :col="{0:'DistrictID', 1:'DistrictName'}" 
                  :variable="'DistrictID'" 
                  @emitValue="getValueSelectInput"
                  :isActive="checkIsActiveAddress.district"
                  :type="'guid'"/>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Số nhà, Đường phố</div>
                <input class="add-input-feild s-input" v-model="dataForm.Potential['ApartmentNumber']"/>
              </div>
              <div class="add-item add-item-txtarea">
                <div class="aib-txt">Địa chỉ</div>
                <textarea class="s-input add-txtarea" v-model="dataForm.Potential['Address']"></textarea>
              </div>
            </div>
            <div class="add-items-site">
              <div class="add-item">
                <div class="aib-txt">Tỉnh/Thành phố</div>
                <div class="add-select-feild">
                  <SelectInput 
                  :data="cities" 
                  :col="{0:'CityID', 1:'CityName'}" 
                  :variable="'CityID'" 
                  @emitValue="getValueSelectInput"
                  :isActive="checkIsActiveAddress.city"
                  :type="'guid'"/>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Phường/Xã</div>
                <div class="add-select-feild">
                  <SelectInput
                  :data="wards" 
                  :col="{0:'WardID', 1:'WardName'}" 
                  :variable="'WardID'" 
                  @emitValue="getValueSelectInput"
                  :isActive="checkIsActiveAddress.ward"
                  :type="'guid'"/>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Mã vùng</div>
                <input class="add-input-feild s-input" v-model="dataForm.Potential['RegionCode']"/>
              </div>
            </div>
          </div>
        </div>
        <div class="add-main-content-description-box">
           <div class="add-section-title">Thông tin mô tả</div>
            <div class="add-item add-item-des">
              <div class="aib-txt">Mô tả</div>
                <textarea class="s-input add-txtarea" v-model="dataForm.Potential['PotentialDescription']"></textarea>
            </div>
        </div>
        <div class="add-main-content-system-infor">
          <div class="add-section-title">Thông tin hệ thống</div>
          <div class="add-items">
            <div class="add-items-site">
              <div class="add-item">
                <div class="aib-txt">Dùng chung</div>
                <input type="checkbox" class="add-input-checkbox" FieldSet="IsShare" isSelectedCheckBox="false" @click="isShareCheckboxOnClick"/>
              </div>
              <div class="add-item">
                <div class="aib-txt">Mã tiềm năng</div>
                <input class="add-input-feild s-input" 
                FieldSet="PotentialCode"
                v-model="dataForm.Potential['PotentialCode']"/>
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
export default {
  components: {
    SelectInput,
    ComboboxComponent
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
      //data form default dùng khi khởi tạo lại giá trị dataform
      dataFormDefault: {
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
        city: false,
        district: false,
        ward: false,
      },
    };
  },
  methods: {
    /**
     * hàm khởi tạo lấy dữ liệu cho các ô select input
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
            // lấy dữ liệu doanh thu
            axiosConfig.call("get", axiosConfig.Turnovers, "", function(response){
              if (response.data){
                me.turnovers = response.data.DataList;
              }
            });
            // lấy dữ liệu loại tổ chức 
            axiosConfig.call("get", axiosConfig.OrganizationTypes, "", function(response){
              if (response.data){
                me.organizationTypes = response.data.DataList;
              }
            });
            // lấy dữ liệu tên các quốc gia
            axiosConfig.call("get", axiosConfig.Nations, "", function(response){
              if (response.data){
                me.nations = response.data.DataList;
              }
            });
            // lấy dữ liệu tên các quốc gia
            axiosConfig.call("get", axiosConfig.PotentialTypes, "", function(response){
              if (response.data){
                me.potentialTypes = response.data.DataList;
              }
            });
            // lấy dữ liệu lĩnh vực
            axiosConfig.call("get", axiosConfig.Fields, "", function(response){
              if (response.data){
                me.fields = response.data.DataList;
              }
            });
            // lấy dữ liệu ngành nghề
            axiosConfig.call("get", axiosConfig.Careers, "", function(response){
              if (response.data){
                me.careers = response.data.DataList;
              }
            });
            // lấy dữ liệu new code
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
                      me.$emit("showToastMessage",3);
                      me.$router.push("/");
                    }else if (response.data && response.data.StatusMsg == Resource.ResponseStatus.PotentialCodeDuplicate){
                      me.validateDuplicate("PotentialCode");
                    }
                  }
                  else{
                    me.$emit("showToastMessage",4);
                  }
              })
              .catch(function(error){
                  me.$emit("showToastMessage",4);
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
                      me.$emit("showToastMessage",3);
                      me.$emit("resetComponent");
                    }else if (response.data && response.data.StatusMsg == Resource.ResponseStatus.PotentialCodeDuplicate){
                      me.validateDuplicate("PotentialCode");
                    }
                  }
                  else{
                    me.$emit("showToastMessage",4);
                  }
              })
              .catch(function(error){
                  me.$emit("showToastMessage",4);
                  console.log(error);
              });
          }catch(error){
              console.log(error);
          }
        }
    },

    /**
     * trức khi lưu check lại xem có hàng nào dính validate không, nếu có thì chưa được lưu
     * created by SONTD (12.08.2022)
     */
    checkValidate(){
      let me = this;
      for (let key in me.validate.required){
        if (!me.validate.required[key] || me.validate.required[key]==0 || me.validate.required[key]==-1){
          me.$refs.addMainContentRef.querySelector(`[FieldSet=${key}]`).classList.add("input-validate-error");
          me.$refs.addMainContentRef.querySelector(`[FieldSet=${key}]`).focus();
          me.validate.required[key]=0;
          return false;
        }else{
          me.$refs.addMainContentRef.querySelector(`[FieldSet=${key}]`).classList.remove("input-validate-error");
        }
      }
      return true;
    },

    /**
     * check validate của các hàng có blur validateRequire()
     * created by SONTD(12.08.2022)
     */
    validateRequired(event){
      if (!event.target.value){
        event.target.classList.add("input-validate-error");
        this.validate.required[event.target.getAttribute("FieldSet")] = 0;
      }else{
        event.target.classList.remove("input-validate-error");
        this.validate.required[event.target.getAttribute("FieldSet")] = 1;
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
     * chức năng đang thi công
     * created by SONTD(19.08.2022)
     */
    isDoing(){
        alert("chức năng đang thi công.");
    }
  },
  created() {
    this.init();
  },
  watch: {
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
              this.dataForm.Potential.CityID="00000000-0000-0000-0000-000000000000"
          }
      },
      // check phường thay đổi 
      'dataForm.Potential.WardID':function(newValue){
          if (newValue==null || newValue== "" || newValue==undefined){
              this.dataForm.Potential.WardID="00000000-0000-0000-0000-000000000000"
          }
      }
  }
};
</script>
<style scoped>
@import url("../../../style/view/potential/add/addPotential.css");
@import url("../../../style/view/potential/add/addTopbar.css");
@import url("../../../style/view/potential/add/addMainContent.css");
</style>