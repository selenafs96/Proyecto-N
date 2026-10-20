"use client";

import { useState } from "react";
import { AnimatePresence, motion } from "motion/react";

import LoginPage from "./(public)/(auth)/login/page";

export default function Home() {

  const [isLoginOpen, setIsLoginOpen] = useState(false);

  return (
    <main className="w-full min-h-screen relative flex justify-end p-14 gap-4">
        <button 
          className="bg-white text-main border border-light-gray rounded-xl p-2"
          onClick={ () => setIsLoginOpen(true)}>Log in</button>
        <button className="bg-primary-dark text-white border border-light-gray rounded-xl p-2">Sign up</button>
        <AnimatePresence>
          {isLoginOpen && (
          <motion.div 
            className="fixed inset-0 z-50 flex items-center justify-center bg-main/40 backdrop-blur-md p-4 sm:p-6 overflow-y-auto"
            initial={{ opacity: 0 }}
            animate={{ opacity: 1 }}
            exit={{ opacity: 0 }}
            transition={{ duration: 0.2 }}>
            <LoginPage onClose={() => setIsLoginOpen(false)}/>
          </motion.div>)}
        </AnimatePresence>
    </main>
  );
}