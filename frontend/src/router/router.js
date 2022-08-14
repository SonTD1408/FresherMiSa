import {createRouter, createWebHistory} from 'vue-router'
import ShowPotential from "../view/potential/show/ShowPotential"
import AddPotential from "../view/potential/add/AddPotential"
import UpdateById from "../view/potential/update/UpdateById"
const routes = [
    {path: '/', component: ShowPotential},
    {path: '/potential/add', component: AddPotential},
    {path: '/potential/update', component: UpdateById, name: "potential.update"}
]

const router = createRouter({
    history: createWebHistory(),
    routes,
})

export default router;