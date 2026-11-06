"use client";

import { useState } from "react";
import Image from "next/image";
import Link from "next/link";

function Sidebar() {
  const [collapsed, setCollapsed] = useState(true);

  function handleCollapse() {
    setCollapsed((prev) => !prev);
  }

  return (
    <aside
      className={`flex flex-col ${collapsed ? "w-16" : "w-75"} bg-white justify-between border-3 border-light-gray`}
    >
      {/* Sidebar header and navigation options */}
      <div className="flex flex-col">
        {/* Logo, title, description and collapse button */}
        <div
          className={`flex ${collapsed ? "px-2 py-6 justify-center" : "p-6"} justify-between`}
        >
          {/* Logo, title and description */}
          {!collapsed && (
            <div className="flex gap-3">
              <Image
                src="/flower-logo.svg"
                alt="Application logo"
                width={40}
                height={40}
              />
              <div className="flex flex-col">
                <span className="text-main font-bold text-lg">Proyecto N</span>
                <p className="text-main text-sm">Nutrición clínica</p>
              </div>
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
          <Link
            href="/dashboard"
            className={`flex items-center transition-colors duration-200 hover:bg-primary-mid focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-primary-dark ${
              collapsed
                ? "h-10 w-10 self-center justify-center rounded-full bg-primary-light"
                : "gap-3 rounded-2xl bg-primary-light px-2.5 py-3"
            }`}
          >
            <Image
              src="/dashboard.svg"
              alt="Dashboard icon"
              width={collapsed ? 18 : 14}
              height={collapsed ? 18 : 14}
              className="shrink-0"
            />
            {!collapsed && (
              <span className="text-primary-extra-dark font-semibold text-base">
                Panel principal
              </span>
            )}
          </Link>
          {/* Pacientes */}
          <Link
            href="/dashboard"
            className={`flex items-center transition-colors duration-200 hover:bg-primary-light focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-primary-dark ${
              collapsed
                ? "h-10 w-10 self-center justify-center rounded-full hover:bg-primary-light"
                : "gap-3 rounded-2xl bg-white px-2.5 py-3"
            }`}
          >
            <Image
              src="/patients.svg"
              alt="Patients icon"
              width={collapsed ? 18 : 14}
              height={collapsed ? 16 : 12}
              className="shrink-0"
            />
            {!collapsed && (
              <span className="text-primary-extra-dark font-medium text-base">
                Pacientes
              </span>
            )}
          </Link>
          {/* Planes nutricionales */}
          <Link
            href="/dashboard"
            className={`flex items-center transition-colors duration-200 hover:bg-primary-light focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-primary-dark ${
              collapsed
                ? "h-10 w-10 self-center justify-center rounded-full hover:bg-primary-light"
                : "gap-3 rounded-2xl bg-white px-2.5 py-3"
            }`}
          >
            <Image
              src="/nutritional-plans.svg"
              alt="Nutritional plans icon"
              width={collapsed ? 16 : 14}
              height={collapsed ? 19 : 17}
              className="shrink-0"
            />
            {!collapsed && (
              <span className="text-primary-extra-dark font-medium text-base">
                Planes nutricionales
              </span>
            )}
          </Link>
          {/* Recetas */}
          <Link
            href="/dashboard"
            className={`flex items-center transition-colors duration-200 hover:bg-primary-light focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-primary-dark ${
              collapsed
                ? "h-10 w-10 self-center justify-center rounded-full hover:bg-primary-light"
                : "gap-3 rounded-2xl bg-white px-2.5 py-3"
            }`}
          >
            <Image
              src="/recipes.svg"
              alt="Recipes icon"
              width={collapsed ? 18 : 14}
              height={collapsed ? 18 : 15}
              className="shrink-0"
            />
            {!collapsed && (
              <span className="text-primary-extra-dark font-medium text-base">
                Recetas
              </span>
            )}
          </Link>
          {/* Consultas y agenda */}
          <Link
            href="/dashboard"
            className={`flex items-center transition-colors duration-200 hover:bg-primary-light focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-primary-dark ${
              collapsed
                ? "h-10 w-10 self-center justify-center rounded-full hover:bg-primary-light"
                : "gap-3 rounded-2xl bg-white px-2.5 py-3"
            }`}
          >
            <Image
              src="/agenda.svg"
              alt="Appointments and agenda icon"
              width={collapsed ? 16 : 14}
              height={collapsed ? 18 : 16}
              className="shrink-0"
            />
            {!collapsed && (
              <span className="text-primary-extra-dark font-medium text-base">
                Consultas y agenda
              </span>
            )}
          </Link>
        </div>
      </div>
      {/* Sidebar footer */}
      <div
        className={`flex flex-col border-t-2 border-light-gray ${collapsed ? "p-2" : "p-4"} gap-3`}
      >
        {/* Mi perfil button */}
        <Link
          href="/dashboard/profile"
          className={`flex items-center justify-center transition-colors duration-200 hover:bg-primary-mid focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-primary-dark ${
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
            <span className="text-base text-primary-extra-dark">Mi perfil</span>
          )}
        </Link>
        {/* Nuevo paciente button */}
        <Link
          href="/dashboard"
          className={`flex items-center justify-center transition-opacity duration-200 hover:opacity-90 focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-primary-dark ${
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
            <span className="text-base text-white">Nuevo paciente</span>
          )}
        </Link>
      </div>
    </aside>
  );
}

export default Sidebar;
