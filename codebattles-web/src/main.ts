import { createApp } from 'vue';
import './style.css';
import App from './App.vue';
import Router from './router/index';
import { basicSetup } from "codemirror";
import VueCodeMirror from "vue-codemirror";
import { library } from '@fortawesome/fontawesome-svg-core';
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';
import Store from './store/index.js';
import SearchStore from "./store/Modules/Search.js";
import {
    faCrown, faCircleArrowUp, faUser, faRightFromBracket, faFlag,
    faPlus, faPenToSquare, faBars, faJetFighter, faBrain, faStopwatch,
    faXmark, faSkullCrossbones, faCircleXmark, faCircleExclamation, faTriangleExclamation, faCircleInfo, faCircleCheck, faFileImport
} from '@fortawesome/free-solid-svg-icons';
import axios from "axios";
import VueGtagPlugin from 'vue-gtag';
import { assertCompletionStatement } from '@babel/types';

if (import.meta.env.DEV) {
    // Allow CORS from localhost
    axios.defaults.headers.common["Access-Control-Allow-Origin"] = "*";
    axios.defaults.baseURL = "https://localhost:7297/";
} else {
    axios.defaults.baseURL = "https://codebattlesapi.azurewebsites.net/";
}

library.add(faCrown, faCircleArrowUp, faUser, faRightFromBracket,
    faFlag, faPlus, faPenToSquare, faBars, faJetFighter,
    faBrain, faStopwatch, faCircleXmark, faXmark, faCircleExclamation, faTriangleExclamation, faCircleInfo, faCircleCheck, faFileImport, faSkullCrossbones)

const app = createApp(App);

app.config.globalProperties.$store = Store;

axios.defaults.withCredentials = true;

app.use(Router)

    .use(Store)

    .use(VueGtagPlugin, {
        appName: "Codebattles",
        pageTrackerScreenviewEnabled: true,
        config: { id: "G-KK26T2CEXQ" }
    }, Router)

    .use(VueCodeMirror, {
        autofocus: false,
        disabled: false,
        indentWithTab: true,
        tabSize: 2,
        placeholder: 'No pressure... :)',
        extensions: [basicSetup]
    })

    .component('font-awesome-icon', FontAwesomeIcon)
    .mount('#app')


