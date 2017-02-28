import { fetch } from "../utilities";
import { Article } from "./article.model";

export class ArticleService {
    
    private static _instance: ArticleService;

    public static get Instance() {
        this._instance = this._instance || new ArticleService();
        return this._instance;
    }

    public get() {
        return fetch({ url: "/api/article/get", authRequired: true });
    }

    public getById(id) {
        return fetch({ url: `/api/article/getbyid?id=${id}`, authRequired: true });
    }

    public add(article) {
        return fetch({ url: `/api/article/add`, method: "POST", data: { article }, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return fetch({ url: `/api/article/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
