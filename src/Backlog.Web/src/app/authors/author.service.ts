import { fetch } from "../utilities";
import { Author } from "./author.model";

export class AuthorService {
    
    private static _instance: AuthorService;

    public static get Instance() {
        this._instance = this._instance || new AuthorService();
        return this._instance;
    }

    public get() {
        return fetch({ url: "/api/author/get" });
    }

    public getById(id) {
        return fetch({ url: `/api/author/getbyid?id=${id}`, authRequired: true });
    }

    public add(entity) {
        return fetch({ url: `/api/author/add`, method: "POST", data: entity, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return fetch({ url: `/api/author/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
