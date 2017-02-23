import { fetch } from "../utilities";
import { Sprint } from "./sprint.model";

export class SprintService {
    
    private static _instance: SprintService;

    public static get Instance() {
        this._instance = this._instance || new this();
        return this._instance;
    }

    public get() {
        return fetch({ url: "/api/sprint/get", authRequired: true });
    }

    public getCurrent() {
        return fetch({ url: "/api/sprint/getcurrent", authRequired: true });
    }

    public getById(id) {
        return fetch({ url: `/api/sprint/getbyid?id=${id}`, authRequired: true });
    }

    public add(entity) {
        return fetch({ url: `/api/sprint/add`, method: "POST", data: entity, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return fetch({ url: `/api/sprint/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
