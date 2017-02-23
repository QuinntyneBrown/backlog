import { fetch } from "../utilities";
import { Product } from "./product.model";

export class ProductService {
    
    private static _instance: ProductService;

    public static get Instance() {
        this._instance = this._instance || new ProductService();
        return this._instance;
    }

    public get() {
        return fetch({ url: "/api/product/get", authRequired: true });
    }

    public getById(id) {
        return fetch({ url: `/api/product/getbyid?id=${id}`, authRequired: true });
    }

    public add(entity) {
        return fetch({ url: `/api/product/add`, method: "POST", data: entity, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return fetch({ url: `/api/product/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
