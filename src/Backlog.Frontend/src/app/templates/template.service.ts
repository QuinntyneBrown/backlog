import { fetch } from "../utilities";
import { TemplateModel } from "./template.model";

export class TemplateService {
    
    private static _instance: TemplateService;

    public static get Instance() {
        this._instance = this._instance || new this();
        return this._instance;
    }

    public get() {
        return fetch({ url: "/api/template/get" });
    }

    public getById(id) {
        return fetch({ url: `/api/template/getbyid?id=${id}`, authRequired: true });
    }

    public add(template) {
        return fetch({ url: `/api/template/add`, method: "POST", data: { template }, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return fetch({ url: `/api/template/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}