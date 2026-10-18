"use client";

import LoginFeatureSlider from "@/src/components/LogInSlider";
import Image from "next/image";

function LoginPage() {
  return (
    <main className="flex w-full min-h-screen justify-center items-center">
      { /* Left container */ }
      <div className="w-full max-w-[520px] h-[610.98px] bg-primary-light border border-mid-gray p-14 rounded-bl-md rounded-tl-md">
        {/* Logo, title, description and version header */}
        <div className="max-w-lg flex justify-between items-center">
          <div className="flex items-center gap-3">
            <Image
              src="/logo.svg"
              alt="Proyecto N logo"
              width={36}
              height={36}
            />
            <div className="flex flex-col items-center">
              <h1 className="text-main font-bold text-base">Proyecto N</h1>
              <p className="text-muted text-xs">Nutrición clínica</p>
            </div>
          </div>
          <div className="bg-white border border-primary-mid flex justify-between rounded-full px-4 py-0.5 h-6 items-center gap-2">
            <Image src="/dot.svg" alt="Green dot" width={8} height={8} />
            <p className="text-primary-dark font-semibold text-xs tracking-wide">v1.0.0</p>
          </div>
        </div>
       <LoginFeatureSlider />
      </div>
      { /* Right container */ }
      <div className="w-full max-w-[520px] h-[610.98px] bg-white border border-mid-gray rounded-br-md rounded-tr-md">
        
      </div>
    </main>
  );
}

export default LoginPage;
