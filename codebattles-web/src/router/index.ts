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
    { path: '/lobby/:battleId', component: LobbyView},
    { path: '/users/:id/profile', component: ProfileView, meta: {requiresAuth: true} },
    { path: '/battle', component: BattleView },
    { path: '/login', component: LoginView },
    { path: '/register', component: RegisterView },
    { path: '/forgot-password', component: ForgotPasswordView }
    { path: '/logout', component: LogoutView, meta: {requiresAuth: false} }
]

const routerOptions: VueRouter.RouterOptions = {
    history: VueRouter.createWebHistory(),
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