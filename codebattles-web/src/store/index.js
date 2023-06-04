import { createStore } from 'vuex'
import User from './Modules/User';
import Search from './Modules/Search';
import Profile from './Modules/Profile';
import Alert from "./Modules/Alert";

export default createStore({
    modules: {
        User,
        Search,
        Profile,
        Alert
    }
})