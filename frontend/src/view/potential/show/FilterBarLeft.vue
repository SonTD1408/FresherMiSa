<template>
    <div id="filterbar-left" v-if="isShowFilterbarLeft">
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
                <div class="fsb-item" v-for="(item,index) in column" :key="index">
                    <input type="checkbox" class="fsbi-icon">
                    <div class="fsbi-label">{{item.VietnameseName}}</div>
                </div>
                
            </div>
        </div>
      </div>
</template>
<script>
export default{
    props:{
        isShowFilterbarLeft: Boolean,
    },
    data() {
        return {
            column: [
                {ColumnName: 'Tag', VietnameseName: 'Thẻ'},
                {ColumnName: 'VocativeName', VietnameseName: 'Xưng hô'},
                {ColumnName: 'FullName', VietnameseName: 'Họ và tên'},
                {ColumnName: 'PositionName', VietnameseName: 'Thẻ'},
                {ColumnName: 'PhoneNumber', VietnameseName: 'ĐT di động'},
                {ColumnName: 'OfficePhoneNumber', VietnameseName: 'ĐT cơ quan'},
                {ColumnName: 'OfficeEmail', VietnameseName: 'Email cơ quan'},
                {ColumnName: 'Email', VietnameseName: 'Email cá nhân'},
                {ColumnName: 'Organization', VietnameseName: 'Tổ chức'},
                {ColumnName: 'Address', VietnameseName: 'Địa chỉ'},
                {ColumnName: 'CityName', VietnameseName: 'Tỉnh/Thành phố'},
                {ColumnName: 'DistrictName', VietnameseName: 'Quận/Huyện'},
                {ColumnName: 'WardName', VietnameseName: 'Phường/Xã'},
                {ColumnName: 'SourceName', VietnameseName: 'Nguồn gốc'},
                {ColumnName: 'OrganizationTypeName', VietnameseName: 'Loại hình'},
                {ColumnName: 'FieldName', VietnameseName: 'Lĩnh vực'},
                {ColumnName: 'PotentialDescription', VietnameseName: 'Mô tả'},
                {ColumnName: 'no1', VietnameseName: 'Bố cục'},
                {ColumnName: 'no2', VietnameseName: 'Chủ sở hữu'},
                {ColumnName: 'ComeoverName', VietnameseName: 'Doanh thu'},
                {ColumnName: 'IsShare', VietnameseName: 'Dùng chung'},
                {ColumnName: 'Facebook', VietnameseName: 'Facebook'},
                

                
            ]
        }
    },
}
</script>
<style scoped>
@import url("../../../style/view/potential/show/filterbarLeft.css");
</style>