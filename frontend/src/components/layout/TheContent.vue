<template>
    <div id="content">
        <ShowPotential></ShowPotential>
    </div>
</template>
<script>
// import ToolbarTop from "../../view/potential/ToolbarTop.vue"
// import MainContent from "../../view/potential/MainContent.vue"
// import FilterbarLeft from "../../view/potential/FilterbarLeft.vue"
// import ToolbarRight from "../../view/potential/ToolbarRight.vue"
import ShowPotential from "../../view/potential/show/ShowPotential.vue"

export default {
    components:{
        ShowPotential,
    }
}
</script>
<style scoped>
    @import url("../../style/layout/content.css");
</style>