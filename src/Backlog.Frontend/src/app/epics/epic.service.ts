import { fetch } from "../utilities";
import { Epic } from "./epic.model";

export class EpicService {
    constructor(private _fetch = fetch) { }

    private static _instance: EpicService;

    public static get Instance() {
        this._instance = this._instance || new EpicService();
        return this._instance;
    }

    public get(): Promise<Array<Epic>> {
        return this._fetch({ url: "/api/epic/get", authRequired: true }).then((results: string) => {
            return (JSON.parse(results) as { epics: Array<Epic> }).epics;
        });
    }

    public getById(id): Promise<Epic> {
        return this._fetch({ url: `/api/epic/getbyid?id=${id}`, authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { epic: Epic }).epic;
        });
    }

    public add(epic) {
        return this._fetch({ url: `/api/epic/add`, method: "POST", data: { epic }, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return this._fetch({ url: `/api/epic/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
