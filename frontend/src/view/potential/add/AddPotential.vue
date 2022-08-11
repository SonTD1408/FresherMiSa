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
          <button class="s-button-gray">Lưu và thêm</button>
          <button class="s-button" @click="test">Lưu</button>
        </div>
      </div>
      <div id="add-main-content">
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
                  v-model="dataForm.Potential['FirstName']"
                  @blur="validateRequired($event)"
                />
              </div>
              <div class="validate-error" v-if="validate.required.FirstName==false">Tên không được để trống</div>
              <div class="add-item">
                <div class="aib-txt">Phòng ban</div>
                <div class="add-select-feild">
                  <SelectInput :col="{0:'DepartmentID',1:'DepartmentName'}" :data="departments"  :variable="'DepartmentID'" @emitValue="getValueSelectInput"/>
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
                  <SelectInput  :data="sources" @emitValue="getValueSelectInput" :col="{0:'SourceID', 1: 'SourceName'}" :variable="'SourceID'"/>
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
                v-bind:value="(dataForm.Potential['LastName']!=undefined? dataForm.Potential['LastName']:'')+' '+(dataForm.Potential['FirstName']!=undefined? dataForm.Potential['FirstName']:'')"/>
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
                  v-model="dataForm.Potential['OfficePhoneNumber']"
                  FieldSet = "OfficePhoneNumber"
                  class="add-input-feild s-input"
                />
              </div>
              <div class="add-item">
                <div class="aib-txt">Loại tiềm năng</div>
                <input
                  v-model = "dataForm.Potential['PotentialType']"
                  FieldSet="PotentialType"
                  class="add-input-feild s-input"
                />
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
                  v-model="dataForm.Potential['OrganizationName']"
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
                <input type="text"
                FieldSet="Field" 
                  class="add-input-feild s-input"
                />
              </div>
              <div class="add-item">
                <div class="aib-txt">Doanh thu</div>
                <div class="add-select-feild">
                  <SelectInput :data="incomes" :variable="'IncomeID'" @emitValue="getValueSelectInput" :col="{0: 'IncomeID' , 1:'Income'}"/>
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
                  <SelectInput :data="organizationTypes" :variable="'OrganizationTypeID'" @emitValue="getValueSelectInput" :col="{0: 'OrganizationTypeID' , 1:'OrganizationTypeName'}"/>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Ngành nghề</div>
                <input
                  v-model="dataForm.Potential['OrganizationCareer']"
                  FieldSet="OrganizationCareer"
                  class="add-input-feild s-input"
                />
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
                  <SelectInput :data="nations" :col="{0:'NationID', 1:'NationName'}" :variable="'NationID'" @emitValue="getValueSelectInput"/>
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
                  :isActive="checkIsActiveAddress.district"/>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Số nhà, Đường phố</div>
                <input class="add-input-feild s-input" />
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
                  :isActive="checkIsActiveAddress.city"/>
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
                  :isActive="checkIsActiveAddress.ward"/>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Mã vùng</div>
                <input class="add-input-feild s-input" />
              </div>
            </div>
          </div>
        </div>
        <div class="add-main-content-description-box">
           <div class="add-section-title">Thông tin mô tả</div>
            <div class="add-item add-item-des">
              <div class="aib-txt">Địa chỉ</div>
                <textarea class="s-input add-txtarea" v-model="dataForm.Potential['DesciptionP']"></textarea>
            </div>
        </div>
        <div class="add-main-content-system-infor">
          <div class="add-section-title">Thông tin hệ thống</div>
          <div class="add-items">
            <div class="add-items-site">
              <div class="add-item">
                <div class="aib-txt">Dùng chung</div>
                <input type="checkbox" class="add-input-checkbox" v-model="dataForm.Potential['SharedP']"/>
              </div>
              <div class="add-item">
                <div class="aib-txt">Mã tiềm năng</div>
                <input class="add-input-feild s-input" 
                FieldSet="PotentialCode"
                v-model="dataForm.Potential['PotentialCode']"/>
              </div>
            </div>
          </div>
        </div>
      </div>

  </div>
