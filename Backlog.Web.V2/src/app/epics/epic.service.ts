import { environment } from "../environment";
import { fetch } from "../utilities";
import { Epic } from "./epic.model";

export class EpicService {
    
    private static _instance: EpicService;

    public static get Instance() {
        this._instance = this._instance || new EpicService();
        return this._instance;
    }

    public get() {
        return fetch({ url: `${this._baseUrl}/api/epic/get`, authRequired: true });
    }

    public getById(id) {
        return fetch({ url: `${this._baseUrl}/api/epic/getbyid?id=${id}`, authRequired: true });
    }

    public add(entity) {
        return fetch({ url: `${this._baseUrl}/api/epic/add`, method: "POST", data: entity, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return fetch({ url: `${this._baseUrl}/api/epic/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }

    // private get _baseUrl() { return environment.baseUrl; }

    private get _baseUrl() { return ""; }
    
}
