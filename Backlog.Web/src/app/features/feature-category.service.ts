import { fetch } from "../utilities";
import { FeatureCategory } from "./feature-category.model";

export class FeatureCategoryService {
    
    private static _instance: FeatureCategoryService;

    public static get Instance() {
        this._instance = this._instance || new this();
        return this._instance;
    }

    public get() {
        return fetch({ url: "/api/feature-category/get", authRequired: true });
    }

    public getById(id) {
        return fetch({ url: `/api/feature-category/getbyid?id=${id}`, authRequired: true });
    }

    public add(entity) {
        return fetch({ url: `/api/feature-category/add`, method: "POST", data: entity, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return fetch({ url: `/api/feature-category/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
