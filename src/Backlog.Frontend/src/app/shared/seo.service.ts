import { Title } from "./title.service";

export class SeoService {
    constructor(private _title: Title = Title.Instance) {

    }
    
    private static _instance;

    public static get Instance() {
        this._instance = this._instance || new this();
        return this._instance;
    }

    public getTitle(): string {
        throw new DOMException();
    }
    public setTitle(newTitle: string, baseTitle = false) {
        throw new DOMException();
    }

    public setMetaRobots(robots: string) {
        throw new DOMException();
    }

    private getOrCreateMetaElement(name: string): HTMLElement {
        throw new DOMException();
    }
}