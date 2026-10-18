
import React, { useState, useEffect } from 'react';
import { ChevronLeft, ChevronRight, Activity, ShieldCheck, CalendarClock, Database } from 'lucide-react';

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
    description: "Cálculos automáticos de macronutrientes y gasto metabólico personalizado."
  },
  {
    id: 2,
    icon: <ShieldCheck className="w-4 h-4 text-primary-dark" />,
    badge: "Fuentes de datos homologadas",
    metrics: [
      { label: "Composición de alimentos básicos", value: "BEDCA España", swapOrder: true, metricIcon: <Database className="text-primary-dark"/> },
      { label: "Composición de alimentos envasados", value: "Open Food Facts", swapOrder: true },
    ],
    title: "Seguridad y datos homologados",
    description: "Datos de composición de alimentos provenientes de bases de datos oficiales BEDCA y Open Food Facts."
  },
  {
    id: 3,
    icon: <CalendarClock className="w-4 h-4 text-primary-dark" />,
    badge: "Seguimiento clínico y consultas",
    metrics: [
      { label: "Adherencia", value: "94%", sub: "Excelente", swapOrder: false },
      { label: "Próxima revisión", value: "7 Nov", sub: "10:30h", swapOrder: false },
      { label: "Evolución peso", value: "-2.4 kg", swapOrder: false },
    ],
    footerLabel: "Historial de consultas y bioimpedancia",
    footerValue: "Expediente #84920",
    title: "Gestión integral del paciente",
    description: "Centraliza historia clínica, evolución antropométrica e historial de citas en un entorno clínico despejado y seguro."
  }
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
    <div className="w-full max-w-lg flex flex-col justify-between py-6">
      {/* Dynamic slide content */}
      <div className="relative flex flex-col justify-between">
        {/* Floating metric preview card */}
        <div 
          key={currentSlide.id}
          className="bg-white rounded-2xl p-6 border border-light-gray shadow-[0_8px_30px_rgb(0,0,0,0.04)] transition-all duration-500 ease-out transform h-55"
        >
          {/* Card header badge */}
          <div className="flex items-center justify-between pb-4 border-b border-light-gray">
            <div className="flex items-center gap-2 text-main font-semibold text-sm">
              <span className="p-1 rounded bg-mid-gray flex items-center justify-center">
                {currentSlide.icon}
              </span>
              <span>{currentSlide.badge}</span>
            </div>
            { currentSlide.badgeStatus && 
                <span className="px-2.5 py-0.5 rounded-full text-xs font-medium bg-[#e5f8ee] text-primary-dark">
                {currentSlide.badgeStatus}
                </span>
            }
          </div>

          {/* Metrics grid */}
          <div className="flex justify-between my-4 gap-3">
            {currentSlide.metrics.map((m, i) => (
              <div 
                key={m.label} 
                className="bg-light-gray rounded-xl p-3 border border-mid-gray text-center w-full gap-4"
              >
                <div className="flex items-center justify-center">
                { m.metricIcon && <div>{m.metricIcon}</div>}
                { m.swapOrder ? 
                <div className="text-lg font-bold text-main tracking-tight">
                  {m.value}{' '}
                <div className="text-xs text-muted font-medium mb-1">{m.label}</div>
                  <span className="text-xs font-normal text-mid-gray">{m.sub}</span>
                </div>
                : 
                <div className="text-lg font-bold text-dark-gray tracking-tight">
                <div className="text-xs text-muted font-medium mb-1">{m.label}</div>
                  {m.value}{' '}
                  <span className="text-xs font-normal text-muted">{m.sub}</span>
                </div> }
                </div>
              </div>
            ))}
          </div>

          {/* Card footer */}
          <div className="flex items-center justify-between pt-3 border-t border-light-gray text-xs">
            <span className="text-muted">{currentSlide.footerLabel}</span>
            <span className="font-semibold text-main">{currentSlide.footerValue}</span>
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
          <p className="mt-3 text-sm text-muted leading-relaxed max-w-md">
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
                    ? 'w-6 bg-primary-dark' 
                    : 'w-2 bg-slate-300 hover:bg-muted'
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
  );
}