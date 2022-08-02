<template>
  <div id="content">
    <div class="toolbarTop">
      <div id="toolbarTop">
        <div class="tt-left">
          <div class="ttl-name">
            <div class="ttl-name-txt">Tất cả tiềm năng</div>
            <div class="ttl-name-icon"></div>
          </div>
          <div class="ttl-action">Sửa</div>
          <div class="ttl-refresh"></div>
        </div>
        <div class="tt-right">
          <div class="s-button-combo-container">
            <div class="sbcc-box">
              <button class="sbcc-button">
                <div class="sbcc-icon icon-page"></div>
                Thêm
              </button>
              <!-- <div class="sbcc-icon icon-page"></div> -->
              <div class="sbcc-type">
                <div class="sbcc-type-dropdown-icon"></div>
              </div>
            </div>
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
      <div id="filterbarLeft">
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
              <div class="fsbi-icon"></div>
              <div class="fsbi-label">Thẻ</div>
            </div>
            <div class="fsb-item">
              <div class="fsbi-icon"></div>
              <div class="fsbi-label">Xưng hô</div>
            </div>
            <div class="fsb-item">
              <div class="fsbi-icon"></div>
              <div class="fsbi-label">Họ và tên</div>
            </div>
            <div class="fsb-item">
              <div class="fsbi-icon"></div>
              <div class="fsbi-label">Chức danh</div>
            </div>
            <div class="fsb-item">
              <div class="fsbi-icon"></div>
              <div class="fsbi-label">ĐT di động</div>
            </div>
            <div class="fsb-item">
              <div class="fsbi-icon"></div>
              <div class="fsbi-label">ĐT cơ quan</div>
            </div>
            <div class="fsb-item">
              <div class="fsbi-icon"></div>
              <div class="fsbi-label">Email cơ quan</div>
            </div>
            <div class="fsb-item">
              <div class="fsbi-icon"></div>
              <div class="fsbi-label">Email cá nhân</div>
            </div>
            <div class="fsb-item">
              <div class="fsbi-icon"></div>
              <div class="fsbi-label">Tổ chức</div>
            </div>
            <div class="fsb-item">
              <div class="fsbi-icon"></div>
              <div class="fsbi-label">Địa chỉ</div>
            </div>
          </div>
        </div>
      </div>
      <div id="mainContent">
        <div id="potential-table">
          <div class="s-thead">
            <div class="s-tr">
                <div class="s-th">
                    <div class="s-th-export-icon"></div>
                    <div class="s-th-select-icon"></div>
                </div>
              <div class="s-th">Thẻ</div>
              <div class="s-th">Xưng hô</div>
              <div class="s-th">Họ và tên</div>
              <div class="s-th">Chức danh</div>
              <div class="s-th">ĐT di động</div>
              <div class="s-th">ĐT cơ quan</div>
              <div class="s-th">Email cơ quan</div>
              <div class="s-th">Email cá nhân</div>
              <div class="s-th">MS thuế</div>
              <div class="s-th">Loại tiềm năng</div>
              <div class="s-th">@@</div>
            </div>
          </div>
          <div class="s-tbody" v-on:scroll="handleScroll">
            <div class="s-tr" v-for="(item, index) in items" :key="index">
              <div class="hi"></div>
              <div class="s-td" v-for="i of item" :key="i">{{ i }}</div>
            </div>
          </div>
        </div>
        <div class="footer"></div>
      </div>
      <div id="toolbarRight">
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
  </div>
</template>
<script>
// import ToolbarTop from "./ToolbarTop.vue"
// import MainContent from "./MainContent.vue"
// import FilterbarLeft from "./FilterbarLeft.vue"
// import ToolbarRight from "./ToolbarRight.vue"

