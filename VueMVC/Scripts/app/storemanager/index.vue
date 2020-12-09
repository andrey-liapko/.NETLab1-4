

<template>
    <div id="index">
        <h2>Select from {{Count}} genres:</h2>
        <ul v-for="item in Categories">
            <li><a :href="EditUrl+'?category='+item.Name">{{item.Name}}</a></li>
        </ul>
    </div>

</template>
<script>
   
    
    export default {
        name: "index-component",
        props: {
            count: String,
            ArrCategory: Array,
            EditUrl: String
        },
        data() {
            return {
                Count: this.count,
                Categories: this.ArrCategory
            }
        },
        mounted() {
            console.log("count");
            console.log(this.Count);
            console.log("categ");
            console.log(this.Categories);
        }
    };
</script>