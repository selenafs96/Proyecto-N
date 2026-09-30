import { apiClient } from "../lib/axios";
import { UserResponse } from "../types/UserResponse";

class UserService {
    private apiUrl: string;

    constructor() {
        this.apiUrl = process.env.NEXT_PUBLIC_API_URL + "/api/User";
    }

    async getUserById(userId: number): Promise<UserResponse | null> {
        try {
            const response = await apiClient.get<UserResponse>(this.apiUrl + `/${userId}`);
            return response.data;
        } catch (error) {
            console.log(`Error recuperando datos del usuario: ${error}`);
            return null;
        }
    }
}

export default UserService;