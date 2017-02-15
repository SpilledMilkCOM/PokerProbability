/*
    This module cleans up some of the routing declarations so it doesn"t ALL have to be in the app.module
*/

import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { HomeComponent } from "./components/home/home.component";

// STILL needed for the app module to "declare" even though this is lazy loaded?
import { CounterComponent } from "./components/counter/counter.component";
import { FetchDataComponent } from "./components/fetchdata/fetchdata.component";

const routes: Routes = [
    { path: "", redirectTo: "home", pathMatch: "full" },
    { path: "home", component: HomeComponent },
    // Eagerly Loaded...
    { path: "counter", component: CounterComponent },
    { path: "fetch-data", component: FetchDataComponent },

    // Need to create Modules to have these components Lazy Loaded.
    //{ path: "counter", loadChildren: "/components/counter/counter.component#CounterModule" },
    //{ path: "fetch-data", loadChildren: "/components/fetchdata/fetchdata.component#FetchDataModule" },
    { path: "**", redirectTo: "home" }                          // Used for 404 route (page not found)
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }

export const routableComponents = [
    HomeComponent,
    CounterComponent,
    FetchDataComponent
];