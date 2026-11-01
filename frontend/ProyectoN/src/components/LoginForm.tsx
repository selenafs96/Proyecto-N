"use client";

import { useState } from "react";
import Image from "next/image";
import Link from "next/link";
import { useRouter } from "next/navigation";
import { Eye, EyeOff, X } from "lucide-react";

function LoginForm({onClose} : { readonly onClose: () => void}) {

  const router = useRouter();

  // States for password visibility
  const [passwordVisible, setPasswordVisible] = useState(false);

  function handlePasswordVisibility() {
    setPasswordVisible(prev => !prev);
  }

  // States fot text inputs
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  // States for user experience
  const [isLoading, setIsLoading] = useState(false);
  const [errorMessage, setErrorMessage] = useState("");

  const handleSubmit = async (e: React.SubmitEvent<HTMLFormElement>) => {
    e.preventDefault();
    setErrorMessage("");
    setIsLoading(true);

    try {
      // const response = await fetch('/api/login', { ... });
      
      await new Promise((resolve) => setTimeout(resolve, 1500)); // Simulación de espera (1.5s)

      // Ejemplo de validación simple
      if (email === "admin@clinica.com" && password === "123456") {
        router.push("/dashboard");
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
      <div className=" relative w-full max-w-130 lg:h-[610px] bg-white border border-mid-gray rounded-md lg:rounded-l-none rounded-tr-md pt-6 px-6">
      <button
          type="button"
          aria-label="Cerrar"
          className="absolute -top-4 -right-4 z-20 rounded-full bg-white p-2 shadow-md h-8 w-8"
          onClick={ onClose }
      ><X className="w-4 h-4"/></button>
            <p className="w-full text-muted text-[0.55rem] text-right">¿Nuevo en la plataforma? <span className="text-[0.55rem] font-semibold text-primary-dark">Solicitar demo</span></p>
            <div className="flex flex-col gap-4 justify-center lg:h-full p-6 sm:p-8 lg:p-14">
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
                <form className="flex flex-col gap-4" onSubmit={handleSubmit}>
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
                        <input id="email" name="email" autoComplete="username" type="email" required value={email} onChange={(e) => setEmail(e.target.value)} placeholder="nutricionista@clinica.com" className="text-sm border border-mid-gray w-full px-4 py-1.5 rounded-lg drop-shadow-xs bg-white focus: outline-none" />
                        {/* Password */}
                        <div className="flex justify-between">
                            <label htmlFor="password" className="text-xs font-semibold text-main">
                                Contraseña
                            </label>
                            <p className="text-primary-dark font-semibold text-xs">¿Olvidaste tu contraseña?</p>
                        </div>
                        <div className="flex justify-between text-sm border border-mid-gray w-full rounded-lg drop-shadow-xs bg-white pr-3 items-center">
                            <input id="password" name="password" autoComplete="current-password" type={passwordVisible ? "text" : "password"} required value={password} onChange={(e) => setPassword(e.target.value)} placeholder="********" className="text-sm w-full px-4 py-1.5 focus: outline-none" />
                            <button type="button" onClick={handlePasswordVisibility} aria-label={ passwordVisible ? "Ocultar contraseña" : "Mostrar contraseña" }>
                              { passwordVisible ? <EyeOff className="text-primary-dark/50"/> : <Eye className="text-primary-dark/50"/>}
                            </button>
                        </div>
                        {errorMessage && (
                        <p role="alert" className="text-xs text-red-600">
                          {errorMessage}
                        </p>
                        )}
                        { /* Remember me */ }
                        <div className="flex gap-2">
                          <input id="remember" type="checkbox" className="accent-primary-mid" />
                          <label htmlFor="remember" className="text-xs text-muted">Recordar inicio de sesión en este equipo</label>
                        </div>
                        <button type="submit" disabled={isLoading} aria-busy={isLoading} className="bg-primary-dark text-white rounded-lg w-full drop-shadow-xs px-4 py-2 text-sm mt-6">{isLoading ? "Iniciando sesión..." : "Iniciar sesión"}</button>
                        <p className="text-muted text-xs">¿No tienes una cuenta? <span className="font-semibold text-primary-dark">Solicita acceso</span></p>
                    </div>
                    <p className="text-[0.55rem] text-muted mt-6">Al continuar aceptas los <span className="text-primary-dark font-medium underline">términos y condiciones de privacidad</span>. Consulta nuestra <span className="text-primary-dark underline font-medium">política de privacidad</span>.</p>
                </form>
            </div>
        </div>
    )
}

export default LoginForm;