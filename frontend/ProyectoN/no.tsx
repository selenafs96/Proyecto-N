 <div className="py-44.5 flex flex-col gap-6">
          {/* Slide */}
          <div className="flex flex-col mr-80">
            {/* Slide card */}
            <div className="flex flex-col gap-3 p-5 bg-white border border-mid-gray rounded-2xl">
              {/* Top slide */}
              <div className="flex justify-between pb-3 border-b border-b-mid-gray">
                {/* Balance energético y macros */}
                <div className="flex justify-between rounded-full px-4 py-0.5 h-6 items-center gap-2">
                  <Image
                    src="/chart.svg"
                    alt="Green dot"
                    width={15}
                    height={15}
                  />
                  <p className="text-main font-bold text-sm">
                    Balance energético y macros
                  </p>
                </div>
                {/* Tiempo real */}
                <div className="bg-primary-light flex justify-between rounded-full px-2 py-0.5 h-6 items-center gap-2">
                  <p className="text-primary-dark font-semibold text-xs">
                    Tiempo real
                  </p>
                </div>
              </div>
              {/* Mid slide */}
              <div className="flex gap-3 justify-between">
                <div className="flex flex-col border border-mid-gray bg-light-gray rounded-xl p-3 w-full items-center">
                  <p className="text-sm text-muted font-light">Proteínas</p>
                  <p className="font-bold text-main">
                    138g <span className="text-xs text-primary-dark">28%</span>
                  </p>
                </div>
                <div className="flex flex-col border border-mid-gray bg-light-gray rounded-xl p-3 w-full items-center">
                  <p className="text-sm text-muted font-light">Proteínas</p>
                  <p className="font-bold text-main">
                    138g <span className="text-xs text-primary-dark">44%</span>
                  </p>
                </div>
                <div className="flex flex-col border border-mid-gray bg-light-gray rounded-xl p-3 w-full items-center">
                  <p className="text-sm text-muted font-light">Proteínas</p>
                  <p className="font-bold text-main">
                    138g <span className="text-xs text-primary-dark">28%</span>
                  </p>
                </div>
              </div>
              {/* Bottom slide */}
              <div className="flex justify-between pt-3 items-center">
                <p className="text-muted font-light text-sm">
                  Gasto energético basal (Harris-Benedict)
                </p>
                <p className="font-semibold text-main">2140kcal/día</p>
              </div>
            </div>
          </div>
          {/* Título y descripción*/}
          <div className="flex flex-col mr-80 gap-2">
            <h2 className="text-main font-bold text-2xl">
              Planificación nutricional de precisión
            </h2>
            <p className="text-muted text-sm">
              Cálculos automáticos de macronutrientes, gasto metabólico personalizado y sincronización de bioimpedancia en tiempo real.
            </p>
          </div>
        </div>