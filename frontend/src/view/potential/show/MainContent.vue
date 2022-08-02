<template>
    <div id="mainContent">
        <div id="potential-table">
            <div class="s-thead">
                <div class="s-tr">
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
            <div class="s-tbody">
                <div class="s-tr" v-for="(item, index) in items" :key="index">
                    <div class="s-td" v-for="i of item" :key="i">{{i}}</div>
                </div>
            </div>
        </div>
        <div class="footer">
        </div>
    </div>
</template>
<script>
import "../../../script/common/scollTable";
export default {
    data() {
        return {
            items : {
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
                    3:[
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
            }
        }
    },
    mounted() {
        document.querySelector(".s-table").addEventListener("scroll",this.handleScroll);
    },
    // unmounted() {
    //     document.querySelector(".s-table").removeEventListener("scroll",this.handleScroll);
    // },
    methods: {
        handleScroll(event){
            console.log("hehe");
            // let thead = document.querySelector(".s-thead");
            if (event.target.scrollLeft > 0){
                console.log(event.target.scrollLeft)
            }
        }
    },
}
</script>
<style scoped>
@import url("../../../style/view/potential/show/mainContent.css");
</style>