import { fetch } from "../utilities";
import { Category } from "./category.model";

export class CategoryService {
    constructor(private _fetch = fetch) { }

    private static _instance: CategoryService;

    public static get Instance() {
        this._instance = this._instance || new CategoryService();
        return this._instance;
    }

    public get(): Promise<Array<Category>> {
        return this._fetch({ url: "/api/category/get", authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { categorys: Array<Category> }).categorys;
        });
    }

    public getById(id): Promise<Category> {
        return this._fetch({ url: `/api/category/getbyid?id=${id}`, authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { category: Category }).category;
        });
    }

    public add(category) {
        return this._fetch({ url: `/api/category/add`, method: "POST", data: { category }, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return this._fetch({ url: `/api/category/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
