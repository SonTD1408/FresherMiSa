<template>
  <div id="content-show">
    <div class="toolbar-top">
      <div id="toolbar-top">
        <!-- tool bar top left  -->
        <div class="tt-left" v-if="toolbarTopLeftStatus=='normal'">
          <div class="ttl-name">
            <div class="ttl-name-txt" @click="isDoing">Tất cả tiềm năng</div>
            <div class="ttl-name-icon" @click="isDoing"></div>
          </div>
          <div class="ttl-action" @click="isDoing">Sửa</div>
          <div class="ttl-refresh" @click="isDoing"></div>
        </div>
        <div class="tt-left" v-if="toolbarTopLeftStatus=='rowSelected'">
          <div class="ttl-choosed">Đã chọn <span>{{ numberOfRowSelected }}</span></div>
          <div class="tll-fogot-choose" @click="forgotChoosed">Bỏ chọn</div>
          <button class="s-button-gray ttl-button-update" @click="hideShowUpdateMany(true)">
            <div class="ttlbu-icon"></div> Cập nhật thông tin
          </button>
          <div class="s-button-gray ttl-option" @click="hideShowOptionDialogToolbarLeft">
              <div class="ttl-option-icon"></div>
              <div class="ttl-option-item-box" v-if="isShowOptionTtleft" v-click-outside="optionOutSideOnClick">
                <div class="s-button-gray ttl-option-item" @click="exportSelectedRow"><div class="ttloi-icon-export"></div> <span>Xuất khẩu</span></div>
                <div class="s-button-gray ttl-option-item" @click="deleteButtonOnClick"><div class="ttloi-icon-delete"></div> <span style="color: red">Xóa</span></div>
              </div>
          </div>
        </div>
        <!-- toolbar top right  -->
        <div class="tt-right">
          <div class="s-button-combo-container">
            <router-link to="/potential/add" class="sbcc-box">
              <button class="sbcc-button">
                <div class="sbcc-icon icon-page"></div>
                Thêm
              </button>
              <!-- <div class="sbcc-icon icon-page"></div> -->
              <div class="sbcc-type">
                <div class="sbcc-type-dropdown-icon"></div>
              </div>
            </router-link>
          </div>
          <div class="ttr-option" @click="isDoing">
            <div class="ttr-option-icon"></div>
          </div>
          <div class="ttr-option-combo" >
            <div class="ttroc-list-icon-box" @click="isDoing">
              <div class="ttroc-list-icon"></div>
            </div>
            <div class="ttroc-dropdown-icon-box" @click="isDoing">
              <div class="ttroc-dropdown-icon"></div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="potential-content">
      
      <FilterBarLeft :isShowFilterbarLeft="isShowFilterbarLeft" @emitValue="getValueFilterData" @confirmFilterPotential="confirmFilterPotential"></FilterBarLeft>
      <div id="main-content" ref="showMainContentRef">
        <div class="filterbar-left-show-hide-btn" @click="hideShowFilterbarLeft">
          <div class="filterbar-left-show-hide-btn-icon"></div>
        </div>
        <div class="toolbar-right-show-hide-btn" @click="hideShowToolbarRight">
          <div class="toolbar-right-show-hide-btn-icon"></div>
        </div>
        <div id="potential-table" ref="gridTable">
          <div class="s-thead">
            <div class="s-tr">
                <div class="s-th align-right">
                    <div class="s-th-export-icon" @click="isDoing"></div>
                    <input type="checkbox" class="s-th-select-icon s-th-check-all-row" isChecked="false" @click="checkAllRowOnClick">
                </div>
              <div class="s-th">Thẻ</div>
              <div class="s-th">Xưng hô</div>
              <div class="s-th">Họ và tên</div>
              <div class="s-th">Chức danh</div>
              <div class="s-th">Phòng ban</div>
              <div class="s-th">ĐT di động</div>
              <div class="s-th">ĐT cơ quan</div>
              <div class="s-th">Email cơ quan</div>
              <div class="s-th">Email cá nhân</div>
              <div class="s-th">Tổ chức</div>
              <div class="s-th">Địa chỉ</div>
              <div class="s-th">Tỉnh/Thành phố</div>
              <div class="s-th">Quận/Huyện</div>
              <div class="s-th">Phường/Xã</div>
              <div class="s-th">Nguồn gốc</div>
              <div class="s-th">Mô tả</div>
              <div class="s-th">Doanh thu</div>
            </div>
          </div>
          <div class="s-tbody" v-on:scroll="handleScroll" v-show="isShowDataInTable" v-click-outside="bodyGridOnClickOutside">
            <div class="s-tr" v-for="(item, index) in data" :key="index" :indexOfRow="index" :idOfRow="item.PotentialID" @mouseover="rowOnMouseOver" @mouseleave="rowOnMouseLeave" @click="rowOnClick">
              <div class="s-td align-right">
                  <div class="s-td-update-icon" style="visibility: hidden;" @click="updateIconOnClick($event)"></div>
                  <input type="checkbox" class="s-th-select-icon" isChecked="false" @click="gridCheckboxOnClick">
              </div>
              <div class="s-td" v-for="(i,ind) in gridColumns" :key="ind">
                  <div class="cell-phone-icon" v-if="ind==6 || ind==5"></div>
                  <div class="s-td-text" :class="(ind>4 && ind<9)? 'text-color-blue':''" v-if="ind!=2">{{formatNullData(item[i])}}</div>
                  <div class="s-td-text text-color-blue" v-if="ind==2">{{((item['LastName']!="")? `${item['LastName']} `:"" )+  item['FirstName']}}</div>
              </div>
            </div>
            <LoadingComponent :typeOfLoading="isShowLoading"></LoadingComponent>
            <div class="show-potential-no-data" v-if="isDataNull">Không tìm thấy dữ liệu</div>
          </div>
        </div>
        <div class="footer" ref="showPotentialFooter">
          <div class="footer-left">Total: <span :innerHTML="numberOfRecord"></span></div>
          <div class="footer-right">
            <div class="footer-page-size" @click="pageSizeOnClick" v-click-outside="selectPageSizeOnClickOutside"><span>{{pageSize}}</span> 
               Bản ghi trên Trang
              <div class="fps-dropdown"></div>
              <div class="fps-combobox" v-show="isShowPagesizeCombobox">
                <div class="fpsc-item" Value="10" @click="changePageSizeOnClick">
                  <div class="fpsc-item-text">10 Bản ghi trên Trang</div>
                  <div class="fpsc-item-selected-icon"></div>
                </div>
                <div class="fpsc-item" Value="20" @click="changePageSizeOnClick">
                  <div class="fpsc-item-text">20 Bản ghi trên Trang</div>
                  <div class="fpsc-item-selected-icon"></div>
                </div>
                <div class="fpsc-item" Value="50" @click="changePageSizeOnClick">
                  <div class="fpsc-item-text">50 Bản ghi trên Trang</div>
                  <div class="fpsc-item-selected-icon"></div>
                </div>
                <div class="fpsc-item" Value="100" @click="changePageSizeOnClick">
                  <div class="fpsc-item-text">100 Bản ghi trên Trang</div>
                  <div class="fpsc-item-selected-icon"></div>
                </div>
              </div>
            </div>
            <div class="footer-paging">
                <div class="fp-first" @click="goToFirstPage"></div>
                <div class="fp-prev" @click="goToPrePage"></div>
                <div class="fp-txt"><span class="from">{{(pageNumber-1)*pageSize+1}}</span>đến<span class="to">{{(pageNumber*pageSize > numberOfRecord)? numberOfRecord : (pageNumber)*pageSize}}</span></div>
                <div class="fp-next" @click="goToNextPage"></div>
                <div class="fp-last" @click="goToLastPage"></div>
            </div>
          </div>
        </div>
      </div>
      <div id="toolbar-right" v-if="isShowToolbarRight" ref="showPotentialToolbarRight">
        <div class="tr-header">
          <div class="trh-item" @click="isDoing">
            <div class="trh-item-icon trh-item-icon-1"></div>
          </div>
          <div class="trh-item" @click="isDoing">
            <div class="trh-item-icon trh-item-icon-2"></div>
          </div>
          <div class="trh-item" @click="isDoing">
            <div class="trh-item-icon trh-item-icon-3"></div>
          </div>
          <div class="trh-item" @click="isDoing">
            <div class="trh-item-icon trh-item-icon-4"></div>
          </div>
        </div>
        <div class="tr-body">
          <div class="tr-body-title">Lịch sử giao dịch</div>
          <div class="trb-item-box" v-if="toolbarRight.indexOfRowSelected!=-1">
            <div class="trb-item" v-show="toolbarRight.isShowCreatedBy">
              <div class="trb-item-icon-box">
                <div class="trb-item-icon"></div>
              </div>
              <div class="trb-item-content">
                <div class="trbic-type">Ghi chú</div>
                <div class="trbic-txt"><div class="trbic-txt-name">Nguyễn Văn Hà</div>.<div class="trbic-txt-date">12/08/2021</div></div>
              </div>
            </div>
            <div class="trb-item" v-show="toolbarRight.isShowModifiedBy">
              <div class="trb-item-icon-box">
                <div class="trb-item-icon"></div>
              </div>
              <div class="trb-item-content">
                <div class="trbic-type">Ghi chú</div>
                <div class="trbic-txt"><div class="trbic-txt-name">Nguyễn Văn Hà</div>.<div class="trbic-txt-date">12/08/2021</div></div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <UpdateMany :isShow="isShowUpdateMany" @hideShowStatus="hideShowUpdateMany" :idList="rowIDList" @confirmMultiUpdate="confirmMultiUpdate"></UpdateMany>
    <DialogComponent :isShow="isShowDialogComponent" @confirm="confirmDialog"></DialogComponent>
  </div>

