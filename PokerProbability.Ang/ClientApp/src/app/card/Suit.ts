export class Suit implements ISuit {
    public abbreviation: string;

    constructor(public id: number, public icon: string, public name: string) {
        this.abbreviation = name.charAt(0);
    }
}