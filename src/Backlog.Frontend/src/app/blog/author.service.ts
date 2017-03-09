import { fetch } from "../utilities";
import { Author } from "./author.model";

export class AuthorService {
    constructor(private _fetch = fetch) { }

    private static _instance: AuthorService;

    public static get Instance() {
        this._instance = this._instance || new AuthorService();
        return this._instance;
    }

    public get(): Promise<Array<Author>> {
        return this._fetch({ url: "/api/author/get", authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { authors: Array<Author> }).authors;
        });
    }

    public getById(id): Promise<Author> {
        return this._fetch({ url: `/api/author/getbyid?id=${id}`, authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { author: Author }).author;
        });
    }

    public add(author) {
        return this._fetch({ url: `/api/author/add`, method: "POST", data: { author }, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return this._fetch({ url: `/api/author/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
