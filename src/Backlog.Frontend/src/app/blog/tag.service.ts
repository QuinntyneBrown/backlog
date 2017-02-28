import { fetch } from "../utilities";
import { Tag } from "./tag.model";

export class TagService {
    
    private static _instance: TagService;

    public static get Instance() {
        this._instance = this._instance || new TagService();
        return this._instance;
    }

    public get() {
        return fetch({ url: "/api/tag/get", authRequired: true });
    }

    public getById(id) {
        return fetch({ url: `/api/tag/getbyid?id=${id}`, authRequired: true });
    }

    public add(tag) {
        return fetch({ url: `/api/tag/add`, method: "POST", data: { tag }, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return fetch({ url: `/api/tag/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
