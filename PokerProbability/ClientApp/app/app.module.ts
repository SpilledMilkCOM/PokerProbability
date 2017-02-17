import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UniversalModule } from 'angular2-universal';                   // BrowserModule, HttpModule, and JsonpModule

import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { CardComponent } from './components/card/card.component';

import { AppRoutingModule, routableComponents } from "./app-routing.module";

// Implementing a fake service so Http can be used in the service.

import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { InMemoryDataService } from './components/fetchdata/in-memory-data.service';

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        routableComponents,
        CardComponent
    ],
    imports: [
        UniversalModule,    // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        FormsModule,        // For two-way binding [(ngModel)]
        //InMemoryWebApiModule.forRoot(InMemoryDataService),

        // How do you wrap security in the modules/components if the client can get around in the debugger?

        AppRoutingModule
    ]
    // COULD put providers: here for "global" providers (Angular 2 uses a provider tree)
    // (Might want to put services/providers here if EAGER loaded.)
    // Could be singletons versus inject into the component.  Every component (or service) can have access to these providers.
    // If you only provide a service ONCE, then by its very nature it's a SINGLETON.
})
export class AppModule {
}