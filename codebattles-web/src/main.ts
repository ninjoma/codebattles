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
import { faCrown, faCircleArrowUp, faUser, faRightFromBracket, faFlag,
    faPlus, faPenToSquare, faBars, faJetFighter, faBrain, faStopwatch, 
    faXmark, faXmarkCircle, faCircleXmark, faCircleExclamation, faTriangleExclamation, faCircleInfo, faCircleCheck } from '@fortawesome/free-solid-svg-icons';
import axios from "axios";
import VueGtagPlugin from 'vue-gtag';

if(import.meta.env.DEV) {
    // Allow CORS from localhost
    axios.defaults.headers.common["Access-Control-Allow-Origin"] = "*";
}

library.add(faCrown, faCircleArrowUp, faUser, faRightFromBracket, 
    faFlag, faPlus, faPenToSquare, faBars, faJetFighter,
    faBrain, faStopwatch, faCircleXmark, faXmark, faCircleExclamation, faTriangleExclamation, faCircleInfo, faCircleCheck)

const app = createApp(App);

app.config.globalProperties.$store = Store;

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


