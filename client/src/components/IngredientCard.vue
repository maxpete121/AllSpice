<template>
    <div>
        <h2>{{ ingredient.name }}</h2>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { Ingredients } from '../models/Ingredients';
export default {
    props: {ingredient: {type: Ingredients, required: true}},
    setup(){
    return {  }
    }
};
</script>


<style lang="scss" scoped>

</style>