</template>
<script>
import SelectInput from "../../../components/common/SelectInput.vue";
export default {
  components: {
    SelectInput,
  },
  data() {
    return {
      dataForm: {
        Potential: {}
      },
      validate:{
        required: {
          FirstName : true,
        }
      },
      vocatives: {},
      departments: {},
      positions: {},
      sources: {},
      organizationTypes: {},
      incomes: {},
      nations: {},
      districts: {},
      cities: {},
      wards: {},
      checkIsActiveAddress: {
        city: false,
        district: false,
        ward: false,
      }
    };
  },
  methods: {
    /**
     * lấy xưng hô từ server
     * Created by SonTD (08.08.2022)
     */
    getVocativesFromServer(){
      try{
        this.axios.
          get("http://localhost:5091/api/Vocative")
          .then((response) => {
            this.vocatives = response.data.DataList;
          })
      }catch(error){
        console.log(error);
      }
    },
    /**
     * lấy phòng ban từ server
     * Created by SonTD (08.08.2022)
     */
    getDepartmentFromServer(){
      try{
        this.axios
          .get("http://localhost:5091/api/Department")
          .then((response) => {
            this.departments = response.data;
          })
      }catch(error){
        console.log(error);
      }
    },
    /**
     * lấy chức danh từ server
     * Created by SonTD (08.08.2022)
     */
    getPositionFromServer(){
      try{
        this.axios
          .get("http://localhost:5091/api/Position")
          .then((response) => {
            this.positions = response.data;
          })
      }catch(error){
        console.log(error);
      }
    },
    /**
     * lấy nguồn gốc từ server
     * Created by SonTD (08.08.2022)
     */
    getSourceFromServer(){
      try{
        this.axios
          .get("http://localhost:5091/api/Source")
          .then((response) => {
            this.sources = response.data;
          })
      }catch(error){
        console.log(error);
      }
    },
    /**
     * lấy loại tổ chức từ server
     * Created by SonTD (08.08.2022)
     */
    getOrganizationTypeFromServer(){
      try{
        this.axios
          .get("http://localhost:5091/api/OrganizationType")
          .then((response) => {
            this.organizationTypes = response.data;
          })
      }catch(error){
        console.log(error);
      }
    },
    /**
     * lấy doanh thu từ server
     * Created by SonTD (08.08.2022)
     */
    getIncomeFromServer(){
      try{
        this.axios
          .get("http://localhost:5091/api/InCome")
          .then((response) => {
            this.incomes = response.data;
          })
      }catch(error){
        console.log(error);
      }
    },
    /**
     * lấy tên quốc gia từ server
     * Created by SonTD (08.08.2022)
     */
    getNationFromServer(){
      try{
        this.axios
          .get("http://localhost:5091/api/Nation")
          .then((response) => {
            this.nations = response.data;
          })
      }catch(error){
        console.log(error);
      }
    },
    /**
     * lấy tên huyện từ server
     * Created by SonTD (08.08.2022)
     */
    getDistrictFromServer(){
      try{
        this.axios
          .get("http://localhost:5091/api/District?cityID="+this.dataForm.Potential.CityID)
          .then((response) => {
            this.districts = response.data;
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
      try{
        this.axios
          .get("http://localhost:5091/api/City?nationID="+this.dataForm.Potential.NationID)
          .then((response) => {
            this.cities = response.data;
            console.log(this.cities)
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
      try{
        this.axios
          .get("http://localhost:5091/api/Ward?districtID="+this.dataForm.Potential.DistrictID)
          .then((response) => {
            this.wards = response.data;
            console.log(this.wards)
          })
      }catch(error){
        console.log(error);
      }
    },


    test(){
      let val = this.checkValidate();
      console.log(val);
      if (val){
        try{
          this.axios
            .post("http://localhost:5091/api/Potential", this.dataForm)
            .then((response) => {
              console.log(response);
            });
        }catch(error){
            console.log(error);
        }

        console.log(this.dataForm)
        this.$router.push("/")
      }
    },

    checkValidate(){
      // this.validate.required.forEach(function(item){
      //   console.log(item);
      // })
      for (let key in this.validate.required){
        if (this.validate.required[key]==false ||this.validate.required[key]==undefined){
          return false;
        }
      }
      return true;
    },
    validateRequired(event){
      if (!event.target.value){
        event.target.classList.add("input-validate-error");
        this.validate.required[event.target.getAttribute("FieldSet")] = false;
      }else{
        event.target.classList.remove("input-validate-error");
        this.validate.required[event.target.getAttribute("FieldSet")] = true;
      }
    },

    /**
     * lấy gia trị từ select input component
     * createdby SONTD (08.08.2022)
     * @param {*} vocative 
     */
    getValueSelectInput(val, variable){
      this.dataForm.Potential[variable] = val;
    },
    
  },
  created() {
    this.getVocativesFromServer();
    this.getDepartmentFromServer();
    this.getPositionFromServer();
    this.getSourceFromServer();
    this.getOrganizationTypeFromServer();
    this.getIncomeFromServer();
    this.getNationFromServer();
  },
  watch: {
      //check sự thay đổi của quốc gia
      'dataForm.Potential.NationID':function(newValue){
         if (newValue>0 && newValue!="" && newValue!=undefined){
            // khởi tạo lại id của tỉnh, huyện, xã
            this.dataForm.Potential.CityID ="";
            this.dataForm.Potential.DistrictID ="";
            this.dataForm.Potential.WardID ="";
            // khởi tạo lại giá trị của tỉnh huyện xã 
            this.cities ={};
            this.districts = {};
            this.wards ={};

            this.checkIsActiveAddress.city=true;
            this.getCityFromServer();
         }
      },
      //check tỉnh thay đổi
      'dataForm.Potential.CityID':function(newValue){
          if (newValue>0 && newValue!="" && newValue!=undefined){
              // khởi tạo lại id của huyện, xã
              this.dataForm.Potential.DistrictID ="";
              this.dataForm.Potential.WardID ="";
              // khởi tạo lại giá trị của huyện xã 
              this.districts = {};
              this.wards ={};
              this.checkIsActiveAddress.district=true;
              this.getDistrictFromServer();
          }
      },
      //check huyện thay đổi
      'dataForm.Potential.DistrictID':function(newValue){
          if (newValue>0 && newValue!="" && newValue!=undefined){
              // khởi tạo lại id của xã
              this.dataForm.Potential.WardID ="";
              // khởi tạo lại giá trị của xã 
              this.wards ={};
              this.checkIsActiveAddress.ward=true;
              this.getWardFromServer();
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