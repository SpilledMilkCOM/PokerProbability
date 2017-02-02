import { Component, OnInit } from '@angular/core';
import { FetchDataService } from "./fetchdata.service";

import "rxjs/add/operator/catch";
import { Observable } from "rxjs/Observable";

@Component({
    selector: 'fetchdata',
    template: require('./fetchdata.component.html'),
    providers: [FetchDataService]       // Provided here...  (Means - available here and anywhere in its tree) Also "hiding" this service from others OUTSIDE of the tree.
})
export class FetchDataComponent implements OnInit {
    errorMessage: string;
    //forecasts: IWeatherForecast[];                // Use an array only if you're not assigning a Promise or Observable.
    //forecasts: Observable<IWeatherForecast[]>;
    forecasts: Promise<IWeatherForecast[]>;

    //constructor(http: Http) {
    //    http.get('/api/SampleData/WeatherForecasts').subscribe(result => {
    //        this.forecasts = result.json();
    //    });

    constructor(private dataService: FetchDataService) {
        // Keep data retrieval OUT of the constructor.
    }

    // This is part of the LifeCycle Hooks
    // You DON'T have to implement the OnInit interface, this will still work provided the signature matches.
    ngOnInit() {
        console.log("FetchDataComponent.ngOnInit()");

        /*
        this.dataService.getData()
            .subscribe(
            data => {
                console.log("FetchDataComponent.ngOnInit() - subscription returned.");

                this.forecasts = data;

                console.log("FetchDataComponent.ngOnInit() - data assigned.");
            },
            error => this.errorMessage = <any>error
            );
        */

        // Assigning the observable assigns the async pipe.
        // (Could make this wait for the promise with the .then() function, but the forcasts variable would need to change back to just an array.)
        this.forecasts = this.dataService.getData()
            .catch(error => this.errorMessage = <any>error);

        /*

        This call "feels" less asynchronous even though it is.

        this.forecasts = this.dataService.getData()
            .do(() => this.toastService.activate('Got data'))
            .catch(error => this.errorMessage = <any>error)
            .finally( do stuff here too);
        */
    }
}