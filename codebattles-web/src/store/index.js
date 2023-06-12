import { createStore } from 'vuex'
import User from './Modules/User';
import Search from './Modules/Search';
import Profile from './Modules/Profile';
import Alert from "./Modules/Alert";
import Game from "./Modules/Game";
import Language from "./Modules/Language";
import Gamemode from "./Modules/Gamemode";
import Stats from "./Modules/Stats";

export default createStore({
    modules: {
        User,
        Search,
        Profile,
        Alert,
        Game,
        Language,
        Gamemode,
        Stats
    }
})