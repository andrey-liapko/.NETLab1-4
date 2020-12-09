
<template>
    <div>
        <b-navbar toggleable="lg" type="dark" variant="info">
            <b-navbar-brand href="/Store">STORE</b-navbar-brand>
            <b-navbar-brand href="/StoreManager">STORE MANAGER</b-navbar-brand>






            <b-collapse id="nav-collapse" is-nav>
          

                <!-- Right aligned nav items -->
                <b-navbar-nav class="ml-auto">




                    <b-nav-form>
                        <div class="hkl">
                            <b-form-input class="mr-sm-2" placeholder="Search"></b-form-input>

                            <b-button size="sm" class="my-2 my-sm-0" type="submit">Search</b-button>
                        </div>
                    </b-nav-form>

                    <b-nav-item-dropdown right>
                        <!-- Using 'button-content' slot -->
                        <template #button-content>
                            <em>User</em>
                        </template>
                        <b-dropdown-item href="#">Profile</b-dropdown-item>
                        <b-dropdown-item href="#">Sign Out</b-dropdown-item>
                    </b-nav-item-dropdown>
                </b-navbar-nav>
            </b-collapse>
        </b-navbar>
    </div>


</template>
<script>
    export default {
        name: "menu-component",

        mounted() {
            console.log("count");

        }
    };
</script>
<style>
    .hkl {
        margin-bottom: -15px;
      
    }
</style>