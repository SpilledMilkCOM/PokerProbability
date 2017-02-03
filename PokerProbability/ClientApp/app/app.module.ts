import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';                   // BrowserModule, HttpModule, and JsonpModule
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { CardComponent } from './components/card/card.component';

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        CardComponent,
        HomeComponent
    ],
    imports: [
        UniversalModule,    // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        FormsModule,        // For two-way binding [(ngModel)]

        // How do you wrap security in the modules/components if the client can get around in the debugger?

        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
    // COULD put providers: here for "global" providers (Angular 2 uses a provider tree)
    // (Might want to put services/providers here if EAGER loaded.)
    // Could be singletons versus inject into the component.  Every component (or service) can have access to these providers.
    // If you only provide a service ONCE, then by its very nature it's a SINGLETON.
})
export class AppModule {
}