<template>
  <div id="contentShow">
    <div class="toolbarTop">
      <div id="toolbarTop">
        <!-- tool bar top left  -->
        <div class="tt-left" v-if="toolbarTopLeftStatus=='normal'">
          <div class="ttl-name">
            <div class="ttl-name-txt">Tất cả tiềm năng</div>
            <div class="ttl-name-icon"></div>
          </div>
          <div class="ttl-action">Sửa</div>
          <div class="ttl-refresh"></div>
        </div>
        <div class="tt-left" v-if="toolbarTopLeftStatus=='rowSelected'">
          <div class="ttl-choosed">Đã chọn <span>{{numberOfRowSelected}}</span></div>
          <div class="tll-fogot-choose" @click="forgotChoosed">Bỏ chọn</div>
          <button class="s-button-gray ttl-button-update" @click="hideShowUpdateMany(true)">
            <div class="ttlbu-icon"></div> Cập nhật thông tin
          </button>
          <div class="ttl-option"></div>
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
          <div class="ttr-option">
            <div class="ttr-option-icon"></div>
          </div>
          <div class="ttr-option-combo">
            <div class="ttroc-list-icon-box">
              <div class="ttroc-list-icon"></div>
            </div>
            <div class="ttroc-dropdown-icon-box">
              <div class="ttroc-dropdown-icon"></div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="potentialContent">
      <div id="filterbarLeft" v-if="isShowFilterbarLeft">
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
            <div class="fsb-item">
              <input type="checkbox" class="fsbi-icon">
              <div class="fsbi-label">Thẻ</div>
            </div>
            <div class="fsb-item">
              <input type="checkbox" class="fsbi-icon">
              <div class="fsbi-label">Xưng hô</div>
            </div>
            <div class="fsb-item">
              <input type="checkbox" class="fsbi-icon">
              <div class="fsbi-label">Họ và tên</div>
            </div>
            <div class="fsb-item">
              <input type="checkbox" class="fsbi-icon"/>
              <div class="fsbi-label">Chức danh</div>
            </div>
            <div class="fsb-item">
              <input type="checkbox" class="fsbi-icon"/>
              <div class="fsbi-label">ĐT di động</div>
            </div>
            <div class="fsb-item">
              <input type="checkbox" class="fsbi-icon"/>
              <div class="fsbi-label">ĐT cơ quan</div>
            </div>
            <div class="fsb-item">
              <input type="checkbox" class="fsbi-icon"/>
              <div class="fsbi-label">Email cơ quan</div>
            </div>
            <div class="fsb-item">
              <input type="checkbox" class="fsbi-icon"/>
              <div class="fsbi-label">Email cá nhân</div>
            </div>
            <div class="fsb-item">
              <input type="checkbox" class="fsbi-icon"/>
              <div class="fsbi-label">Tổ chức</div>
            </div>
            <div class="fsb-item">
              <input type="checkbox" class="fsbi-icon"/>
              <div class="fsbi-label">Địa chỉ</div>
            </div>
            <div class="fsb-item">
              <input type="checkbox" class="fsbi-icon"/>
              <div class="fsbi-label">Tỉnh/Thành phố</div>
            </div>
            <div class="fsb-item">
              <input type="checkbox" class="fsbi-icon"/>
              <div class="fsbi-label">Quận/Huyện</div>
            </div>
            <div class="fsb-item">
              <input type="checkbox" class="fsbi-icon"/>
              <div class="fsbi-label">Phường/Xã</div>
            </div>
            <div class="fsb-item">
              <input type="checkbox" class="fsbi-icon"/>
              <div class="fsbi-label">Nguồn gốc</div>
            </div>
            <div class="fsb-item">
              <input type="checkbox" class="fsbi-icon"/>
              <div class="fsbi-label">Loại hình</div>
            </div>
            <div class="fsb-item">
              <input type="checkbox" class="fsbi-icon"/>
              <div class="fsbi-label">Lĩnh vực</div>
            </div>
            <div class="fsb-item">
              <input type="checkbox" class="fsbi-icon"/>
              <div class="fsbi-label">Mô tả</div>
            </div>
            <div class="fsb-item">
              <input type="checkbox" class="fsbi-icon"/>
              <div class="fsbi-label">Bố cục</div>
            </div>
            <div class="fsb-item">
              <input type="checkbox" class="fsbi-icon"/>
              <div class="fsbi-label">Chủ sở hữu</div>
            </div>
            <div class="fsb-item">
              <input type="checkbox" class="fsbi-icon"/>
              <div class="fsbi-label">Doanh thu</div>
            </div>
            <div class="fsb-item">
              <input type="checkbox" class="fsbi-icon"/>
              <div class="fsbi-label">Dùng chung</div>
            </div>
            <div class="fsb-item">
              <input type="checkbox" class="fsbi-icon"/>
              <div class="fsbi-label">Facebook</div>
            </div>
          </div>
        </div>
      </div>
      <div id="mainContent">
        <div class="filterbarLeftShowHideBtn" @click="hideShowFilterbarLeft">
          <div class="filterbarLeftShowHideBtn-icon"></div>
        </div>
        <div class="toolbarRightShowHideBtn" @click="hideShowToolbarRight">
          <div class="toolbarRightShowHideBtn-icon"></div>
        </div>
        <div id="potential-table">
          <div class="s-thead">
            <div class="s-tr">
                <div class="s-th align-right">
                    <div class="s-th-export-icon"></div>
                    <!-- <div class="s-th-select-icon"></div> -->
                    <input type="checkbox" class="s-th-select-icon">
                </div>
              <div class="s-th">Thẻ</div>
              <div class="s-th">Xưng hô</div>
              <div class="s-th">Họ và tên</div>
              <div class="s-th">Chức danh</div>
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
              <div class="s-th">Dùng chung</div>
            </div>
          </div>
          <div class="s-tbody" v-on:scroll="handleScroll">
            <div class="s-tr" v-for="(item, index) in data" :key="index" :idOfRow="item.PotentialID">
              <div class="s-td align-right">
                    <input type="checkbox" class="s-th-select-icon" isChecked="false" @click="gridCheckboxOnClick">
              </div>
              <div class="s-td" v-for="(i,ind) in columns" :key="ind">
                  <div class="cell-phone-icon" v-if="ind==5 || ind==4"></div>
                  <div v-if="ind!=2">{{formatNullData(item[i])}}</div>
                  <div v-if="ind==2">{{formatNullData(`${item['LastName']} ${item['FirstName']}`)}}</div>
              </div>
            </div>
          </div>
        </div>
        <div class="footer">
          <div class="footer-left">Total: <span :innerHTML="numberOfRecord"></span></div>
          <div class="footer-right">
            <div class="footer-page-size" @click="pageSizeOnClick"><span>{{pageSize}}</span> 
               Bản ghi trên Trang
              <div class="fps-dropdown"></div>
              <div class="fps-combobox" v-if="isShowPagesizeCombobox">
                <div class="fpsc-item" Value="10" @click="changePageSizeOnClick">
                  10 Bản ghi trên Trang
                </div>
                <div class="fpsc-item" Value="20" @click="changePageSizeOnClick">
                  20 Bản ghi trên Trang
                </div>
                <div class="fpsc-item" Value="50" @click="changePageSizeOnClick">
                  50 Bản ghi trên Trang
                </div>
                <div class="fpsc-item" Value="100" @click="changePageSizeOnClick">
                  100 Bản ghi trên Trang
                </div>
              </div>
            </div>
            <div class="footer-paging">
                <div class="fp-first"></div>
                <div class="fp-prev"></div>
                <div class="fp-txt"><span class="from">1</span>đến<span class="to">50</span></div>
                <div class="fp-next"></div>
                <div class="fp-last"></div>
            </div>
          </div>
        </div>
      </div>
      <div id="toolbarRight" v-if="isShowToolbarRight">
        <div class="tr-header">
          <div class="trh-item">
            <div class="trh-item-icon trh-item-icon1"></div>
          </div>
          <div class="trh-item">
            <div class="trh-item-icon trh-item-icon2"></div>
          </div>
          <div class="trh-item">
            <div class="trh-item-icon trh-item-icon3"></div>
          </div>
          <div class="trh-item">
            <div class="trh-item-icon trh-item-icon4"></div>
          </div>
        </div>
        <div class="tr-body">
          <div class="tr-body-title">Lịch sử giao dịch</div>
          <div class="trb-item-box">
            <div class="trb-item">
              <div class="trb-item-icon-box">
                <div class="trb-item-icon"></div>
              </div>
              <div class="trb-item-content">
                <div class="trbic-type">Ghi chú</div>
                <div class="trbic-txt">Nguyễn Văn Hà (A006) . 12/08/2021</div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <UpdateMany :isShow="isShowUpdateMany" @hideShowStatus="hideShowUpdateMany"></UpdateMany>
  </div>

