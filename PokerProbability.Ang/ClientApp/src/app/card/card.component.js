"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var card_service_1 = require("./card.service");
var Suit_1 = require("./Suit");
var CardComponent = /** @class */ (function () {
    function CardComponent(cardService) {
        this.cardService = cardService;
        this.currentSuit = new Suit_1.Suit(1, "?", "Spade");
        this.currentValue = "A";
        this.suits = [this.currentSuit, new Suit_1.Suit(2, "?", "Diamond"), new Suit_1.Suit(3, "?", "Club"), new Suit_1.Suit(4, "?", "Heart")];
        this.values = [this.currentValue, "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"];
        this.isDefinedEvent = new core_1.EventEmitter();
        this.cardVisible = true;
    }
    CardComponent.prototype.selectCard = function (cardIndex) {
        this.currentValue = this.values[cardIndex];
        this.updateCurrentCard();
    };
    CardComponent.prototype.selectSuit = function (suitId) {
        this.currentSuit = this.suits[suitId - 1];
        this.updateCurrentCard();
    };
    CardComponent.prototype.updateCurrentCard = function () {
        this.currentCard = this.currentValue.concat(this.currentSuit.abbreviation);
        this.isDefinedEvent.next(this.currentCard != null);
    };
    __decorate([
        core_1.Output(),
        __metadata("design:type", core_1.EventEmitter)
    ], CardComponent.prototype, "isDefinedEvent", void 0);
    CardComponent = __decorate([
        core_1.Component({
            selector: "card",
            inputs: ['cardVisible'],
            template: require("./card.component.html"),
            providers: [card_service_1.CardService]
        }),
        __metadata("design:paramtypes", [card_service_1.CardService])
    ], CardComponent);
    return CardComponent;
}());
exports.CardComponent = CardComponent;
//# sourceMappingURL=card.component.js.map