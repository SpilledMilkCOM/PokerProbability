// This class is only used for test data.

export class WeatherForcast implements IWeatherForecast {

    constructor(public dateFormatted: string, public temperatureC: number, public temperatureF: number, public summary: string) {
    }

}