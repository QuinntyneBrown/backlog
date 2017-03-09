import { fetch } from "../utilities";
import { Feature } from "./feature.model";

export class FeatureService {
    constructor(private _fetch = fetch) { }

    private static _instance: FeatureService;

    public static get Instance() {
        this._instance = this._instance || new FeatureService();
        return this._instance;
    }

    public get(): Promise<Array<Feature>> {
        return this._fetch({ url: "/api/feature/get", authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { features: Array<Feature> }).features;
        });
    }

    public getById(id): Promise<Feature> {
        return this._fetch({ url: `/api/feature/getbyid?id=${id}`, authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { feature: Feature }).feature;
        });
    }

    public add(feature) {
        return this._fetch({ url: `/api/feature/add`, method: "POST", data: { feature }, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return this._fetch({ url: `/api/feature/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
