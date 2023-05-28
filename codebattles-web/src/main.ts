import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import Router from './router/index'
import { basicSetup } from "codemirror";
import VueCodeMirror from "vue-codemirror";
import { library } from '@fortawesome/fontawesome-svg-core';
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';
import { faCrown, faCircleArrowUp, faUser, faRightFromBracket, faFlag, faPlus, faPenToSquare, faBars, faJetFighter, faBrain, faStopwatch, faXmark, faXmarkCircle, faCircleXmark } from '@fortawesome/free-solid-svg-icons';
import VueGtagPlugin from 'vue-gtag';

library.add(faCrown, faCircleArrowUp, faUser, faRightFromBracket, faFlag, faPlus, faPenToSquare, faBars, faJetFighter,
    faBrain, faStopwatch, faCircleXmark, faXmark)

createApp(App)

.use(Router)

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