</template>
<script>
import vClickOutside from "click-outside-vue3";
import UpdateMany from "../update/UpdateMany.vue";
import DialogComponent from "../../../components/dialog/DialogComponent.vue"
import axiosConfig  from "@/script/config/axiosConfig";
import LoadingComponent from "@/components/common/LoadingComponent.vue";
import FilterBarLeft from "./FilterBarLeft.vue";
export default {
  directives: {
      clickOutside: vClickOutside.directive
  },
  props:{
      searchString: String,
  },
  components:{
    UpdateMany,
    DialogComponent,
    LoadingComponent,
    FilterBarLeft
},
  data() {
    return {
      // biến để reset table
      isShowDataInTable: 1,
      // biến đếm số dòng được chọn
      numberOfRowSelected: 0,
      // biến lưu trữ những id đã chọn trc khi update
      rowIDList: [],
      // biến thay đổi trạng thái của toolbar top
      toolbarTopLeftStatus: "normal",
      // biến chọn page size
      isShowPagesizeCombobox: false,
      // biến ẩn hiện dialog xuất khẩu và xóa
      isShowOptionTtleft: false,
      // biến ẩn hiện thanh bên trái
      isShowFilterbarLeft: true,
      //biến ẩn hiện thanh bên phải
      isShowToolbarRight: true,
      // biến ẩn hiện update many dialog
      isShowUpdateMany: false,
      // ẩn hiện dialog component
      isShowDialogComponent: 0,
      // ẩn hiện loading
      isShowLoading: 0,
      // kiểm tra data lấy về có null không
      isDataNull: false,
      //số bản ghi trên trang
      pageSize : "50",
      // số trang 
      pageNumber: 1,
      // các cột trong 1 dòng dữ liệu trên grid
      gridColumns: [
        "PotentialCode",
        "VocativeName",
        "FirstName",
        "PositionName",
        "DepartmentName",
        "PhoneNumber",
        "OfficePhoneNumber",
        "OfficeEmail",
        "Email",
        "Organization",
        "Address",
        "CityName",
        "DistrictName",
        "WardName",
        "SourceName",
        "PotentialDescription",
        "TurnoverName"
      ],
      // data của bảng lấy từ server 
      data: {},
      // số lượng bản ghi lấy từ db 
      numberOfRecord: 0,
      // lưu lại index của dòng mình vừa click
      toolbarRight: {
        indexOfRowSelected: 4,
        isShowCreatedBy: false,
        isShowModifiedBy: false
      },
      // lấy từ fileter bar khi ấn áp dụng
      FilterData: [],
    };
  },

  methods: {
    /**
     * di chuột hover vào row thì hiện icon update
     * created by SONTD(24.08.2022)
     */
    rowOnMouseOver(event){
        if (event.target.closest(".s-tr")){
            if (event.target.closest(".s-tr").querySelector(".s-td-update-icon")){
                event.target.closest(".s-tr").querySelector(".s-td-update-icon").style.visibility="visible";
            }
        }
    },

    /**
     * di chuột ra ngoài row ẩn icon update
     * created by SONTD(24.08.2022)
     */
    rowOnMouseLeave(event){
        if (event.target.closest(".s-tr")){
            if (event.target.closest(".s-tr").querySelector(".s-td-update-icon")){
                event.target.closest(".s-tr").querySelector(".s-td-update-icon").style.visibility="hidden";
            }
        }
    },

    /**
     * hàm lấy tiềm năng từ serve
     * created by SONTD (07.08.2022)
     */
    getDataFromServer(){
      let me = this,
          url = `?pageSize=${me.pageSize}&pageNumber=${me.pageNumber}`;
      if (me.searchString){
          url+= `&filter=${me.searchString}`;
      }
      me.isDataNull = false;
      try{
          me.isShowLoading = 1;
          axiosConfig.call("post", axiosConfig.Potentials+"/Filter"+url,me.FilterData, function(response){
            if (response.data){
              me.isShowLoading= 0;
              if (response.data.Data){
                if (response.data.Data.NumberOfRecord==0){
                  me.isDataNull = true;
                }else{
                  me.isDataNull = false;
                }
                me.data = response.data.Data.PotentialList;
                me.numberOfRecord = response.data.Data.NumberOfRecord;
              }else{
                me.isDataNull = true;
              }
            }else{
              me.isDataNull=true;
            }
          });
      }catch(error){
          console.log(error);
      }
    },

    /**
     * hàm khi scroll thì kéo theo thead của table
     * created by SONTD (04.08.2022)
     */
    handleScroll(event){
        let me = this;
        const thead = me.$refs.gridTable.querySelector(".s-thead");
        if (event.target.scrollLeft>0){
            const translateX = -event.target.scrollLeft +"px";
            thead.style.transform = `translateX(${translateX})`;
        }else{
            thead.style.transform = "translateX(0)";
        }
    },

    /**
     * hàm hiện combobox chọn page size 
     * created by SONTD (04.08.2022)
     */
    pageSizeOnClick(){
      let me = this;
      if (!me.isShowPagesizeCombobox){
        let inputPageSizes = me.$refs.showPotentialFooter.querySelectorAll(".fpsc-item");
        if (inputPageSizes.length>0){
          inputPageSizes.forEach(function(inputPageSize){
            if (inputPageSize.getAttribute("Value") == me.pageSize){
              inputPageSize.classList.add("fpsc-item-selected");
              if(inputPageSize.querySelector(".fpsc-item-selected-icon")){
                inputPageSize.querySelector(".fpsc-item-selected-icon").style.visibility= "visible";
              }
            }else{
              inputPageSize.classList.remove("fpsc-item-selected");
              if(inputPageSize.querySelector(".fpsc-item-selected-icon")){
                inputPageSize.querySelector(".fpsc-item-selected-icon").style.visibility= "hidden";
              }
            }
          })
        }
      }
      me.isShowPagesizeCombobox = !me.isShowPagesizeCombobox
    },

    /**
     * hàm lấy page size khi người dùng đổi page size
     * Created by SONTD (04.08.2022)
     */
    changePageSizeOnClick(event){
      this.pageSize = event.target.closest(".fpsc-item").getAttribute("Value");
      this.pageNumber =1;
      this.reloadDataGrid();
    },

    /**
     * hàm dùng để bắt sự kiện click ra ngoài của ô chọn pagesize
     */
    selectPageSizeOnClickOutside(){
        this.isShowPagesizeCombobox = false;
    },

    /**
     * hàm ẩn hiện dialog xuất khẩu và xóa trên thanh toolbar left
     * created by SONTD(13.08.2022) 
     */
    hideShowOptionDialogToolbarLeft(){
        let me = this;
        me.isShowOptionTtleft = !me.isShowOptionTtleft;
    },

    /**
     * hàm ẩn hiện thanh lọc dữ liệu
     * Created by SONTD (04.08.2022)
     */
    hideShowFilterbarLeft(){
      let me = this;
      if(this.isShowFilterbarLeft){
        me.$refs.showMainContentRef.querySelector(".filterbar-left-show-hide-btn-icon").style.transform="rotate(180deg)"
      }else{
        me.$refs.showMainContentRef.querySelector(".filterbar-left-show-hide-btn-icon").style.transform="rotate(0)"
      }
      me.isShowFilterbarLeft = !me.isShowFilterbarLeft
    },

    /**
     * hàm ẩn hiện thanh toolbar bên phải
     * Created by SONTD (04.08.2022)
     */
    hideShowToolbarRight(){
      let me = this;
      if(this.isShowToolbarRight){
        me.$refs.showMainContentRef.querySelector(".toolbar-right-show-hide-btn-icon").style.transform="rotate(180deg)"
      }else{
        me.$refs.showMainContentRef.querySelector(".toolbar-right-show-hide-btn-icon").style.transform="rotate(0)"
      }
      me.isShowToolbarRight = !me.isShowToolbarRight
    },

    /**
     * hàm đổi màu cho hàng đó khi chọn 1 dòng,
     * tính số dòng đã chọn,
     * thay dổi thanh toolbar top khi chọn 1 dòng,
     * Created by SONTD (04.08.2022)
     * @param {event} event 
     */
    gridCheckboxOnClick(event){
      let me = event.target;
      if (me.getAttribute("isChecked")=="false"){
        me.setAttribute("isChecked","true");
        me.parentElement.parentElement.querySelectorAll(".s-td").forEach(function(child){
          child.classList.add("row-selected");
        })
        this.numberOfRowSelected++;
        // kiểm tra nếu số dòng chọn lớn hơn 1 thì thay đổi trạng thái thanh toolbar top
        if (this.numberOfRowSelected > 0){
          this.toolbarTopLeftStatus="rowSelected";
        }
        me.setAttribute("isChecked","true");
      }
      else{
        me.parentElement.parentElement.querySelectorAll(".s-td").forEach(function(child){
          child.classList.remove("row-selected");
        })
        this.numberOfRowSelected--;
        // kiểm tra nếu số dòng chọn lớn hơn 1 thì thay đổi trạng thái thanh toolbar top
        if (this.numberOfRowSelected < 1){
          this.toolbarTopLeftStatus="normal";
        }
        me.setAttribute("isChecked","false");
      }
    },

    /**
     * hàm bỏ chọn tất cả các dòng đã chọn
     * Created by SONTD (05.08.2022)
     */
    forgotChoosed(){
      let me = this;
      this.toolbarTopLeftStatus="normal";
      me.$refs.gridTable.querySelectorAll(".s-tr").forEach(function(tr){
        let input = tr.querySelector("input");
        if (input.getAttribute("isChecked")=="true"){
          input.click();
          input.setAttribute("isChecked","false");
        }
      })
    },

    /**
     * hàm ẩn hiện dialog update nhiều dòng 1 lúc
     * Created by SONTD (05.08.2022)
     * @param {*} param 
     */
    hideShowUpdateMany(param){
      let me  = this;
      if (me.isShowUpdateMany==false){
        me.rowIDList = me.getSelectedRow();
      }
      me.isShowUpdateMany = param;
    },

    /**
     * hàm xử lí khi bấm lưu update nhiều bản ghi
     * created by SONTD(18.08.2022)
     */
    confirmMultiUpdate(isSuccess){
        let me  =this;
        me.isShowUpdateMany = !me.isShowUpdateMany;
        if (isSuccess){
            me.$emit("showToastMessage",3,"Sửa thành công");
            me.reloadDataGrid();
        }else{
            me.$emit("showToastMessage",4,"Sửa thất bại");
        }
    },

    /**
     * hàm check value, nếu null thì chuyển thành -
     * @param {*} value 
     */
    formatNullData(value){
      if (value=="" || value==null || value==undefined){
        return "-"
      }
      else{
        return value;
      }
    },

    /**
     * hàm lấy id những dòng đã được chọn
     * created by SONTD(18.08.2022)
     */
    getSelectedRow(){
        let rowIDList= [],
            me = this;
        me.$refs.gridTable.querySelectorAll(".s-tbody [isChecked=true]").forEach(function(item){
            rowIDList.push(item.closest(".s-tr").getAttribute('idOfRow'))
        });
        return rowIDList;
    },

    /**
     * hàm đóng dialog component
     * created by SONTD (13.08.2022)
     */
    confirmDialog(confirm){
        let me = this;
        if(!confirm){
          me.isShowDialogComponent =0;
        }else{
            try{
                let rowIDList = [];
                me.isShowDialogComponent =0;
                me.$refs.gridTable.querySelectorAll(".s-tbody [isChecked='true']").forEach(function(item){
                    rowIDList.push(item.closest("[idOfRow]").getAttribute("idOfRow"));
                });
                // tạo mảng id cần xóa để đẩy vào server
                let idArray = {
                  "ListID" : rowIDList
                };
                axiosConfig.call("post",axiosConfig.MultiDelete, idArray, function(response){
                    if (response.data.StatusMsg == "s"){
                        me.$emit("showToastMessage",3,"Xóa thành công");
                        me.reloadDataGrid();
                    }else{
                        me.$emit("showToastMessage",4,"Xóa thất bại");
                    }
                })
            }catch(error){
                console.log(error);
            }
        }
    },

    /**
     * sự kiện khi nhấn vào nút delete
     * created by SONTD(13.08.2022)
     */
    deleteButtonOnClick(){
        let me = this;
        me.isShowDialogComponent = 1;
    },

    /**
     * hàm export ra file excel những dòng đã chọn
     * created by SONTD(26.08.2022)
     */
    exportSelectedRow(){
        let me = this,
            row = [];
        try{
            if (me.$refs.gridTable.querySelectorAll(".s-td [isChecked=true]")){
                me.$refs.gridTable.querySelectorAll(".s-td [isChecked=true]").forEach(function(item){
                    row.push(item.closest(".s-tr").getAttribute("idofrow"));
                });
            }
            me.axios({
              url: axiosConfig.PotentialExport,
              method: 'post',
              responseType: 'blob', // important,
              data: row,
            }).then((response) => {
              const url = window.URL.createObjectURL(new Blob([response.data]));
              const link = document.createElement('a');
              link.href = url;
              link.setAttribute('download', 'Potential.xlsx'); //or any other extension
              document.body.appendChild(link);
              link.click();
              link.remove();
          });

        }catch(error){
            console.log(error);
        }
    },

    /**
     * hàm reload data trong bảng
     * createdby SonTD(13.08.2022)
     */
    reloadDataGrid(){
        let me = this;
        me.isShowDataInTable =0;
        me.data={};
        //load lại data
        me.getDataFromServer();
        me.isShowDataInTable =1;
        // bỏ những hàng đã chọn 
        me.forgotChoosed();
    },

    /**
     * hàm xử lí khi click ra ngoài element
     * created by SONTD(14.08.2022)
     */
    optionOutSideOnClick(){
      let me = this;
      me.isShowOptionTtleft = false;
    },

    /**
     * hàm xử lí khi nhấn đúp vào 1 dòng db
     * created by SONTD(14.08.2022)
     */
    updateIconOnClick(event){
        let me = this;
        me.$router.push({name: "potential.update", query: {PotentialID : ""+event.target.closest(".s-tr").getAttribute("idOfRow")}})
    },

    /**
     * hàm chuyển đến trang đầu tiên
     * created by SONTD(19.08.2022)
     */
    goToFirstPage(){
        let me = this;
        if (me.pageNumber!=1){
            me.pageNumber =1; 
            me.reloadDataGrid();
        }
    },

    /**
     * hàm chuyển đến trang sau
     * created by SONTD(19.08.2022)
     */
    goToNextPage(){
        let me = this,
            numberOfPage = (me.numberOfRecord - ( me.numberOfRecord % me.pageSize )) / me.pageSize;
        if (me.numberOfRecord % me.pageSize != 0 ) {numberOfPage +=1;}
        if (me.pageNumber < numberOfPage){
            me.pageNumber +=1;
            me.reloadDataGrid();
        }
    },

    /**
     * hàm chuyển đến trang trước đó
     * created by SONTD(19.08.2022)
     */
    goToPrePage(){
        let me = this;
        if (me.pageNumber>1){
            me.pageNumber -=1;
            me.reloadDataGrid();
        }
    },

    /**
     * hàm chuyển đến trang cuối cùng
     * created by SONTD(19.08.2022)
     */
    goToLastPage(){
        let me = this,
            numberOfPage = (me.numberOfRecord - ( me.numberOfRecord % me.pageSize )) / me.pageSize;
        if (me.numberOfRecord % me.pageSize != 0 ) {numberOfPage +=1;}
        if (me.pageNumber != numberOfPage){
            me.pageNumber = numberOfPage;
            me.reloadDataGrid();
        }
    },

    /**
     * hàm sự kiện khi ấn vào ô checkbox để check tất cả các hàng
     * created by SONTD(26.08.2022)
     */
    checkAllRowOnClick(event){
        let me  = this;
        if (me.$refs.gridTable.querySelectorAll(".s-tbody .s-th-select-icon")){
            me.$refs.gridTable.querySelectorAll(".s-tbody .s-th-select-icon").forEach(function(item){
                if (item.getAttribute("isChecked")==event.target.getAttribute("isChecked")){
                    item.click();
                }
            });
        }
        if (event.target.getAttribute("isChecked")=="false"){
            event.target.setAttribute("isChecked", "true");
        }else{
            event.target.setAttribute("isChecked", "false");
        }
    },

    /**
     * thực hiện sự kiện khi ấn vào dòng dữ liệu ở bảng grid
     * created by SONTD(28.08.2022)
     * @param {*} event 
     */
    rowOnClick(event){
        let me = this;
        me.toolbarRight.indexOfRowSelected = event.target.closest(".s-tr").getAttribute("indexOfRow");
        if(me.$refs.showPotentialToolbarRight){
          if (me.data[me.toolbarRight.indexOfRowSelected]){
              // xử lí ẩn hiện và nội dung của thẻ người tạo
              if (me.data[me.toolbarRight.indexOfRowSelected].CreatedBy){
                  me.toolbarRight.isShowCreatedBy = true;
                  // biến lưu người thẻ div của người tạo
                  let created = me.$refs.showPotentialToolbarRight.querySelector(".trb-item:nth-child(1)");
                  if (created){
                      created.querySelector(".trbic-txt-name").innerHTML=me.data[me.toolbarRight.indexOfRowSelected].CreatedBy+" (A001)";
                      if (me.data[me.toolbarRight.indexOfRowSelected].CreatedDate){
                        created.querySelector(".trbic-txt-date").innerHTML=me.data[me.toolbarRight.indexOfRowSelected].CreatedDate.substring(0,10);
                      }else{
                        created.querySelector(".trbic-txt-date").innerHTML="";
                      }
                  }
              }else{
                me.toolbarRight.isShowCreatedBy = false;
              }
  
              // xử lí nội dung và ẩn hiện cho thẻ người thay đổi
              if (me.data[me.toolbarRight.indexOfRowSelected].ModifiedBy){
                  me.toolbarRight.isShowModifiedBy = true;
                  // biến lưu người thẻ div của người tạo
                  let modified = me.$refs.showPotentialToolbarRight.querySelector(".trb-item:nth-child(2)");
                  if (modified){
                      modified.querySelector(".trbic-txt-name").innerHTML=me.data[me.toolbarRight.indexOfRowSelected].ModifiedBy+" (A002)";
                      if (me.data[me.toolbarRight.indexOfRowSelected].ModifiedDate){
                        modified.querySelector(".trbic-txt-date").innerHTML=me.data[me.toolbarRight.indexOfRowSelected].ModifiedDate.substring(0,10);
                      }else{
                        modified.querySelector(".trbic-txt-date").innerHTML=" ";
                      }
                  }
              }else{
                me.toolbarRight.isShowModifiedBy = false;
              }
          }
        }
    },

    /**
     * xử lí sự kiện bấm ra ngoài row thì không hiện data ở toolbar right
     * created by SONTD(05.09.2022)
     */
     bodyGridOnClickOutside(){
        let me = this;
        me.toolbarRight.indexOfRowSelected = -1;
    },

    /**
     * láy dữ liệu từ filter bar để lọc
     * created by SONTD(29.08.2022)
     */
    getValueFilterData(value){
        let me = this;
        me.FilterData = value;
    },

    /**
     * bắt đầu lọc
     * created by SONTD(29.08.2022)
     */
    confirmFilterPotential(){
        let me = this;
        me.pageNumber =1;
        me.reloadDataGrid();
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
    // lấy data từ server
    this.getDataFromServer();
  },
  mounted() {
    this.getSelectedRow();
  },
  watch: {
      // lấy giá trị ô input search
      'searchString':function(){
        let me  = this;
          me.pageNumber = 1;
          me.reloadDataGrid();
      }
  }
};
</script>
<style scoped>
@import url("../../../style/common/button.css");
@import url("../../../style/view/potential/show/showPotential.css");
@import url("../../../style/view/potential/show/toolbarTop.css");
/* @import url("../../../style/view/potential/show/filterbarLeft.css"); */
@import url("../../../style/view/potential/show/mainContent.css");
@import url("../../../style/view/potential/show/toolbarRight.css");
.text-color-blue{
  color: #4262F0;
}
</style>