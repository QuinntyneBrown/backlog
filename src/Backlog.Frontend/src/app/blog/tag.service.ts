import { fetch } from "../utilities";
import { Tag } from "./tag.model";

export class TagService {
    constructor(private _fetch = fetch) { }

    private static _instance: TagService;

    public static get Instance() {
        this._instance = this._instance || new TagService();
        return this._instance;
    }

    public get(): Promise<Array<Tag>> {
        return this._fetch({ url: "/api/tag/get", authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { tags: Array<Tag> }).tags;
        });
    }

    public getById(id): Promise<Tag> {
        return this._fetch({ url: `/api/tag/getbyid?id=${id}`, authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { tag: Tag }).tag;
        });
    }

    public add(tag) {
        return this._fetch({ url: `/api/tag/add`, method: "POST", data: { tag }, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return this._fetch({ url: `/api/tag/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
