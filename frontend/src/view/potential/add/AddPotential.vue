<template>
  <div id="contentAdd">
      <div id="addTopbar">
        <div class="addTopbar-left">
          <div class="al-txt1">Thêm Tiềm năng -</div>
          <div class="al-txt2">Mẫu tiêu chuẩn</div>
          <div class="al-changeConstruct">Sửa bố cục</div>
        </div>
        <div class="addTopbar-right">
          <router-link to="/"><button class="s-button-gray">Hủy bỏ</button></router-link>
          <!-- <button class="s-button-gray">Hủy bỏ</button> -->
          <button class="s-button-gray">Lưu và thêm</button>
          <button class="s-button">Lưu</button>
        </div>
      </div>
      <div id="addMainContent">
        <div class="addMainContent-img-box">
          <div class="add-section-title">Ảnh tiềm năng</div>
          <div class="aimgb-img-box">
            <div class="aimgb-img"></div>
          </div>
        </div>
        <div class="addMainContent-infor-box">
          <div class="add-section-title">Thông tin chung</div>
          <div class="add-items">
            <div class="add-items-site">
              <div class="add-item">
                <div class="aib-txt">Xưng hô</div>
                <div class="add-select-feild">
                  <SelectInput :isActive="true" :col="{0:'VocativeID', 1: 'Vocative'}" :data="vocatives" :variable="'VocativeID'" @emitValue="getValueSelectInput"/>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Tên <span>*</span></div>
                <input
                  class="add-input-feild s-input"
                />
              </div>
              <div class="validate-error">Tên không được để trống</div>
              <div class="add-item">
                <div class="aib-txt">Phòng ban</div>
                <div class="add-select-feild">
                  <SelectInput :col="{0:'DepartmentID',1:'DepartmentName'}" :data="departments"  :variable="'DepartmentID'" @emitValue="getValueSelectInput"/>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">ĐT di động <div class="add-item-icon"></div></div>
                <input
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
                  class="add-input-feild s-input"
                />
              </div>
              <div class="add-item">
                <div class="aib-txt">Email cơ quan</div>
                <input
                  class="add-input-feild s-input"
                />
              </div>
              <div class="add-item">
                <div class="aib-txt">Mã số thuế</div>
                <input
                  class="add-input-feild s-input"
                />
              </div>
            </div>
            <div class="add-items-site">
              <div class="add-item">
                <div class="aib-txt">Họ và tên đệm</div>
                <input class="add-input-feild s-input" />
              </div>
              <div class="add-item">
                <div class="aib-txt">Họ và tên</div>
                <input class="add-input-feild s-input" disabled />
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
                  class="add-input-feild s-input"
                />
              </div>
              <div class="add-item">
                <div class="aib-txt">Loại tiềm năng</div>
                <input
                  class="add-input-feild s-input"
                />
              </div>
              <div class="add-item">
                <div class="aib-txt">Email cá nhân</div>
                <input
                  class="add-input-feild s-input"
                />
              </div>
              <div class="add-item">
                <div class="aib-txt">Tổ chức</div>
                <input
                  class="add-input-feild s-input"
                />
              </div>
            </div>
          </div>
        </div>
        <div class="addMainContent-org-box">
          <div class="add-section-title">Thông tin tổ chức</div>
          <div class="add-items">
            <div class="add-items-site">
              <div class="add-item">
                <div class="aib-txt">Tài khoản ngân hàng</div>
                <input
                  class="add-input-feild s-input"
                />
              </div>
              <div class="add-item">
                <div class="aib-txt">Ngày thành lập</div>
                <input type="date"
                  class="add-input-feild s-input"
                />
              </div>
              <div class="add-item">
                <div class="aib-txt">Lĩnh vực</div>
                <input type="text"
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
                <input class="add-input-feild s-input" />
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
                  class="add-input-feild s-input"
                />
              </div>
            </div>
          </div>
        </div>
        <div class="addMainContent-address-box">
          <div class="add-section-title">Thông tin địa chỉ</div>
          <div class="add-items">
            <div class="add-items-site">
              <div class="add-item">
                <div class="aib-txt">Quốc gia</div>
                <div class="add-select-feild">
                  <SelectInput/>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Quận/Huyện</div>
                <div class="add-select-feild">
                  <SelectInput/>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Số nhà, Đường phố</div>
                <input class="add-input-feild s-input" />
              </div>
              <div class="add-item add-item-txtarea">
                <div class="aib-txt">Địa chỉ</div>
                <textarea class="s-input add-txtarea"></textarea>
              </div>
            </div>
            <div class="add-items-site">
              <div class="add-item">
                <div class="aib-txt">Tỉnh/Thành phố</div>
                <div class="add-select-feild">
                  <SelectInput/>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Phường/Xã</div>
                <div class="add-select-feild">
                  <SelectInput/>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Mã vùng</div>
                <input class="add-input-feild s-input" />
              </div>
            </div>
          </div>
        </div>
        <div class="addMainContent-description-box">
           <div class="add-section-title">Thông tin mô tả</div>
            <div class="add-item add-item-des">
              <div class="aib-txt">Địa chỉ</div>
                <textarea class="s-input add-txtarea"></textarea>
            </div>
        </div>
        <div class="addMainContent-system-infor">
          <div class="add-section-title">Thông tin hệ thống</div>
          <div class="add-items">
            <div class="add-items-site">
              <div class="add-item">
                <div class="aib-txt">Dùng chung</div>
                <input type="checkbox" class="add-input-checkbox"/>
              </div>
              <div class="add-item">
                <div class="aib-txt">Dùng chung</div>
                <input class="add-input-feild s-input" />
              </div>
            </div>
          </div>
        </div>
      </div>
  </div>
</template>
<script>
// import axios from "axios";
import SelectInput from "../../../components/common/SelectInput.vue";
export default {
  components: {
    SelectInput,
  },
  data() {
    return {
      dataForm: {},
      vocatives: {},
      departments: {},
      positions: {},
      sources: {},
      organizationTypes: {},
      incomes: {},
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
            this.vocatives = response.data;
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
     * lấy gia trị từ select input component
     * createdby SONTD (08.08.2022)
     * @param {*} vocative 
     */
    getValueSelectInput(vocative, variable){
      this.dataForm[variable] = vocative;
      console.log(this.dataForm);
    },
    
  },
  created() {
    this.getVocativesFromServer();
    this.getDepartmentFromServer();
    this.getPositionFromServer();
    this.getSourceFromServer();
    this.getOrganizationTypeFromServer();
    this.getIncomeFromServer();
  },
};
</script>
<style scoped>
@import url("../../../style/view/potential/add/addTopbar.css");
@import url("../../../style/view/potential/add/addMainContent.css");
</style>