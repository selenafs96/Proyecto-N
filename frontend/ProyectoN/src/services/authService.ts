import { apiClient } from "../lib/axios";
import type { LoginResponse, LoginRequest } from "../types/UserResponse";

class AuthService {
    private apiUrl: string;

    constructor() {
        this.apiUrl = process.env.NEXT_PUBLIC_API_URL + "/api/Auth";
    }

    async login(credentials: LoginRequest): Promise<LoginResponse> {
        const response = await apiClient.post<LoginResponse>(this.apiUrl + "/login", credentials);
        return response.data;
    }
}

export default AuthService;