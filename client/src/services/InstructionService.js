import { applyStyles } from "@popperjs/core"
import { AppState } from "../AppState"
import { Instruction } from "../models/Instruction"
import { api } from "./AxiosService"


class InstructionService{

    async getInstructions(recipeId){
        let response = await api.get(`api/instructions/${recipeId}/recipe`)
        let recipeInstructionData = await response.data.map(instruction => new Instruction(instruction))
        AppState.recipeInstructions = recipeInstructionData
    }

    async createInstruction(instructionData){
        let response = await api.post(`api/instructions`, instructionData)
        let newInstruction = new Instruction(response.data)
        AppState.recipeInstructions.push(newInstruction)
    }

    async createInstruction(instructionData){
        let response = await api.post('api/instructions', instructionData)
        let newInstruction = new Instruction(response.data)
        AppState.recipeInstructions.push(newInstruction)
        return newInstruction
    }

    async deleteInstruction(instructionId){
        let response = await api.delete(`api/instructions/${instructionId}`)
        let instructionIndex = AppState.recipeInstructions.findIndex(instruction => instruction.id == instructionId)
        AppState.recipeInstructions.splice(instructionIndex, 1)
        this.renumber()
        return response.data
    }

    async renumber(){
        let count = 0
        for (let i = 0; i < AppState.recipeInstructions.length; i++) {
            AppState.recipeInstructions[i].step = count +=1
        }
    }
}

export const instructionService = new InstructionService()