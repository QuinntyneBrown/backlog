import { fetch } from "../utilities";
import { Feature } from "./feature.model";

export class FeatureService {
    
    private static _instance: FeatureService;

    public static get Instance() {
        this._instance = this._instance || new this();
        return this._instance;
    }

    public get() {
        return fetch({ url: "/api/feature/get", authRequired: true  });
    }

    public getById(id) {
        return fetch({ url: `/api/feature/getbyid?id=${id}`, authRequired: true });
    }

    public add(feature) {
        return fetch({ url: `/api/feature/add`, method: "POST", data: { feature }, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return fetch({ url: `/api/feature/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
