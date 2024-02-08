<template>
    <div type="button" data-bs-toggle="modal" :data-bs-target="target" :style="bgPic" class="recipe-card-home d-flex flex-column justify-content-end" :title="recipe.title">
        <div class="text-dark recipe-card-child p-2">
            <h5>{{ recipe.title }}</h5>
            <h6>{{ recipe.category }}</h6>
        </div>
    </div>
    <!-- Button trigger modal -->
<!-- Modal -->
<div class="modal fade" :id="catchModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h1 class="modal-title fs-5" id="exampleModalLabel">{{recipe.title}}</h1>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body d-flex">
        <img class="img-fluid img-resize" :src="recipe.img" alt="image of food.">
        <h6 class="ms-3">{{ recipe.instructions }}</h6>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary">Favorite⭐</button>
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { Recipes } from '../models/Recipes';
export default {
    props: {recipe: {type: Recipes, required: true}},
    setup(props){
    return { 
        bgPic: computed(()=>{
            let string = `background-image: url(${props.recipe.img}); background-size: cover; background-position: center;`
            return string
        }),
        target: computed(()=>{
            let addId = props.recipe.id
            let startId = '#modal'
            let newId = startId + addId
            return newId
        }),
        catchModal: computed(()=>{
            let catchId = 'modal'
            let startId = props.recipe.id
            let newId = catchId + startId
            return newId
        })
     }
    }
};
</script>


<style lang="scss" scoped>
.recipe-card-home{
    outline: solid 2px black;
    height: 280px;
    background-position: center;
    background-size: cover;
    border-radius: 5px;
    box-shadow: 1px 6px 6px rgba(0, 0, 0, 0.7);
}

.recipe-card-home:hover{
    outline: solid 2px black;
    height: 280px;
    background-position: center;
    background-size: cover;
    transform: scale(1.02);
    cursor: pointer;
    border-radius: 5px;
}

.recipe-card-child{
    background-color: rgba(255, 255, 255, 0.8);
}

.img-resize{
    height: 200px;
}
</style>