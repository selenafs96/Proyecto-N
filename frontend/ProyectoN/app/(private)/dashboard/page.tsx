"use client"

import AuthService from "@/src/services/authService";
import { UserResponse } from "@/src/types/Auth";
import { useEffect, useState } from "react";

export default function Dashboard() {
  const [user, setUser] = useState<UserResponse | null>(null);
  const [loading, setLoading] = useState(true);

  

  useEffect(() => {
    async function checkSession() {
        const authService = new AuthService();
      const currentUser = await authService.getCurrentUser();
      if (currentUser) {
        setUser(currentUser);
      } else {
        // Opcional: Redirigir al login si no está autenticado
        // router.push("/");
      }
      setLoading(false);
    }

    void checkSession();
  }, []);

  if (loading) return <p>Cargando sesión...</p>;
  return (
    <div>
      <div>Hola soy el dashboard</div>
      <p>{user?.email}</p>
    </div>
  );
}
