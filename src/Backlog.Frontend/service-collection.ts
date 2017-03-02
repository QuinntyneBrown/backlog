import { EpicService } from "./src/app/epics";

export class ServiceCollection extends Array<any> {
    constructor() {
        super();

        this.addRange([
            EpicService
        ]);
    }

    private addRange = (values: any[]) => values.map(value => this.push(value));
}