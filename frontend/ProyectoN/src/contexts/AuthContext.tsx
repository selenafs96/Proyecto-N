"use client";

import {
  createContext,
  useCallback,
  useContext,
  useEffect,
  useMemo,
  useState,
  type ReactNode,
} from "react";
import axios from "axios";

import AuthService from "../services/authService";
import type { UserResponse } from "../types/Auth";

interface AuthContextValue {
  user: UserResponse | null; // Authenticated user, null if there's no session
  loading: boolean; // True if it is still checking the session
  error: string | null; // Error messages
  refreshUser: () => Promise<UserResponse | null>; // Checks the session and updates the user state.
}

// undefined allows to detect if a component is using the context outside the provider
const AuthContext = createContext<AuthContextValue | undefined>(undefined);

// Transforms techical axios errors in friendly messages
function getErrorMessage(error: unknown): string {
  if (axios.isAxiosError(error)) {
    if (!error.response) {
      return "No se pudo conectar con el servidor. Comprueba tu conexión.";
    }

    if (error.response.status >= 500) {
      return "Problema en el servidor. Inténtalo más tarde.";
    }
  }

  return "Ha ocurrido un error inesperado.";
}

// Provider that contains the auth state
export function AuthProvider({ children }: { children: ReactNode }) {
  // Only one instance of the service during the lifetime of the provider
  const authService = useMemo(() => new AuthService(), []);

  // Shared states
  const [user, setUser] = useState<UserResponse | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  // Checks the user and updates the user state
  const refreshUser = useCallback(async () => {
    setLoading(true);
    setError(null);

    try {
      const currentUser = await authService.getCurrentUser();
      setUser(currentUser);
      return currentUser;
    } catch (error: unknown) {
      setError(getErrorMessage(error));
      throw error;
    } finally {
      setLoading(false);
    }
  }, [authService]);

  // When the provider is mounted, it retrieves the existing session from the browser cookie
  useEffect(() => {
    // Avoids updating the state if the provider unmounts before finishing the request
    let cancelled = false;

    async function checkSession() {
      try {
        const currentUser = await authService.getCurrentUser();

        if (!cancelled) {
          setUser(currentUser);
        }
      } catch (error: unknown) {
        if (!cancelled) {
          setError(getErrorMessage(error));
          console.error("No se pudo comprobar la sesión.", error);
        }
      } finally {
        if (!cancelled) {
          setLoading(false);
        }
      }
    }

    void checkSession();

    // Cleaning function: if the user moves to another page, stops the checking
    return () => {
      cancelled = true;
    };
  }, [authService]);

  return (
    <AuthContext.Provider value={{ user, loading, error, refreshUser }}>
      {children}
    </AuthContext.Provider>
  );
}

// Hook for reading the auth state without importing the component
export function useAuth() {
  const context = useContext(AuthContext);

  if (context === undefined) {
    throw new Error("useAuth debe usarse dentro de un AuthProvider.");
  }

  return context;
}