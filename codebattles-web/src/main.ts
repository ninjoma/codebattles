import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import Router from './router/index'
import { basicSetup } from "codemirror";
import VueCodeMirror from "vue-codemirror";

createApp(App)

.use(Router)

.use(VueCodeMirror, {
    autofocus: false,
    disabled: false,
    indentWithTab: true,
    tabSize: 2,
    placeholder: 'No pressure... :)',
    extensions: [basicSetup]
})


.mount('#app')


