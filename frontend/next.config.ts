import type { NextConfig } from "next";
import path from "path";

const nextConfig: NextConfig = {
  // Ajustamos la raíz para Turbopack, indicándole que está un nivel más arriba (porque la ra´zi del repositorio está en proyecto-n)
  turbopack: {
    root: path.join(__dirname, "../"),
  },
};

export default nextConfig;
