export interface UserResponse {
    userId: number,
    dni: string,
    name: string,
    lastName: string,
    email: string,
    phoneNumber: string,
    photoUrl: string
}

export interface LoginRequest {
    email: string,
    password: string
}

export interface AuthError {
    propertyName: string,
    errorMessage:string
}

export interface LoginResponse {
    message: string
}