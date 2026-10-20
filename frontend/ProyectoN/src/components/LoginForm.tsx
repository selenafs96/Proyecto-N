"use client";

import { useState } from "react";
import Image from "next/image";
import Link from "next/link";
import Router from "next/router";
import { Eye } from "lucide-react";

function LoginForm({onClose} : { readonly onClose: () => void}) {


  // States fot text inputs
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  // States for user experience
  const [isLoading, setIsLoading] = useState(false);
  const [errorMessage, setErrorMessage] = useState("");

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
      <div className=" relative w-full max-w-130 h-[610px] bg-white border border-mid-gray rounded-br-md rounded-tr-md pt-6 px-6">
      <button
          type="button"
          aria-label="Cerrar"
          className="absolute -top-4 -right-4 z-20 rounded-full bg-white p-2 shadow-md h-10 w-10"
          onClick={ onClose }
      >X</button>
            <p className="w-full text-muted text-xs text-right">¿Nuevo en la plataforma? <span className="text-xs font-semibold text-primary-dark">Solicitar demo</span></p>
            <div className="flex flex-col gap-4 justify-center h-full p-14">
              <div>
                <h2 className="font-bold text-3xl text-main">Bienvenido de nuevo</h2>
                <p className="text-muted text-xs">Introduce tus credenciales para acceder a tu consulta clínica</p>
              </div>
                { /* Continue with Google */ }
                <Link href="/" className="mt-4 border border-mid-gray flex justify-center items-center gap-3 px-4 py-2 rounded-lg drop-shadow-xs bg-white">
                    <Image src="/google.svg" alt="Google logo" width={18} height={18}/>
                    <p className="text-xs">Continuar con Google</p>
                </Link>
                {/* Formulario */}
                <form className="flex flex-col gap-4">
                    { /* O continuar con email */ }
                    <div className="mt-6 flex items-center gap-3">
                        <span aria-hidden="true" className="flex-1 border-t border-mid-gray" />
                        <span className="text-xs text-muted">o continuar con email</span>
                        <span aria-hidden="true" className="flex-1 border-t border-mid-gray" />
                    </div>
                    { /* Email input */ }
                    <div className="flex flex-col gap-3 justify-center">
                        {/* Email */}
                        <label htmlFor="email" className="text-xs font-semibold text-main">
                            Email profesional
                        </label>
                        <input id="email" type="email" required value={email} onChange={(e) => setEmail(e.target.value)} placeholder="nutricionista@clinica.com" className="text-sm border border-mid-gray w-full px-4 py-1.5 rounded-lg drop-shadow-xs bg-white" />
                        {/* Password */}
                        <div className="flex justify-between">
                            <label htmlFor="password" className="text-xs font-semibold text-main">
                                Contraseña
                            </label>
                            <p className="text-primary-dark font-semibold text-xs">¿Olvidaste tu contraseña?</p>
                        </div>
                        <div className="flex justify-between text-sm border border-mid-gray w-full rounded-lg drop-shadow-xs bg-white pr-3 items-center">
                            <input id="password" type="password" required value={password} onChange={(e) => setPassword(e.target.value)} placeholder="********" className="text-sm w-full px-4 py-1.5" />
                            <Eye className="text-primary-dark/50"/>
                        </div>
                        { /* Remember me */ }
                        <div className="flex gap-2">
                          <input type="checkbox" className="accent-primary-mid" />
                          <p className="text-xs text-muted">Recordar inicio de sesión en este equipo</p>
                        </div>
                        <button type="submit" className="bg-primary-dark text-white rounded-lg w-full drop-shadow-xs px-4 py-2 text-sm mt-6">Iniciar sesión</button>
                        <p className="text-muted text-xs">¿No tienes una cuenta? <span className="font-semibold text-primary-dark">Solicita acceso</span></p>
                    </div>
                    <p className="text-xs text-muted mt-6">Al continuar aceptas los <span className="text-primary-dark font-medium underline">términos y condiciones de privacidad</span>. Consulta nuestra <span className="text-primary-dark underline font-medium">política de privacidad</span>.</p>
                </form>
            </div>
        </div>
    )
}

export default LoginForm;