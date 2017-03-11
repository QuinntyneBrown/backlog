import { fetch } from "../utilities";
import { Article } from "./article.model";

export class ArticleService {
    constructor(private _fetch = fetch) { }

    private static _instance: ArticleService;

    public static get Instance() {
        this._instance = this._instance || new this();
        return this._instance;
    }

    public get(): Promise<Array<Article>> {
        return this._fetch({ url: "/api/article/get", authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { articles: Array<Article> }).articles;
        });
    }

    public getById(id): Promise<Article> {
        return this._fetch({ url: `/api/article/getbyid?id=${id}`, authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { article: Article }).article;
        });
    }

    public getBySlug(slug): Promise<Article> {
        return this._fetch({ url: `/api/article/getbyslug?slug=${slug}`, authRequired: true }).then((results: string) => {
            return (JSON.parse(results) as { article: Article }).article;
        });
    }
    
    public add(article) {
        return this._fetch({ url: `/api/article/add`, method: "POST", data: { article }, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return this._fetch({ url: `/api/article/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
}