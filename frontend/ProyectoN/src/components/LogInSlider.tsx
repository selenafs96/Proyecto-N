
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
  footerLabel: string;
  footerValue: string;
  title: string;
  description: string;
  icon: React.ReactNode;
}

const slides: Slide[] = [
  {
    id: 1,
    icon: <Activity className="w-4 h-4 text-[#346e57]" />,
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
    icon: <ShieldCheck className="w-4 h-4 text-[#346e57]" />,
    badge: "Fuentes de datos homologadas",
    metrics: [
      { label: "Composición de alimentos básicos", value: "BEDCA Española", swapOrder: true, metricIcon: <Database /> },
      { label: "Composición de alimentos envasados", value: "Open Food Facts", swapOrder: true },
    ],
    footerLabel: "Protocolo de Exclusión Estricta",
    footerValue: "Certificación Médica Activa",
    title: "Seguridad y datos homologados",
    description: "Conexión cifrada de grado clínico con datos de composición de alimentos provenientes de bases de datos oficiales BEDCA y Open Food Facts."
  },
  {
    id: 3,
    icon: <CalendarClock className="w-4 h-4 text-[#346e57]" />,
    badge: "Seguimiento Clínico y Consultas",
    badgeStatus: "Sincronizado",
    metrics: [
      { label: "Adherencia Pauta", value: "94%", sub: "Excelente", swapOrder: false },
      { label: "Próxima Revisión", value: "7 Nov", sub: "10:30h", swapOrder: false },
      { label: "Evolución Peso", value: "-2.4 kg", sub: "Objetivo", swapOrder: false },
    ],
    footerLabel: "Historial de Consultas & Bioimpedancia",
    footerValue: "Expediente #MED-84920",
    title: "Gestión Integral del Paciente",
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
      {/* Dynamic Slide Content */}
      <div className="relative min-h-[380px] flex flex-col justify-between">
        {/* Floating Metric Preview Card */}
        <div 
          key={`card-${currentSlide.id}`}
          className="bg-white rounded-2xl p-6 border border-slate-100 shadow-[0_8px_30px_rgb(0,0,0,0.04)] transition-all duration-500 ease-out transform"
        >
          {/* Card Header Badge */}
          <div className="flex items-center justify-between pb-4 border-b border-slate-100">
            <div className="flex items-center gap-2 text-slate-800 font-semibold text-sm">
              <span className="p-1 rounded bg-[#346e57]/10 flex items-center justify-center">
                {currentSlide.icon}
              </span>
              <span>{currentSlide.badge}</span>
            </div>
            { currentSlide.badgeStatus && 
                <span className="px-2.5 py-0.5 rounded-full text-xs font-medium bg-[#e5f8ee] text-[#2d5a47]">
                {currentSlide.badgeStatus}
                </span>
            }
          </div>

          {/* Metrics grid */}
          <div className="flex justify-between my-4 gap-3">
            {currentSlide.metrics.map((m, i) => (
              <div 
                key={i} 
                className="bg-light-gray rounded-xl p-3 border border-mid-gray text-center w-full"
              >
                { m.swapOrder ? 
                <div className="text-lg font-bold text-slate-800 tracking-tight">
                  {m.value}{' '}
                <div className="text-xs text-slate-500 font-medium mb-1">{m.label}</div>
                  <span className="text-xs font-normal text-slate-400">{m.sub}</span>
                </div>
                : 
                <div className="text-lg font-bold text-slate-800 tracking-tight">
                <div className="text-xs text-slate-500 font-medium mb-1">{m.label}</div>
                  {m.value}{' '}
                  <span className="text-xs font-normal text-slate-400">{m.sub}</span>
                </div> }
              </div>
            ))}
          </div>

          {/* Card Footer */}
          <div className="flex items-center justify-between pt-3 border-t border-slate-100 text-xs">
            <span className="text-slate-500">{currentSlide.footerLabel}</span>
            <span className="font-semibold text-slate-800">{currentSlide.footerValue}</span>
          </div>
        </div>

        {/* Text Section (Title & Description) */}
        <div 
          key={`text-${currentSlide.id}`}
          className="mt-8 transition-opacity duration-500 ease-out"
        >
          <h2 className="text-2xl font-bold text-slate-900 tracking-tight">
            {currentSlide.title}
          </h2>
          <p className="mt-3 text-sm text-slate-600 leading-relaxed max-w-md">
            {currentSlide.description}
          </p>
        </div>

        {/* Navigation Controls: Dots + Arrows */}
        <div className="flex items-center justify-between pt-8">
          {/* Pagination Indicators (Dots) */}
          <div className="flex items-center gap-2">
            {slides.map((slide, idx) => (
              <button
                key={slide.id}
                onClick={() => setCurrentIndex(idx)}
                aria-label={`Ir a diapositiva ${idx + 1}`}
                className={`h-2 rounded-full transition-all duration-300 ${
                  currentIndex === idx 
                    ? 'w-6 bg-[#346e57]' 
                    : 'w-2 bg-slate-300 hover:bg-slate-400'
                }`}
              />
            ))}
          </div>

          {/* Arrow Buttons */}
          <div className="flex items-center gap-2">
            <button
              onClick={handlePrev}
              aria-label="Diapositiva anterior"
              className="w-9 h-9 rounded-full border border-slate-200 bg-white text-slate-600 flex items-center justify-center hover:bg-slate-50 hover:border-slate-300 transition-colors shadow-sm active:scale-95"
            >
              <ChevronLeft className="w-4 h-4" />
            </button>
            <button
              onClick={handleNext}
              aria-label="Diapositiva siguiente"
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