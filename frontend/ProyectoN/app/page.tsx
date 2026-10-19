"use client";

import { useState } from "react";
import LoginPage from "./(public)/(auth)/login/page";

export default function Home() {

  const [isOpen, setIsOpen] = useState(false);

  return (
    <main className="w-full min-h-screen relative flex justify-end p-14 gap-4">
        <button 
          className="bg-white text-main border border-light-gray rounded-xl p-2"
          onClick={ () => setIsOpen(true)}>Log in</button>
        <button className="bg-primary-dark text-white border border-light-gray rounded-xl p-2">Sign up</button>
        {isOpen && (
        <div className="fixed inset-0 z-50 flex items-center justify-center bg-main/40 backdrop-blur-md p-4 sm:p-6 overflow-y-auto">
          <LoginPage />
        </div>)}
    </main>
  );
}