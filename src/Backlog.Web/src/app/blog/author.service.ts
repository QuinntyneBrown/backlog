import { fetch } from "../utilities";
import { Author } from "./author.model";

export class AuthorService {
    
    private static _instance: AuthorService;

    public static get Instance() {
        this._instance = this._instance || new AuthorService();
        return this._instance;
    }

    public get() {
        return fetch({ url: "/api/author/get", authRequired: true });
    }

    public getById(id) {
        return fetch({ url: `/api/author/getbyid?id=${id}`, authRequired: true });
    }

    public add(author) {
        return fetch({ url: `/api/author/add`, method: "POST", data: { author }, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return fetch({ url: `/api/author/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
