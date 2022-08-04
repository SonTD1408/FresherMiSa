import {createRouter, createWebHistory} from 'vue-router'
import ShowPotential from "../view/potential/show/ShowPotential"
import AddPotential from "../view/potential/add/AddPotential"
const routes = [
    {path: '/', component: ShowPotential},
    {path: '/potential/add', component: AddPotential}
]

const router = createRouter({
    history: createWebHistory(),
    routes,
})

export default router;