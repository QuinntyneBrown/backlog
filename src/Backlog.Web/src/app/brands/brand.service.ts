import { fetch } from "../utilities";
import { Brand } from "./brand.model";

export class BrandService {
    
    private static _instance: BrandService;

    public static get Instance() {
        this._instance = this._instance || new BrandService();
        return this._instance;
    }

    public get() {
        return fetch({ url: "/api/brand/get", authRequired: true });
    }

    public getById(id) {
        return fetch({ url: `/api/brand/getbyid?id=${id}`, authRequired: true });
    }

    public add(brand) {
        return fetch({ url: `/api/brand/add`, method: "POST", data: { brand }, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return fetch({ url: `/api/brand/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
