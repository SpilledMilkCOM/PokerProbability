import { Component } from '@angular/core';

import { CardComponent } from '../card/card.component';

@Component({
    selector: 'home',
    template: require('./home.component.html')
})
export class HomeComponent {
    public card2Visible: boolean;
    public card3Visible: boolean;
    public card4Visible: boolean;
    public card5Visible: boolean;
    public card6Visible: boolean;
    public card7Visible: boolean;
    public winPercent = 0.0;

    public constructor() {
        this.card2Visible = false;
    }

    public calculate() {
        this.winPercent = 44.44;
    }

    public handleCard1Event(evt) {
        this.card2Visible = true;
    }

    public handleCard2Event(evt) {
        this.card3Visible = true;
    }

    public handleCard3Event(evt) {
        this.card4Visible = true;
    }

    public handleCard4Event(evt) {
        this.card5Visible = true;
    }

    public handleCard5Event(evt) {
        this.card6Visible = true;
    }

    public handleCard6Event(evt) {
        this.card7Visible = true;
    }
}