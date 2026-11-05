"use client";

import { useEffect } from "react";
import { useRouter } from "next/navigation";
import { LoaderCircle } from "lucide-react";


import { useAuth } from "@/src/contexts/AuthContext";

export default function PrivateLayout({ children }: LayoutProps<"/">) {
  const router = useRouter();
  const { user, loading, error } = useAuth();

  useEffect(() => {
    if (!loading && !error && !user) {
      router.replace("/");
    }
  }, [loading, error, user, router]);

  if (loading) {
      return (
        <main className="min-h-screen flex items-center justify-center gap-2">
          <LoaderCircle
            className="h-8 w-8 animate-spin text-primary-dark"
            aria-hidden="true"
          />
          <p>Comprobando sesión...</p>
        </main>
      );
    }

    if (error) {
      return (
        <main className="min-h-screen flex items-center justify-center gap-2">
          <p role="alert">{error}</p>
        </main>
      );
    }

    if (!user) {
      return null;
    }

  return <>{children}</>;
}
