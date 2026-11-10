"use client";

import { useEffect } from "react";
import { useRouter } from "next/navigation";
import { LoaderCircle } from "lucide-react";

import { useAuth } from "@/src/contexts/AuthContext";
import Image from "next/image";
import Link from "next/link";
import Sidebar from "@/src/components/Sidebar";

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
        <p className="text-lg">Comprobando sesión...</p>
      </main>
    );
  }

  if (error) {
    return (
      <main className="min-h-screen flex items-center justify-center gap-2">
        <p className="text-lg" role="alert">{error}</p>
      </main>
    );
  }

  if (!user) {
    return null;
  }

  return (
    <main className="flex h-screen w-full">
      <Sidebar />
      <div className="flex flex-1 flex-col">
        <header className="h-20 bg-amber-200 w-full text-lg">Soy el header</header>
        <div className="flex flex-1">{children}</div>
      </div>
    </main>
  );
}
