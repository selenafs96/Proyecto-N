"use client";

import { useState } from "react";
import Image from "next/image";
import Link from "next/link";
import Router from "next/router";
import { Eye } from "lucide-react";

function LoginForm() {


// 1. Estados para los campos de texto
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  // 2. Estados para la experiencia de usuario (Feedback UI)
  const [isLoading, setIsLoading] = useState(false);
  const [errorMessage, setErrorMessage] = useState("");

  // 3. Manejador del envío del formulario
  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault(); // Evita que la página se recargue
    setErrorMessage(""); // Limpiamos errores previos
    setIsLoading(true);

    try {
      // Simulación de llamada a tu backend / API de autenticación
      // const response = await fetch('/api/login', { ... });
      
      await new Promise((resolve) => setTimeout(resolve, 1500)); // Simulación de espera (1.5s)

      // Ejemplo de validación simple
      if (email === "admin@clinica.com" && password === "123456") {
        // Redirigir al dashboard si las credenciales son correctas
        Router.push("/dashboard");
      } else {
        throw new Error("El correo electrónico o la contraseña son incorrectos.");
      }
    } catch (err: unknown) {
      if (err instanceof Error) {
        setErrorMessage(err.message);
      } else {
        setErrorMessage("Ha ocurrido un error inesperado. Inténtalo de nuevo.");
      }
    } finally {
      setIsLoading(false); // Desactivamos el estado de carga
    }
  };

    return (
        <div className="w-full max-w-130 h-[610px] bg-white border border-mid-gray rounded-br-md rounded-tr-md p-6">
            <p className="w-full text-muted text-xs text-right">¿Nuevo en la plataforma? <span className="text-xs font-semibold text-primary-dark">Solicitar demo</span></p>
            <div>
                <h2 className="font-bold text-3xl text-main">Bienvenido de nuevo</h2>
                { /* Continaur con Google */ }
                <p className="text-muted text-xs">Introduce tus credenciales para acceder a tu consulta clínica</p>
                <Link href="/" className="border border-mid-gray flex justify-center items-center gap-3 px-4 py-1.5 rounded-lg drop-shadow-xs bg-white">
                    <Image src="/google.svg" alt="Google logo" width={18} height={18}/>
                    <p className="text-xs">Continuar con Google</p>
                </Link>
                { /* O continuar con email */ }
                <div className="my-6 flex items-center gap-3">
                    <span aria-hidden="true" className="flex-1 border-t border-mid-gray" />
                    <span className="text-xs text-muted">o continuar con email</span>
                    <span aria-hidden="true" className="flex-1 border-t border-mid-gray" />
                </div>
                {/* Formulario */}
                <form className="flex flex-col gap-4">
                    { /* Email input */ }
                    <div className="flex flex-col gap-1.5">
                        {/* Email */}
                        <label htmlFor="email" className="text-xs font-semibold text-main">
                            Email profesional
                        </label>
                        <input id="email" type="email" required value={email} onChange={(e) => setEmail(e.target.value)} placeholder="nutricionista@clinica.com" className="text-sm border border-mid-gray w-full px-4 py-1.5 rounded-lg drop-shadow-xs bg-white" />
                        {/* Contraseña */}
                        <div className="flex justify-between">
                            <label htmlFor="password" className="text-xs font-semibold text-main">
                                Contraseña
                            </label>
                            <p className="text-primary-dark font-semibold text-xs">¿Olvidaste tu contraseña?</p>
                        </div>
                        <div className="flex justify-between text-sm border border-mid-gray w-full rounded-lg drop-shadow-xs bg-white pr-3 items-center">
                            <input id="password" type="password" required value={email} onChange={(e) => setEmail(e.target.value)} placeholder="********" className="text-sm w-full px-4 py-1.5" />
                            <Eye className="text-primary-dark/50"/>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    )
}

export default LoginForm;