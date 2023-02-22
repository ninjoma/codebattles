import * as VueRouter from "vue-router";
import LobbyView from "../views/LobbyView.vue";

const routes: VueRouter.RouteRecordRaw[] = [
    { path: '/lobby', component: LobbyView },
]

const routerOptions: VueRouter.RouterOptions = {
    history: VueRouter.createWebHistory(),
    routes
}

export default VueRouter.createRouter(routerOptions);