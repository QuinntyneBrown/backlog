import { fetch } from "../utilities";
import { FeatureCategory } from "./feature-category.model";

export class FeatureCategoryService {
    constructor(private _fetch = fetch) { }

    private static _instance: FeatureCategoryService;

    public static get Instance() {
        this._instance = this._instance || new FeatureCategoryService();
        return this._instance;
    }

    public get(): Promise<Array<FeatureCategory>> {
        return this._fetch({ url: "/api/featurecategory/get", authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { featureCategorys: Array<FeatureCategory> }).featureCategorys;
        });
    }

    public getById(id): Promise<FeatureCategory> {
        return this._fetch({ url: `/api/featurecategory/getbyid?id=${id}`, authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { featureCategory: FeatureCategory }).featureCategory;
        });
    }

    public add(featureCategory) {
        return this._fetch({ url: `/api/featurecategory/add`, method: "POST", data: { featureCategory }, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return this._fetch({ url: `/api/featurecategory/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
}