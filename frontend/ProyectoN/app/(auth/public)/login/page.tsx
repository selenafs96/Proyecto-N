"use client";

import LoginFeatureSlider from "@/src/components/LogInSlider";
import FeatureSlider from "@/src/components/LogInSlider";
import Image from "next/image";

function LoginPage() {
  return (
    <main className="flex">
      <div className="w-full bg-primary-light border border-mid-gray p-14">
        {/* Logo, title, description and version header */}
        <div className="flex justify-between items-center">
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
            <p className="text-primary-dark font-semibold text-xs">v1.0.0</p>
          </div>
        </div>
       <LoginFeatureSlider />
      </div>
      <div className="w-full bg-white border border-mid-gray">
        
      </div>
    </main>
  );
}

export default LoginPage;
