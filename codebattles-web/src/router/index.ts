import * as VueRouter from "vue-router";
import LobbyView from "../views/LobbyView.vue";
import ProfileView from "../views/ProfileView.vue";
import BattleView from "../views/BattleView.vue";
import LoginView from "../views/LoginView.vue";
import RegisterView from "../views/RegisterView.vue";
import ForgotPasswordView from "../views/ForgotPasswordView.vue";
import LogoutView from "../views/LogoutView.vue";
import Store from '../store/index.js';

const routes: VueRouter.RouteRecordRaw[] = [
    { path: '/lobby', component: LobbyView, meta: {requiresAuth: true} },
    { path: '/users/:id/profile', component: ProfileView, meta: {requiresAuth: true} },
    { path: '/battle', component: BattleView, meta: {requiresAuth: true} },
    { path: '/login', component: LoginView, meta: {requiresAuth: false} },
    { path: '/register', component: RegisterView, meta: {requiresAuth: false} },
    { path: '/forgot-password', component: ForgotPasswordView, meta: {requiresAuth: false} },
    { path: '/logout', component: LogoutView, meta: {requiresAuth: false} }
]

const routerOptions: VueRouter.RouterOptions = {
    history: VueRouter.createWebHistory(),
    routes
}

var router = VueRouter.createRouter(routerOptions)

router.beforeEach((to, from, next) => {
    if(to.matched.some(record => record.meta.requiresAuth)) {
        if(!Store.getters.isLogged) {
            return next({ path: '/login' });
        }
    }
    return next();
});


export default router;