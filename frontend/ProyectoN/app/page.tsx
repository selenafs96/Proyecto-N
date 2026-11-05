"use client";

import { useEffect, useState } from "react";
import { AnimatePresence, motion } from "motion/react";
import { useRouter } from "next/navigation";
import { LoaderCircle } from "lucide-react";

import LoginDialog from "@/src/components/LoginDialog";
import { useAuth } from "@/src/contexts/AuthContext";

export default function Home() {
  const router = useRouter();
  const { user, loading, error } = useAuth();
  const [isLoginOpen, setIsLoginOpen] = useState(false);

  useEffect(() => {
    if (!loading && !error && user) {
      router.replace("/dashboard");
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
    return (
      <main className="w-full min-h-screen relative flex justify-end p-14 gap-4">
        <button
          className="bg-white text-main border border-light-gray rounded-xl p-2"
          onClick={() => setIsLoginOpen(true)}
        >
          Log in
        </button>
        <button className="bg-primary-dark text-white border border-light-gray rounded-xl p-2">
          Sign up
        </button>
        <AnimatePresence>
          {isLoginOpen && (
            <motion.div
              className="fixed inset-0 z-50 flex items-start justify-center bg-main/40 backdrop-blur-md p-4 sm:p-6 overflow-y-auto"
              initial={{ opacity: 0 }}
              animate={{ opacity: 1 }}
              exit={{ opacity: 0 }}
              transition={{ duration: 0.2 }}
            >
              <div className="my-auto w-full flex justify-center">
                <LoginDialog
                  open={isLoginOpen}
                  onClose={() => setIsLoginOpen(false)}
                />
              </div>
            </motion.div>
          )}
        </AnimatePresence>
      </main>
    );
  }
}
