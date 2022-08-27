<template>
    <div id="tool-tip" v-click-outside="onClickOutside">
        <div class="tool-tip-bottom-center">
            <div class="tool-tip-txt">{{msg}}</div>
            <div class="tool-tip-arrow"></div>
        </div>
    </div>
</template>
<script>
import vClickOutside from "click-outside-vue3"
export default{
    directives: {
      clickOutside: vClickOutside.directive
    },
    props: {
        // message của tooltip
        msg: String,
    },
    methods: {
        /**
         * hàm thực hiện khi ấn ra ngoài tooltip, ẩn tooltip
         */
        onClickOutside(){
            this.$emit("tooltipClickOutside");
        }
    },
}
</script>
<style scoped>
    #tool-tip{
        position: absolute;
        z-index: 1;
        bottom: calc(100% + 12px);
        transform: translateX(calc(-50% + 8px));
        font-weight: 100;
        font-size: 13px;
        background-color: #424857;
        border-radius: 4px;
        height: 32px;
    }
    .tool-tip-bottom-center{
        position: relative;
        height: 100%;
        /* width: 100%; */
        padding: 0 16px;
    }
    .tool-tip-bottom-center .tool-tip-arrow{
        position: absolute;
        z-index: -1;
        top: calc(100% - 12px);
        left: calc(50% - 8px);
        height: 16px;
        width: 16px;
        transform: rotate(45deg);
        background-color: #424857;
    }
    .tool-tip-txt{
        color: #fff;
        line-height: 32px;
        white-space: nowrap;
    }
</style>