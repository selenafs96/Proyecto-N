import { apiClient } from "../lib/axios";
import type { LoginResponse, LoginRequest, UserResponse } from "../types/Auth";

class AuthService {
    private apiUrl: string;

    constructor() {
        this.apiUrl = process.env.NEXT_PUBLIC_API_URL + "/api/Auth";
    }

    async login(credentials: LoginRequest): Promise<LoginResponse> {
        const response = await apiClient.post<LoginResponse>(this.apiUrl + "/login", credentials);
        return response.data;
    }

    async getCurrentUser(): Promise<UserResponse | null> {
        try{
            const response = await apiClient.get<UserResponse>(this.apiUrl + "/me");
            return response.data;
        } catch (error) {
            return null;
        }
    }
}

export default AuthService;