import Vue from 'vue'
import DetailsComponent from './details.vue'
import BrowseComponent from './browse.vue'
import IndexComponent from './index.vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import BootstrapVue from "bootstrap-vue"
import { BNavbar, BNavbarToggle, BNavbarBrand, BNavItemDropdown, BCollapse, BDropdownItem, BNavbarNav, BNavForm, BFormInput, BButton, BLink } from 'bootstrap-vue'


Vue.component('b-navbar', BNavbar)
Vue.component('b-navbar-toggle', BNavbarToggle)
Vue.component('b-navbar-brand', BNavbarBrand)
Vue.component('b-nav-item-dropdown', BNavItemDropdown)
Vue.component('b-collapse', BCollapse)
Vue.component('b-dropdown-item', BDropdownItem)
Vue.component('b-navbar-nav', BNavbarNav)
Vue.component('b-nav-form', BNavForm)
Vue.component('b-form-input', BFormInput)
Vue.component('b-button', BButton)
Vue.component('b-link', BLink)

Vue.use(NavbarPlugin)

Vue.component(BootstrapVue)
Vue.component('b-list-group', BListGroup)
Vue.component('b-list-group-item', BListGroupItem)
new Vue({
    el: '#store',
    components: {
        DetailsComponent,
        BrowseComponent,
        IndexComponent
    }
})