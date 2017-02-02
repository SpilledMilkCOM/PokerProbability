import { Component } from '@angular/core';

import { CardComponent } from '../card/card.component';

@Component({
    selector: 'home',
    template: require('./home.component.html')
})

export class HomeComponent {
    public winPercent = 0.0;

    public calculate() {
        this.winPercent = 44.44;
    }
}