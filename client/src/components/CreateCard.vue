<template>
      <div type="button" data-bs-toggle="modal" data-bs-target="#modalCreate" class="rounded-circle bg-success create-card p-2 sticky-bottom text-center mb-2">
          <i class="mdi mdi-plus add-button"></i>
      </div>
        <div class="modal fade" id="modalCreate" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h1 class="modal-title fs-5" id="exampleModalLabel"></h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body d-flex">
            <h6 class="ms-3"></h6>
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
export default {
    setup(){
    return {  }
    }
};
</script>


<style lang="scss" scoped>
.create-card{
    min-height: 70px;
    min-width: 70px;
    max-width: 120px;
    box-shadow: 2px 6px 6px rgba(0, 0, 0, 0.523);
}

.create-card:hover{
    min-height: 70px;
    min-width: 70px;
    max-width: 120px;
    box-shadow: 2px 6px 6px rgba(0, 0, 0, 0.523);
    transform: scale(1.03);
    cursor: pointer;
}
.add-button{
    font-size: 70px;
}
</style>