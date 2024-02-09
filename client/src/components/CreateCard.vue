<template>
  <div title="Create new recipe!" class="sticky-bottom d-flex justify-content-end me-4">
    <div type="button" data-bs-toggle="modal" data-bs-target="#modalCreate" class="rounded-circle create-card bg-success p-2 sticky-bottom text-center mb-2 me-4">
        <i class="mdi mdi-plus add-button"></i>
    </div>
  </div>
        <div class="modal fade" id="modalCreate" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h1 class="modal-title fs-5" id="exampleModalLabel">Create a new recipe...</h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body d-flex justify-content-center">
            <form action="" class="d-flex flex-column align-items-center">
              <div class="w-75 text-center">
                <label for="">Recipe Title...</label>
                <input v-model="newRecipeData.Title" class="form-control" maxlength="40" type="text" required>
              </div>
              <div class="d-flex mt-2">
                <div class="me-2 text-center">
                  <label for="">Category...</label>
                  <select v-model="newRecipeData.Category" name="category" id="category-select" class="form-control">
                    <option selected disabled>Select one..</option>
                    <option  value="Cheese">Cheese</option>
                    <option value="Italian">Italian</option>
                    <option value="Soup">Soup</option>
                    <option value="Mexican">Mexican</option>
                    <option value="Specialty Coffee">Specialty Coffee</option>
                  </select>
                </div>
                <div class="text-center">
                <label for="">Image url of food...</label>
                <input v-model="newRecipeData.Img" class="form-control" type="url" required maxlength="500">
              </div>
              </div>
              <div class="mt-2 d-flex flex-column text-center">
                <label for="">Instructions...</label>
                <textarea v-model="newRecipeData.Instructions" name="" id="" cols="55" rows="4"></textarea>
              </div>
              <button type="button" class="btn btn-secondary mt-2">Create!</button>
            </form>
          </div>
          <div class="modal-footer">
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
      let newRecipeData = ref({})
    return { 
      newRecipeData,
     }
    }
};
</script>


<style lang="scss" scoped>
.create-card{
    min-height: 70px;
    min-width: 120px;
    // max-width: 120px;
    box-shadow: 2px 6px 6px rgba(0, 0, 0, 0.523);
}

.create-card:hover{
    min-height: 70px;
    min-width: 120px;
    box-shadow: 2px 6px 6px rgba(0, 0, 0, 0.523);
    transform: scale(1.03);
    cursor: pointer;
}
.add-button{
    font-size: 70px;
}
</style>