</template>
<script>
import UpdateMany from "../update/UpdateMany.vue"
import axios from "axios"
export default {
  components:{
    UpdateMany
  },
  data() {
    return {
      // biến đếm số dòng được chọn
      numberOfRowSelected: 0,
      // biến thay đổi trạng thái của toolbar top
      toolbarTopLeftStatus: "normal",
      // biến chọn page size
      isShowPagesizeCombobox: false,
      // biến ẩn hiện thanh bên trái
      isShowFilterbarLeft: true,
      //biến ẩn hiện thanh bên phải
      isShowToolbarRight: true,
      // biến ẩn hiện update many dialog
      isShowUpdateMany: false,
      //số bản ghi trên trang
      pageSize : "50",
      // số trang 
      pageNumber: 1,
      // các cột trong 1 dòng dữ liệu 
      columns: [
        "PotentialCode",
        "Vocative",
        "FirstName",
        "PositionName",
        "PhoneNumber",
        "OfficePhoneNumber",
        "OfficeEmail",
        "Email",
        "OrganizationName",
        "Address",
        "CityName",
        "DistrictName",
        "WardName",
        "SourceName",
        "DescriptionP",
        "SharedP"
      ],
      // data của bảng lấy từ server 
      data: {},
      // số lượng bản ghi lấy từ db 
      numberOfRecord: 0,

    };
  },

  methods: {
    /**
     * hàm lấy tiềm năng từ serve
     * created by SONTD (07.08.2022)
     */
    getPotentialFromServer(){
      try{
        axios
        .get(`http://localhost:5091/api/Potential?pageSize=${this.pageSize}&pageNumber=${this.pageNumber}`)
        .then((response) => {
            this.data = response.data.PotentialList;
            console.log(this.data[0]);
            this.numberOfRecord = response.data.NumberOfRecord;
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
        const thead = document.querySelector(".s-thead");
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
      this.isShowPagesizeCombobox = !this.isShowPagesizeCombobox
    },

    /**
     * hàm lấy page size khi người dùng đổi page size
     * Created by SONTD (04.08.2022)
     */
    changePageSizeOnClick(e){
      this.pageSize = e.target.getAttribute("Value");
      this.pageNumber =1;
      this.getPotentialFromServer();
    },

    /**
     * hàm ẩn hiện thanh lọc dữ liệu
     * Created by SONTD (04.08.2022)
     */
    hideShowFilterbarLeft(){
      if(this.isShowFilterbarLeft){
        document.querySelector(".filterbarLeftShowHideBtn-icon").style.transform="rotate(180deg)"
      }else{
        document.querySelector(".filterbarLeftShowHideBtn-icon").style.transform="rotate(0)"
      }
      this.isShowFilterbarLeft = !this.isShowFilterbarLeft
    },

    /**
     * hàm ẩn hiện thanh toolbar bên phải
     * Created by SONTD (04.08.2022)
     */
    hideShowToolbarRight(){
      if(this.isShowToolbarRight){
        document.querySelector(".toolbarRightShowHideBtn-icon").style.transform="rotate(180deg)"
      }else{
        document.querySelector(".toolbarRightShowHideBtn-icon").style.transform="rotate(0)"
      }
      this.isShowToolbarRight = !this.isShowToolbarRight
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
      this.toolbarTopLeftStatus="normal";
      document.querySelectorAll(".s-tr").forEach(function(tr){
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
      this.isShowUpdateMany = param;
    },

    /**
     * hàm check value, nếu null thì chuyển thành -
     * @param {*} value 
     */
    formatNullData(value){
      console.log(value);
      if (value=="" || value==null || value==undefined){
        return "-"
      }
      else{
        return value;
      }
    }
  },
  created() {
    this.getPotentialFromServer();
  },
};
</script>
<style scoped>
@import url("../../../style/view/potential/show/showPotential.css");
@import url("../../../style/view/potential/show/toolbarTop.css");
@import url("../../../style/view/potential/show/filterbarLeft.css");
@import url("../../../style/view/potential/show/mainContent.css");
@import url("../../../style/view/potential/show/toolbarRight.css");
@import url("../../../style/common/button.css");
</style>