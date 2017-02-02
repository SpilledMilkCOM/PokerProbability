import { Injectable } from "@angular/core";
import { Http, Response } from '@angular/http';

// Only pull in the pieces of rxjs we want to use.

import "rxjs/add/operator/map";         // Define the "map" function from a node module.
import "rxjs/add/operator/catch";
import { Observable } from "rxjs/Observable";
import "rxjs/add/observable/throw";

@Injectable()           // similar to Angular 1's $inject
export class FetchDataService {
    public getDataResult: IWeatherForecast[];

    constructor(private http: Http) {
        // Http is injected into http variable

        this.http = http;
    }

    public getData() {
        //this.http.get('/api/SampleData/WeatherForecasts').subscribe(apiResult => {
        //    this.getDataResult = apiResult.json();
        //});

        console.log("FetchDataService.getData()");

        return this.http.get('/api/SampleData/WeatherForecasts')
            .map((response: Response) => {
                console.log("FetchDataService.getData() - mapping response.");

                return <IWeatherForecast[]>response.json();
            })
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        let msg = `Status code ${error.status} on url ${error.url}`;
        console.error(msg);

        return Observable.throw(msg);
    }
}