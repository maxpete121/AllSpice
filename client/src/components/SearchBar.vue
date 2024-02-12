<template>
    <div>
        <form action="" class="d-flex align-items-center">
            <input class="search-bar" type="text">
            <button class="search-button">Search</button>
        </form>

    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
export default {
    setup(){
    return {  }
    }
};
</script>


<style lang="scss" scoped>

.search-bar{
    all: unset;
    border-bottom-left-radius: 12px;
    border-top-left-radius: 12px;
    height: 27px;
    padding: 5px;
    padding-left: 8px;
    border-color: #0cbc87;
}
.search-button{
    all: unset;
    padding: 5px;
    border-bottom-right-radius: 10px;
    border-top-right-radius: 10px;
    outline: solid 1px #0cbc87;
}

.search-button:hover{
    all: unset;
    padding: 5px;
    border-bottom-right-radius: 10px;
    border-top-right-radius: 10px;
    outline: solid 1px #0cbc87;
    background-color: rgb(232, 232, 232);
    cursor: pointer;
}

</style>