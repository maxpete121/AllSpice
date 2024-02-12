<template>
    <div class="search-box">
        <form action="" class="d-flex align-items-center">
            <input class="search-bar" type="text" maxlength="40">
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
    border-bottom-left-radius: 15px;
    border-top-left-radius: 15px;
    height: 28px;
    padding: 5px;
    padding-left: 8px;
    background-color: rgb(235, 235, 235);
    outline: solid 1px #0cbc87;
}

.search-bar:focus{
    all: unset;
    border-bottom-left-radius: 12px;
    border-top-left-radius: 12px;
    height: 22px;
    padding: 5px;
    padding-left: 8px;
    background-color: rgb(235, 235, 235);
    outline: dashed 2px #009f6f;
}
.search-button{
    all: unset;
    padding: 5px;
    border-bottom-right-radius: 13px;
    border-top-right-radius: 13px;
    background-color: rgb(235, 235, 235);
    outline: solid 1px #0cbc87;
}

.search-button:hover{
    all: unset;
    padding: 5px;
    border-bottom-right-radius: 13px;
    border-top-right-radius: 13px;
    outline: solid 1px #0cbc87;
    background-color: rgb(230, 230, 230);
    cursor: pointer;
}


</style>