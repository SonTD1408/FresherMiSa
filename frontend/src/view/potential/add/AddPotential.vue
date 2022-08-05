<template>
  <div id="contentAdd">
    <div class="toolbarTop">
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
                <div class="combobox-feild-box add-input-feild">
                  <div class="combobox-defalt">- Không chọn -</div>
                  <div class="combobox-icon"></div>
                  <div class="combobox-item-box" style="display: none">
                    <div class="combobox-item">lựa chọn 1</div>
                    <div class="combobox-item">lựa chọn 1</div>
                    <div class="combobox-item">lựa chọn 1</div>
                  </div>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Tên <span>*</span></div>
                <input
                  class="add-input-feild s-input"
                  v-model="potential['name']"
                  @blur="test"
                />
              </div>
              <div class="validate-error">Tên không được để trống</div>
              <div class="add-item">
                <div class="aib-txt">Phòng ban</div>
                <div class="combobox-feild-box add-input-feild">
                  <div class="combobox-defalt">- Không chọn -</div>
                  <div class="combobox-icon"></div>
                  <div class="combobox-item-box" style="display: none">
                    <div class="combobox-item">- Không chọn -</div>
                    <div class="combobox-item">Phòng ban 1</div>
                    <div class="combobox-item">Phòng ban 2</div>
                  </div>
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
                <div class="combobox-feild-box add-input-feild">
                  <div class="combobox-defalt">- Không chọn -</div>
                  <div class="combobox-icon"></div>
                  <div class="combobox-item-box" style="display: none">
                    <div class="combobox-item">- Không chọn -</div>
                    <div class="combobox-item">Nguồn gốc 1</div>
                    <div class="combobox-item">Nguồn gốc 2</div>
                  </div>
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
                <div class="combobox-feild-box add-input-feild">
                  <div class="combobox-defalt">- Không chọn -</div>
                  <div class="combobox-icon"></div>
                  <div class="combobox-item-box" style="display: none">
                    <div class="combobox-item">- Không chọn</div>
                    <div class="combobox-item">Chức danh 1</div>
                    <div class="combobox-item">Chức danh 2</div>
                  </div>
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
                <div class="combobox-feild-box add-input-feild">
                  <div class="combobox-defalt">- Không chọn -</div>
                  <div class="combobox-icon"></div>
                  <div class="combobox-item-box" style="display: none">
                    <div class="combobox-item">- Không chọn -</div>
                    <div class="combobox-item">Doanh thu 1</div>
                    <div class="combobox-item">Doanh thu 2</div>
                  </div>
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
                <div class="combobox-feild-box add-input-feild">
                  <div class="combobox-defalt">- Không chọn -</div>
                  <div class="combobox-icon"></div>
                  <div class="combobox-item-box" style="display: none">
                    <div class="combobox-item">- Không chọn</div>
                    <div class="combobox-item">Loại hình 1</div>
                    <div class="combobox-item">Loại hình 2</div>
                  </div>
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
                <div class="combobox-feild-box add-input-feild">
                  <div class="combobox-defalt">- Không chọn -</div>
                  <div class="combobox-icon"></div>
                  <div class="combobox-item-box" style="display: none">
                    <div class="combobox-item">- Không chọn -</div>
                    <div class="combobox-item">Quốc gia 1</div>
                    <div class="combobox-item">Quốc gia 2</div>
                  </div>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Quận/Huyện</div>
                <div class="combobox-feild-box add-input-feild">
                  <div class="combobox-defalt">- Không chọn -</div>
                  <div class="combobox-icon"></div>
                  <div class="combobox-item-box" style="display: none">
                    <div class="combobox-item">- Không chọn -</div>
                    <div class="combobox-item">Quận/Huyện 1</div>
                    <div class="combobox-item">Quận/Huyện 2</div>
                  </div>
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
                <div class="combobox-feild-box add-input-feild">
                  <div class="combobox-defalt">- Không chọn -</div>
                  <div class="combobox-icon"></div>
                  <div class="combobox-item-box" style="display: none">
                    <div class="combobox-item">- Không chọn -</div>
                    <div class="combobox-item">Tỉnh/Thành phố 1</div>
                    <div class="combobox-item">Tỉnh/Thành phố 2</div>
                  </div>
                </div>
              </div>
              <div class="add-item">
                <div class="aib-txt">Phường/Xã</div>
                <div class="combobox-feild-box add-input-feild">
                  <div class="combobox-defalt">- Không chọn -</div>
                  <div class="combobox-icon"></div>
                  <div class="combobox-item-box" style="display: none">
                    <div class="combobox-item">- Không chọn -</div>
                    <div class="combobox-item">Phường/Xã 1</div>
                    <div class="combobox-item">Phường/Xã 2</div>
                  </div>
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
  </div>
</template>
<script>
import buildCombobox from "../../../script/common/combobox.js";
export default {
  mounted() {
    buildCombobox();
  },
  data() {
    return {
      potential: [],
    };
  },
  methods: {
    test() {
      console.log(this.potential["name"]);
    },
  },
};
</script>
<style scoped>
@import url("../../../style/view/potential/add/addTopbar.css");
@import url("../../../style/view/potential/add/addMainContent.css");
@import url("../../../style/common/combobox.css");
</style>