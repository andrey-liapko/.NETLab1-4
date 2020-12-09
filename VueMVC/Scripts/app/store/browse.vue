<template>
    <div id="browse">
        <h2>Your {{Name}}</h2>
        <div class="list-group" v-for="item in ArrItems">

            <a class="list-group-item list-group-item-action" :href="DetailsUrl+'/'+item.ItemId">{{item.Title}}</a>
        </div>
    </div>

</template>
<script>
    export default {
        name: "browse-component",
        props: {
            name: String,
            ArrItems: Array,
            DetailsUrl: String
        },
        data() {
            return {
                Name: this.name,
                ArrItems: this.ArrItems
            }
        },
        mounted() {
            console.log("ddd");
            console.log(this.ArrItems);
            console.log(this.name);
        }
    };
</script>