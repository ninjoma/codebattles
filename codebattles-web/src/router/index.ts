import * as VueRouter from "vue-router";
import LobbyView from "../views/LobbyView.vue";
import ProfileView from "../views/ProfileView.vue";
import BattleView from "../views/BattleView.vue";
import LoginView from "../views/LoginView.vue";
import RegisterView from "../views/RegisterView.vue";
import ForgotPasswordView from "../views/ForgotPasswordView.vue";
import VerifyPasswordView from "../views/VerifyPasswordView.vue";
import LogoutView from "../views/LogoutView.vue";
import Store from '../store/index.js';
import AdminView from "../views/AdminView.vue";

const routes: VueRouter.RouteRecordRaw[] = [
    { path: '/lobby/:battleId', meta: {requiresAuth: true}, component: LobbyView, name: 'game'},
    { path: '/users/:id/profile', component: ProfileView, meta: {requiresAuth: true}, name: 'profile'},
    { path: '/battle', component: BattleView, meta: {requiresAuth: true}, name: 'battles' },
    { path: '/login', component: LoginView, name: 'login' },
    { path: '/', 
        redirect: to => {
            return { path: '/battle' }
        } 
    },
    { path: '/register', component: RegisterView, name: 'register' },
    { path: '/forgot-password', component: ForgotPasswordView, name: 'forgot-password' },
    { path: '/verify-password', component: VerifyPasswordView, name: 'verify-password' },
    { path: '/logout', component: LogoutView, meta: {requiresAuth: false}, name: 'logout' },
    { path: '/admin', component: AdminView, meta: {requiresAuth: true}, name: 'admin' },
]

const routerOptions: VueRouter.RouterOptions = {
    history: VueRouter.createWebHashHistory(),
    routes
}

var router = VueRouter.createRouter(routerOptions)

router.beforeEach((to, from, next) => {
    if(to.matched.some(record => record.meta.requiresAuth)) {
        if(!Store.getters['User/isLogged']) {
            return next({ path: '/login' });
        }
    }
    return next();
});


export default router;