import UserService from "@/src/services/userService";
import Image from "next/image";

export default async function Home() {
  const userService = new UserService();
  const userData = await userService.getUserById(1);
  console.log(userData);

  return (
    <div className="flex flex-col flex-1 items-center justify-center bg-zinc-50 font-sans dark:bg-black">
      <main className="flex flex-1 w-full max-w-3xl flex-col items-center justify-between py-32 px-16 bg-white dark:bg-black sm:items-start">
        {userData &&
          <h1>{userData.email}</h1>
        }
      </main>
    </div>
  );
}
