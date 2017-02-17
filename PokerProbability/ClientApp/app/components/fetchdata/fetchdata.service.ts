import { Injectable } from "@angular/core";
import { Http, Response } from '@angular/http';

// Only pull in the pieces of rxjs we want to use.

import "rxjs/add/operator/map";         // Define the "map" function from a node module.
import "rxjs/add/operator/catch";
import "rxjs/add/operator/toPromise";
import { Observable } from "rxjs/Observable";
import "rxjs/add/observable/throw";

@Injectable()           // similar to Angular 1's $inject
export class FetchDataService {
    private dataUrl = '/api/SampleData/WeatherForecasts';
    public getDataResult: IWeatherForecast[];

    constructor(private http: Http) {
        // Http is injected into http variable (and it's private so that's a good thing because you don't want other components or services to use this member)

        this.http = http;
    }

    public getData() {   // getData() : Observable<IWeatherForecast[]>
        //this.http.get('/api/SampleData/WeatherForecasts').subscribe(apiResult => {
        //    this.getDataResult = apiResult.json();
        //});

        console.log("FetchDataService.getData()");

        //return null;

        return this.http.get(this.dataUrl)
            .map((response: Response) => {

                // COULD bring in a logger service instead of using the console.
                console.log("FetchDataService.getData() - mapping response.");

                // If the data is returned versus an IActionResult, then you can just reference .json()
                // If an IActionResult is returned then you need .json().data to get at the data since it's wrapped in a ObjectResult

                //return <IWeatherForecast[]>response.json().data;

                var data = <IWeatherForecast[]>response.json();

                console.log(data);

                return data;
            })
            .toPromise()
            //.then()
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        let msg = `Status code ${error.status} on url ${error.url}`;
        console.error(msg);

        return Observable.throw(msg);
    }
}