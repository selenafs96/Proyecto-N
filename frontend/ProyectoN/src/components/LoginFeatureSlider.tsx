import React, { useState, useEffect } from "react";
import Image from "next/image";
import {
  ChevronLeft,
  ChevronRight,
  Activity,
  ShieldCheck,
  CalendarClock,
  Database,
} from "lucide-react";


interface Slide {
  id: number;
  badge: string;
  badgeStatus?: string;
  metrics: {
    label: string;
    value: string;
    sub?: string;
    swapOrder: boolean;
    metricIcon?: React.ReactNode;
  }[];
  footerLabel?: string;
  footerValue?: string;
  title: string;
  description: string;
  icon: React.ReactNode;
}

const slides: Slide[] = [
  {
    id: 1,
    icon: <Activity className="w-4 h-4 text-primary-dark" />,
    badge: "Balance energético y macros",
    badgeStatus: "Tiempo real",
    metrics: [
      { label: "Proteínas", value: "138g", sub: "28%", swapOrder: false },
      { label: "Carbohidratos", value: "210g", sub: "44%", swapOrder: false },
      { label: "Lípidos", value: "62g", sub: "28%", swapOrder: false },
    ],
    footerLabel: "Gasto energético basal (Harris–Benedict)",
    footerValue: "2,140 kcal/día",
    title: "Planificación nutricional de precisión",
    description:
      "Cálculos automáticos de macronutrientes y gasto metabólico personalizado.",
  },
  {
    id: 2,
    icon: <ShieldCheck className="w-4 h-4 text-primary-dark" />,
    badge: "Fuentes de datos homologadas",
    metrics: [
      {
        label: "Composición de alimentos básicos",
        value: "BEDCA España",
        swapOrder: true,
        metricIcon: <Database className="text-primary-dark h-4 w-4" />,
      },
      {
        label: "Composición de alimentos envasados",
        value: "Open Food Facts",
        swapOrder: true,
        metricIcon: <Database className="text-primary-dark h-4 w-4" />,
      },
    ],
    title: "Seguridad y datos homologados",
    description:
      "Datos de composición de alimentos provenientes de bases de datos oficiales BEDCA y Open Food Facts.",
  },
  {
    id: 3,
    icon: <CalendarClock className="w-4 h-4 text-primary-dark" />,
    badge: "Seguimiento clínico y consultas",
    metrics: [
      { label: "Adherencia", value: "94%", sub: "Excelente", swapOrder: false },
      {
        label: "Próxima revisión",
        value: "7 Nov",
        sub: "10:30h",
        swapOrder: false,
      },
      { label: "Evolución peso", value: "-2.4 kg", swapOrder: false },
    ],
    footerLabel: "Historial de consultas y bioimpedancia",
    footerValue: "Expediente #84920",
    title: "Gestión integral del paciente",
    description:
      "Centraliza historia clínica, evolución antropométrica e historial de citas en un entorno clínico despejado y seguro.",
  },
];

