import { apiClient } from "@/src/lib/axios";
import { WeatherForecastResponse } from "@/src/types/weatherforecast";

class WeatherService {
  private apiUrl: string;

  constructor() {
    this.apiUrl = process.env.NEXT_PUBLIC_API_URL + "/weatherforecast";
  }

  async getWeatherForecast(): Promise<WeatherForecastResponse[] | null> {
    try {
      const response = await apiClient.get<WeatherForecastResponse[]>(
        this.apiUrl,
      );
      return response.data;
    } catch (error) {
      console.error("Error al obtener el pronóstico del tiempo:", error);
      return null;
    }
  }
}

export default WeatherService;