export default {
  data() {
    return {
      items: {
        1: [
          "hihi",
          "Anh",
          "Trần Nhật Vũ",
          "Trưởng phòng",
          "123098123",
          "098123099",
          "tadinhson@gmail.com",
          "sonn@gmail.c.cc.c",
          "12309812309",
          "Loại tiềm năng",
          "vũ cc",
        ],
        2: [
          "hihi",
          "Anh",
          "Trần Nhật Vũ",
          "Trưởng phòng",
          "123098123",
          "098123099",
          "tadinhson@gmail.com",
          "sonn@gmail.c.cc.c",
          "12309812309",
          "Loại tiềm năng",
          "vũ cc",
        ],
        3: [
          "hihi",
          "Anh",
          "Trần Nhật Vũ",
          "Trưởng phòng",
          "123098123",
          "098123099",
          "tadinhson@gmail.com",
          "sonn@gmail.c.cc.c",
          "12309812309",
          "Loại tiềm năng",
          "vũ cc",
        ],
        4: [
          "hihi",
          "Anh",
          "Trần Nhật Vũ",
          "Trưởng phòng",
          "123098123",
          "098123099",
          "tadinhson@gmail.com",
          "sonn@gmail.c.cc.c",
          "12309812309",
          "Loại tiềm năng",
          "vũ cc",
        ],
        5: [
          "hihi",
          "Anh",
          "Trần Nhật Vũ",
          "Trưởng phòng",
          "123098123",
          "098123099",
          "tadinhson@gmail.com",
          "sonn@gmail.c.cc.c",
          "12309812309",
          "Loại tiềm năng",
          "vũ cc",
        ],
        6: [
          "hihi",
          "Anh",
          "Trần Nhật Vũ",
          "Trưởng phòng",
          "123098123",
          "098123099",
          "tadinhson@gmail.com",
          "sonn@gmail.c.cc.c",
          "12309812309",
          "Loại tiềm năng",
          "vũ cc",
        ],
        7: [
          "hihi",
          "Anh",
          "Trần Nhật Vũ",
          "Trưởng phòng",
          "123098123",
          "098123099",
          "tadinhson@gmail.com",
          "sonn@gmail.c.cc.c",
          "12309812309",
          "Loại tiềm năng",
          "vũ cc",
        ],
        8: [
          "hihi",
          "Anh",
          "Trần Nhật Vũ",
          "Trưởng phòng",
          "123098123",
          "098123099",
          "tadinhson@gmail.com",
          "sonn@gmail.c.cc.c",
          "12309812309",
          "Loại tiềm năng",
          "vũ cc",
        ],
        9: [
          "hihi",
          "Anh",
          "Trần Nhật Vũ",
          "Trưởng phòng",
          "123098123",
          "098123099",
          "tadinhson@gmail.com",
          "sonn@gmail.c.cc.c",
          "12309812309",
          "Loại tiềm năng",
          "vũ cc",
        ],
        10: [
          "hihi",
          "Anh",
          "Trần Nhật Vũ",
          "Trưởng phòng",
          "123098123",
          "098123099",
          "tadinhson@gmail.com",
          "sonn@gmail.c.cc.c",
          "12309812309",
          "Loại tiềm năng",
          "vũ cc",
        ],
        11: [
          "hihi",
          "Anh",
          "Trần Nhật Vũ",
          "Trưởng phòng",
          "123098123",
          "098123099",
          "tadinhson@gmail.com",
          "sonn@gmail.c.cc.c",
          "12309812309",
          "Loại tiềm năng",
          "vũ cc",
        ],
        12: [
          "hihi",
          "Anh",
          "Trần Nhật Vũ",
          "Trưởng phòng",
          "123098123",
          "098123099",
          "tadinhson@gmail.com",
          "sonn@gmail.c.cc.c",
          "12309812309",
          "Loại tiềm năng",
          "vũ cc",
        ],
        13: [
          "hihi",
          "Anh",
          "Trần Nhật Vũ",
          "Trưởng phòng",
          "123098123",
          "098123099",
          "tadinhson@gmail.com",
          "sonn@gmail.c.cc.c",
          "12309812309",
          "Loại tiềm năng",
          "vũ cc",
        ],
        14: [
          "hihi",
          "Anh",
          "Trần Nhật Vũ",
          "Trưởng phòng",
          "123098123",
          "098123099",
          "tadinhson@gmail.com",
          "sonn@gmail.c.cc.c",
          "12309812309",
          "Loại tiềm năng",
          "vũ cc",
        ],
      },
    };
  },
  mounted() {
  },
  methods: {
    handleScroll(event){
        const thead = document.querySelector(".s-thead");
        if (event.target.scrollLeft>0){
            const translateX = -event.target.scrollLeft +"px";
            thead.style.transform = `translateX(${translateX})`;
        }else{
            thead.style.transform = "translateX(0)";
        }
    }
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