export default function LoginFeatureSlider() {
  const [currentIndex, setCurrentIndex] = useState(0);

  // Auto-advance every 7 seconds
  useEffect(() => {
    const timer = setInterval(() => {
      setCurrentIndex((prev) => (prev + 1) % slides.length);
    }, 7000);
    return () => clearInterval(timer);
  }, []);

  const handlePrev = () => {
    setCurrentIndex((prev) => (prev === 0 ? slides.length - 1 : prev - 1));
  };

  const handleNext = () => {
    setCurrentIndex((prev) => (prev + 1) % slides.length);
  };

  const currentSlide = slides[currentIndex];

  return (
    <div className="w-full max-w-130 h-[610px] bg-primary-light border border-mid-gray p-14 rounded-bl-md rounded-tl-md">
      {/* Logo, title, description and version header */}
      <div className="max-w-lg flex justify-between items-center">
        <div className="flex items-center gap-3">
          <Image src="/logo.svg" alt="Proyecto N logo" width={36} height={36} />
          <div className="flex flex-col items-center">
            <h1 className="text-main font-bold text-base">Proyecto N</h1>
            <p className="text-muted text-xs">Nutrición clínica</p>
          </div>
        </div>
        <div className="bg-white border border-primary-mid flex justify-between rounded-full px-4 py-0.5 h-6 items-center gap-2">
          <Image src="/dot.svg" alt="Green dot" width={8} height={8} />
          <p className="text-primary-dark font-semibold text-xs tracking-wide">
            v1.0.0
          </p>
        </div>
      </div>
      <div className="w-full max-w-lg flex flex-col justify-between py-6">
        {/* Dynamic slide content */}
        <div className="relative flex flex-col justify-between">
          {/* Floating metric preview card */}
          <div
            key={currentSlide.id}
            className="bg-white rounded-2xl p-6 border border-light-gray shadow-[0_8px_30px_rgb(0,0,0,0.04)] transition-all duration-500 ease-out transform h-65"
          >
            {/* Card header badge */}
            <div className="flex items-center justify-between pb-4 border-b border-light-gray">
              <div className="flex items-center gap-2 text-main font-semibold text-sm">
                <span className="p-1 rounded bg-mid-gray flex items-center justify-center">
                  {currentSlide.icon}
                </span>
                <span>{currentSlide.badge}</span>
              </div>
              {currentSlide.badgeStatus && (
                <span className="px-2.5 py-0.5 rounded-full text-xs font-medium bg-[#e5f8ee] text-primary-dark">
                  {currentSlide.badgeStatus}
                </span>
              )}
            </div>

            {/* Metrics grid */}
            <div className="flex justify-between my-4 gap-3">
              {currentSlide.metrics.map((m, _) => (
                <div
                  key={m.label}
                  className="bg-light-gray rounded-xl p-3 border border-mid-gray text-center w-full h-28 min-w-0 overflow-hidden flex items-center justify-center"
                >
                  <div className="flex w-full min-w-0 items-center justify-center">
                    {m.swapOrder ? (
                      <div className="flex w-full min-w-0 flex-col items-center">
                        <div
                          title={m.value}
                          className="flex items-center justify-center gap-2"
                        >
                          <div>{m.metricIcon}</div>
                          <p className="w-full text-sm overflow-hidden text-ellipsis font-bold leading-tight text-main tracking-tight line-clamp-2 wrap-break-word">
                            {m.value}
                          </p>
                        </div>
                        <div
                          title={m.label}
                          className=" mt-4 h-8 w-full overflow-hidden text-ellipsis text-xs text-muted font-medium line-clamp-2"
                        >
                          {m.label}
                        </div>
                        <span
                          title={m.sub}
                          className="h-4 w-full truncate text-xs font-normal text-muted"
                        >
                          {m.sub}
                        </span>
                      </div>
                    ) : (
                      <div className="flex w-full min-w-0 flex-col items-center">
                        <div
                          title={m.label}
                          className="h-8 w-full overflow-hidden text-ellipsis text-xs text-muted font-medium line-clamp-2"
                        >
                          {m.label}
                        </div>
                        <div
                          title={m.value}
                          className="h-8 w-full overflow-hidden text-ellipsis text-base font-bold leading-tight text-dark-gray tracking-tight line-clamp-2 wrap-break-word"
                        >
                          {m.value}
                        </div>
                        <span
                          title={m.sub}
                          className="h-4 w-full truncate text-xs font-normal text-muted"
                        >
                          {m.sub}
                        </span>
                      </div>
                    )}
                  </div>
                </div>
              ))}
            </div>

            {/* Card footer */}
            <div className="flex items-center justify-between pt-3 border-t border-light-gray text-xs">
              <span className="text-muted">{currentSlide.footerLabel}</span>
              <span className="font-semibold text-main">
                {currentSlide.footerValue}
              </span>
            </div>
          </div>

          {/* Title + description) */}
          <div
            key={`text-${currentSlide.id}`}
            className="mt-8 transition-opacity duration-500 ease-out"
          >
            <h2 className="text-2xl font-bold text-main tracking-tight">
              {currentSlide.title}
            </h2>
            <p className="mt-3 text-xs text-muted leading-relaxed max-w-md">
              {currentSlide.description}
            </p>
          </div>

          {/* Navigation controls: dots + arrows */}
          <div className="flex items-center justify-between pt-8">
            {/* Dots */}
            <div className="flex items-center gap-2">
              {slides.map((slide, idx) => (
                <button
                  key={slide.id}
                  onClick={() => setCurrentIndex(idx)}
                  aria-label={`Go to slide ${idx + 1}`}
                  className={`h-2 rounded-full transition-all duration-300 ${
                    currentIndex === idx
                      ? "w-6 bg-primary-dark"
                      : "w-2 bg-slate-300 hover:bg-muted"
                  }`}
                />
              ))}
            </div>

            {/* Arrow buttons */}
            <div className="flex items-center gap-2">
              <button
                onClick={handlePrev}
                aria-label="Previous slide"
                className="w-9 h-9 rounded-full border border-slate-200 bg-white text-muted flex items-center justify-center hover:bg-slate-50 hover:border-slate-300 transition-colors shadow-sm active:scale-95"
              >
                <ChevronLeft className="w-4 h-4" />
              </button>
              <button
                onClick={handleNext}
                aria-label="Next slide"
                className="w-9 h-9 rounded-full border border-slate-200 bg-white text-slate-600 flex items-center justify-center hover:bg-slate-50 hover:border-slate-300 transition-colors shadow-sm active:scale-95"
              >
                <ChevronRight className="w-4 h-4" />
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
