import * as VueRouter from "vue-router";
import LobbyView from "../views/LobbyView.vue";
import ProfileView from "../views/ProfileView.vue";
import BattleView from "../views/BattleView.vue";
import LoginView from "../views/LoginView.vue";
import RegisterView from "../views/RegisterView.vue";
import ForgotPasswordView from "../views/ForgotPasswordView.vue";

const routes: VueRouter.RouteRecordRaw[] = [
    { path: '/lobby/:battleId', component: LobbyView},
    { path: '/profile', component: ProfileView },
    { path: '/battle', component: BattleView },
    { path: '/login', component: LoginView },
    { path: '/register', component: RegisterView },
    { path: '/forgot-password', component: ForgotPasswordView }
]

const routerOptions: VueRouter.RouterOptions = {
    history: VueRouter.createWebHistory(),
    routes
}

export default VueRouter.createRouter(routerOptions);