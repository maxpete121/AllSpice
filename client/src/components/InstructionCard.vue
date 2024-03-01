<template>
    <div class="instruction-card d-flex mt-2 align-items-center pt-2 ms-1 me-1 justify-content-center">
        <div class="d-flex justify-content-end">
            <div class="step rounded-circle d-flex justify-content-center me-4">
                <h4 class="mt-1">{{ instruction.step }}</h4>
            </div>
        </div>
        <div class="mt-1 w-75 d-flex align-items-center justify-content-center">
            <div class="instruction-main pt-1 ps-2 pe-2 pb-1">
                <p>{{ instruction.body }}</p>
            </div>
            <div class="ms-4">
                <button class="btn btn-danger rounded-circle"><i class="mdi mdi-delete"></i></button>
            </div>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { Instruction } from '../models/Instruction';
export default {
    props: { instruction: { type: Instruction, required: true } },
    setup(){
    return {  }
    }
};
</script>


<style lang="scss" scoped>
.instruction-main{
    background-color: white;
    box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.488);
    outline: solid 1px #0cbc87;
    border-radius: 15px;
}

.step{
    height: 40px;
    width: 40px;
    background-color: rgb(222, 222, 222);
    box-shadow: 3px 4px 4px rgba(0, 0, 0, 0.437);
}
</style>