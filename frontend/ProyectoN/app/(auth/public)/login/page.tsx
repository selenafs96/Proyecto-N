import Image from "next/image";

function LoginPage() {
    return (
        <main className="flex">
            <div className="w-full bg-primary-light border border-gray-border p-14">
                { /* Logo, title, description and version header */ }
                <div className="flex justify-between items-center">
                    <div className="flex items-center gap-3">
                        <Image src="/logo.svg" alt="Proyecto N logo" width={36} height={36} />
                        <div className="flex flex-col">
                            <h1 className="text-main font-bold text-base">Proyecto N</h1>
                            <p className="text-muted text-xs">Nutrición clínica</p>
                        </div>
                    </div>
                    <div className="bg-white border border-primary-mid flex justify-between rounded-full px-4 py-0.5 h-6 items-center gap-2">
                        <Image src="/dot.svg" alt="Green dot" width={8} height={8} />
                        <p className="text-primary-dark font-semibold text-xs">v1.0.0</p>
                    </div>
                </div>
                <div className="py-44.5 flex flex-col gap-6">
                    { /* Slide */ }
                    <div className="flex flex-col">
                        { /* Slide card */ }
                        <div className="flex flex-col gap-3 p-5 bg-white border border-mid-gray rounded-2xl">
                            { /* Top */ }
                            <div className="flex justify-between pb-3 border-b border-b-mid-gray">
                                { /* Balance energético y macros */ }
                                <div className="flex justify-between rounded-full px-4 py-0.5 h-6 items-center gap-2">
                                    <Image src="/chart.svg" alt="Green dot" width={15} height={15} />
                                    <p className="text-main font-bold text-sm">Balance energético y macros</p>
                                </div>
                                { /* Tiempo real */ }
                                <div className="bg-primary-light flex justify-between rounded-full px-2 py-0.5 h-6 items-center gap-2">
                                    <p className="text-primary-dark font-semibold text-xs">Tiempo real</p>
                                </div>
                            </div>
                            { /* Mid */ }
                            <div className="flex gap-3">
                                <div></div>
                                <div></div>
                                <div></div>
                            </div>
                        </div>
                        { /* Slide title + description */ }
                        <div>
                            <h2 className="text-main font-bold text-2xl">Title</h2>
                            <p className="text-muted text-sm">Description</p>
                        </div>
                    </div>
                </div>
            </div>
            <div className="w-full bg-white border border-mid-grayr">Hello</div>
        </main>
    )
}

export default LoginPage;