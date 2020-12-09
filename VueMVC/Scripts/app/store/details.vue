<template>
    <div id="details">
        <h2>Your {{Title}}</h2>
   
 
        <p>
            <img alt="Title"
                 src="ItemArtUrl" />
        </p>
        <div id="item-details">
            <p>
                <em>Category:</em>
                {{Category.Name}}
            </p>
            <p>
                <em>Producer:</em>
                {{Producer.Name}}
            </p>
            <p>
                <em>Price:</em>
            {{Price}}
            </p>
            <b-button href="">Add to cart</b-button>
            <p class="button1">

                @Html.ActionLink("Add to cart", "AddToCart",
                "ShoppingCart", new { id = Model.ItemId }, "")
            </p>
            <div class="fb-comments" data-width="230" data-numposts="5"></div>
        </div>
    </div>

</template>
<script>
    export default {
        name: "details-component",
        props: {
            Title: String,
            ItemArtUrl: String,
            Category: Object,
            Producer: Object,
            Price: Float32Array
        }
    };
</script>
