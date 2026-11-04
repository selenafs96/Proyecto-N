"use client";

import { useEffect, useState } from "react";
import { useRouter } from "next/navigation";
import { LoaderCircle } from "lucide-react";

import AuthService from "@/src/services/authService";

export default function PrivateLayout({ children }: LayoutProps<"/">) {
const router = useRouter();
  const [checkingSession, setCheckingSession] = useState(true)

  useEffect(() => {
    let cancelled = false;

    async function checkSession() {
      const authService = new AuthService();
      const user = await authService.getCurrentUser();

      if(cancelled) return;

      if(user) {
        setCheckingSession(false);
      } else {
        router.replace("/");
      }
    }

    void checkSession();

    // Cleaning function: if the user moves to another page, stops the checking
    return () => {
      cancelled = true;
    }
  }, [router])

  if(checkingSession) {
    return  (
      <main className="min-h-screen flex items-center justify-center gap-2">
        <LoaderCircle
        className="h-8 w-8 animate-spin text-primary-dark"
        aria-hidden="true"
      />
        <p>Comprobando sesión...</p>
      </main>
    )
  }

  return (
    <>
    {children}
    </>
  );
}