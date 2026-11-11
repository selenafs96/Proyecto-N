import Image from "next/image";
import { motion } from "motion/react";
import Link from "next/link";

type NavigationOptionProps = {
    collapsed: boolean,
    icon: string,
    text: string
}

function NavigationOption({ collapsed, icon, text } : NavigationOptionProps ) {
  return (
    <Link
      href="/dashboard"
      className={`flex items-center transition-colors duration-200 hover:bg-primary-mid focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-primary-dark ${
        collapsed
          ? "h-10 w-10 self-center justify-center rounded-full bg-primary-light"
          : "gap-3 rounded-2xl bg-primary-light px-2.5 py-3"
      }`}
    >
      <Image
        src={icon}
        alt="Dashboard icon"
        width={collapsed ? 18 : 14}
        height={collapsed ? 18 : 14}
        className="shrink-0"
      />
      {!collapsed && (
        <motion.span
          animate={{
            opacity: collapsed ? 0 : 1,
            width: collapsed ? 0 : "auto",
          }}
          transition={{ duration: 0.2 }}
          className="whitespace-nowrap overflow-hidden text-primary-extra-dark font-semibold text-base"
        >
          {text}
        </motion.span>
      )}
    </Link>
  );
}

export default NavigationOption;
