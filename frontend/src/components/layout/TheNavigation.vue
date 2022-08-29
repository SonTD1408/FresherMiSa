<template>
    <div id="navigation" ref="navigation">
        <div to="/other" class="nav-item" @click="goTo">
            <div class="nt-icon nt-icon-1"></div>
            <div class="nt-label">Bàn làm việc</div>
        </div>
        <div to="/" class="nav-item nav-item-selected" @click="goTo">
            <div class="nt-icon nt-icon-2"></div>
            <div class="nt-label">Tiềm năng</div>
        </div>
        <div to="/other" class="nav-item" @click="goTo">
            <div class="nt-icon nt-icon-3"></div>
            <div class="nt-label">Chào hàng</div>
        </div>
        <div to="/other" class="nav-item" @click="goTo">
            <div class="nt-icon nt-icon-4"></div>
            <div class="nt-label">Liên hệ</div>
        </div>
        <div to="/other" class="nav-item" @click="goTo">
            <div class="nt-icon nt-icon-5"></div>
            <div class="nt-label">Khách hàng</div>
        </div>
        <div to="/other" class="nav-item" @click="goTo">
            <div class="nt-icon nt-icon-6"></div>
            <div class="nt-label">Cơ hội</div>
        </div>
        <div to="/other" class="nav-item" @click="goTo">
            <div class="nt-icon nt-icon-7"></div>
            <div class="nt-label">Báo giá</div>
        </div>
        <div to="/other" class="nav-item" @click="goTo">
            <div class="nt-icon nt-icon-8"></div>
            <div class="nt-label">Đơn hàng</div>
        </div>
        <div to="/other" class="nav-item" @click="goTo">
            <div class="nt-icon nt-icon-9"></div>
            <div class="nt-label">Hóa đơn</div>
        </div>
        <div to="/other" class="nav-item" @click="goTo">
            <div class="nt-icon nt-icon-10"></div>
            <div class="nt-label">Ao cơ hội</div>
        </div>
        <div to="/other" class="nav-item" @click="goTo">
            <div class="nt-icon nt-icon-11"></div>
            <div class="nt-label">Hoạt động</div>
        </div>
        <div to="/other" class="nav-item" @click="goTo">
            <div class="nt-icon nt-icon-12"></div>
            <div class="nt-label">Mục tiêu</div>
        </div>
        <div to="/other" class="nav-item" @click="goTo">
            <div class="nt-icon nt-icon-13"></div>
            <div class="nt-label">Chiến dịch</div>
        </div>
        <div to="/other" class="nav-item" @click="goTo">
            <div class="nt-icon nt-icon-14"></div>
            <div class="nt-label">Khác</div>
        </div>
        
    </div>
</template>
<script>
export default {
    methods: {
        goTo(event){
            let me = this;
            if (me.$refs.navigation.querySelector(".nav-item-selected")){
                me.$refs.navigation.querySelector(".nav-item-selected").classList.remove("nav-item-selected");
            }
            event.target.closest(".nav-item").classList.add("nav-item-selected");
            let to = event.target.closest(".nav-item").getAttribute("to");
            me.$router.push(to);
        }
    },   
}
</script>
<style scoped>
    @import url("../../style/layout/navigation.css");
</style>