export class Alert {

    save = false;
    message: string;

    constructor(s: boolean, m: string) {
        this.save = s;
        this.message = m;
    }
}
