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
}

export const instructionService = new InstructionService()