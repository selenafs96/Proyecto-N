"use client";

import { useState } from "react";
import Image from "next/image";
import Link from "next/link";
import { motion } from "motion/react";
import NavigationOption from "./NavigationOption";

function Sidebar() {
  const [collapsed, setCollapsed] = useState(true);

  function handleCollapse() {
    setCollapsed((prev) => !prev);
  }

  return (
    <motion.aside
      initial={false}
      animate={{ width: collapsed ? 64 : 280 }}
      transition={{ duration: 0.3, ease: "easeInOut" }}
      className={`flex shrink-0 flex-col bg-white justify-between border-3 border-light-gray overflow-hidden `}
    >
      {/* Sidebar header and navigation options */}
      <div className="flex flex-col">
        {/* Logo, title, description and collapse button */}
        <div
          className={`flex ${collapsed ? "px-2 py-6 justify-center" : "p-6"} justify-between`}
        >
          {/* Logo, title and description */}
          {!collapsed && (
            <div className="flex gap-3 min-w-[210px] overflow-hiden">
              <Image
                src="/flower-logo.svg"
                alt="Application logo"
                width={40}
                height={40}
              />
              <motion.div 
                animate={{ opacity: collapsed ? 0 : 1 }}
                transition={{ duration: 0.2, delay: collapsed ? 0 : 0.1 }}
                className="flex flex-col whitespace-nowrap">
                <span className="text-main font-bold text-lg">Proyecto N</span>
                <p className="text-main text-sm">Nutrición clínica</p>
              </motion.div>
            </div>
          )}

          {/* Collapse sidebar icon */}
          <button type="button" onClick={handleCollapse}>
            <Image
              src={collapsed ? "/open-sidebar.svg" : "/hide-sidebar.svg"}
              alt="Icon hide/open sidebar"
              width={20}
              height={20}
            />
          </button>
        </div>
        {/* Navigation options container */}
        <div
          className={`flex flex-col justify-center ${collapsed ? "px-2" : "px-4"} pt-6 gap-2`}
        >
          {/* Panel principal */}
          <NavigationOption collapsed={collapsed} icon="/dashboard.svg" text="Panel principal"/>
          {/* Pacientes */}
          <NavigationOption collapsed={collapsed} icon="dashboard.svg" text="Pacientes"/>
          {/* Planes nutricionales */}
          <NavigationOption collapsed={collapsed} icon="dashboard.svg" text="Planes nutricionales"/>
          {/* Recetas */}
          <NavigationOption collapsed={collapsed} icon="dashboard.svg" text="Recetas"/>
          {/* Consultas y agenda */}
          <NavigationOption collapsed={collapsed} icon="dashboard.svg" text="Consultas y agenda"/>
        </div>
      </div>
      {/* Sidebar footer */}
      <div
        className={`flex flex-col border-t-2 border-light-gray ${collapsed ? "p-2" : "p-4"} gap-3`}
      >
        {/* Mi perfil button */}
        <Link
          href="/dashboard/profile"
          className={`whitespace-nowrap overflow-hidden flex items-center justify-center transition-colors duration-200 hover:bg-primary-mid focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-primary-dark ${
            collapsed
              ? "h-10 w-10 self-center rounded-full bg-primary-light"
              : "gap-2 rounded-2xl bg-primary-light px-3 py-2"
          }`}
        >
          <Image
            src="/profile.svg"
            alt="Profile icon"
            width={collapsed ? 18 : 15}
            height={collapsed ? 18 : 15}
            className="shrink-0"
          />
          {!collapsed && (
            <motion.span 
              animate={{ opacity: collapsed ? 0 : 1, width: collapsed ? 0 : "auto" }}
              transition={{ duration: 0.2 }}
              className="text-base text-primary-extra-dark">Mi perfil</motion.span>
          )}
        </Link>
        {/* Nuevo paciente button */}
        <Link
          href="/dashboard"
          className={`whitespace-nowrap overflow-hidden flex items-center justify-center transition-opacity duration-200 hover:opacity-90 focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-primary-dark ${
            collapsed
              ? "h-10 w-10 self-center rounded-full"
              : "gap-2 rounded-xl bg-primary-dark px-3 py-2"
          }`}
        >
          <Image
            src={collapsed ? "/collapsed-add-patient.svg" : "/add.svg"}
            alt="Add patient icon"
            width={collapsed ? 40 : 9}
            height={collapsed ? 40 : 9}
            className="shrink-0"
          />
          {!collapsed && (
            <motion.span 
              animate={{ opacity: collapsed ? 0 : 1, width: collapsed ? 0 : "auto" }}
              transition={{ duration: 0.2 }}
              className="text-base text-white">Nuevo paciente</motion.span>
          )}
        </Link>
      </div>
    </motion.aside>
  );
}

export default Sidebar;
