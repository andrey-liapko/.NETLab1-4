<template>
    <div id="details">
        <h2>Your {{Title}}</h2>
    </div>

</template>
<script>
    export default {
        name: "details-component",
        props: {
            Title: String
        }
    };
</script>
