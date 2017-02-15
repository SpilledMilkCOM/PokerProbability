import { Component, EventEmitter, Input, Output } from "@angular/core";
import { CardService } from "./card.service";
import { Suit } from "./Suit";

@Component({
    selector: "card",
    inputs: ['cardVisible'],
    template: require("./card.component.html"),
    providers: [CardService]
})
export class CardComponent {
    public currentCard: string;
    public currentSuit: Suit = new Suit(1, "?", "Spade");
    public currentValue: string = "A";

    public suits: Suit[] = [this.currentSuit, new Suit(2, "?", "Diamond"), new Suit(3, "?", "Club"), new Suit(4, "?", "Heart")];
    public values = [this.currentValue, "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"];

    //@Input cardVisible: boolean;      // I don't know why this didn't work  :(  Compiler?
    public cardVisible: boolean;
    @Output() isDefinedEvent: EventEmitter = new EventEmitter();

    constructor(private cardService: CardService) {
        this.cardVisible = true;
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

        this.isDefinedEvent.next(this.currentCard != null);
    }
}