import { fetch } from "../utilities";
import { Brand } from "./brand.model";

export class BrandService {
    constructor(private _fetch = fetch) { }

    private static _instance: BrandService;

    public static get Instance() {
        this._instance = this._instance || new BrandService();
        return this._instance;
    }

    public get(): Promise<Array<Brand>> {
        return this._fetch({ url: "/api/brand/get", authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { brands: Array<Brand> }).brands;
        });
    }

    public getById(id): Promise<Brand> {
        return this._fetch({ url: `/api/brand/getbyid?id=${id}`, authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { brand: Brand }).brand;
        });
    }

    public add(brand) {
        return this._fetch({ url: `/api/brand/add`, method: "POST", data: { brand }, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return this._fetch({ url: `/api/brand/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
