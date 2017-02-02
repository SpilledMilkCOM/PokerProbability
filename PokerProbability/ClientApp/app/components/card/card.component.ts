import { Component } from "@angular/core";
import { Suit } from "./Suit";

@Component({
    selector: "card",
    template: require("./card.component.html")
})

export class CardComponent {
    public currentCard: string;
    public currentSuit: Suit = new Suit(1, "?", "Spade");       // @Input()  ???  Maybe for [(ngModel)] two-way binding.
    public currentValue: string = "A";
    public isDefined: boolean = false;
    public suits: Suit[] = [this.currentSuit, new Suit(2, "?", "Diamond"), new Suit(3, "?", "Club"), new Suit(4, "?", "Heart")];
    public values = [this.currentValue, "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"];

    constructor() {
    }

    public selectCard(cardIndex) {
        this.currentValue = this.values[cardIndex];

        this.updateCurrentCard();
    }

    public selectSuit(suitId) {
        this.currentSuit = this.suits[suitId - 1];

        this.updateCurrentCard();
    }

    private updateCurrentCard() {
        this.currentCard = this.currentValue.concat(this.currentSuit.abbreviation);
    }
}