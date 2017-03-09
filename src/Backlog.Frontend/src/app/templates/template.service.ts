import { fetch } from "../utilities";
import { TemplateModel } from "./template.model";

export class TemplateService {
    constructor(private _fetch = fetch) { }

    private static _instance: TemplateService;

    public static get Instance() {
        this._instance = this._instance || new TemplateService();
        return this._instance;
    }

    public get(): Promise<Array<TemplateModel>> {
        return this._fetch({ url: "/api/template/get", authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { templates: Array<TemplateModel> }).templates;
        });
    }

    public getById(id): Promise<TemplateModel> {
        return this._fetch({ url: `/api/template/getbyid?id=${id}`, authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { template: TemplateModel }).template;
        });
    }

    public add(template) {
        return this._fetch({ url: `/api/template/add`, method: "POST", data: { template }, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return this._fetch({ url: `/api/template/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
