import { api } from "./AxiosService"


class InstructionService{

    async getInstructions(recipeId){
        let response = await api.get(`api/instructions/${recipeId}/`)
    }
}

export const instructionService = new InstructionService()