import { createStore } from 'vuex'
import User from './Modules/User'
import Search from './Modules/Search'
import Profile from './Modules/Profile'

export default createStore({
    modules: {
        User,
        Search,
        Profile
    }
})