import { Suit } from "./Suit";

export class Card {
    public suit: Suit;

    constructor(
        public name: string
        , public value: number) { }
}