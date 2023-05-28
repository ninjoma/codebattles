import * as VueRouter from "vue-router";
import LobbyView from "../views/LobbyView.vue";
import ProfileView from "../views/ProfileView.vue";
import BattleView from "../views/BattleView.vue";
import LoginView from "../views/LoginView.vue";
import RegisterView from "../views/RegisterView.vue";
import ForgotPasswordView from "../views/ForgotPasswordView.vue";

const routes: VueRouter.RouteRecordRaw[] = [
    { name: 'Lobby', path: '/lobby', component: LobbyView },
    { name: 'Profile', path: '/profile', component: ProfileView },
    { name: 'Battle', path: '/battle', component: BattleView },
    { name: 'Login', path: '/login', component: LoginView },
    { name: 'Register', path: '/register', component: RegisterView },
    { name: 'Forgot Password', path: '/forgot-password', component: ForgotPasswordView }
]

const routerOptions: VueRouter.RouterOptions = {
    history: VueRouter.createWebHistory(),
    routes
}

export default VueRouter.createRouter(routerOptions);