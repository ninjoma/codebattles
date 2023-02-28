import * as VueRouter from "vue-router";
import LobbyView from "../views/LobbyView.vue";
import ProfileView from "../views/ProfileView.vue";

const routes: VueRouter.RouteRecordRaw[] = [
    { path: '/lobby', component: LobbyView },
    { path: '/profile', component: ProfileView }
]

const routerOptions: VueRouter.RouterOptions = {
    history: VueRouter.createWebHistory(),
    routes
}

export default VueRouter.createRouter(routerOptions);