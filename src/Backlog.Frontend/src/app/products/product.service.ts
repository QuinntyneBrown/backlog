import { fetch } from "../utilities";
import { Product } from "./product.model";

export class ProductService {
    constructor(private _fetch = fetch) { }

    private static _instance: ProductService;

    public static get Instance() {
        this._instance = this._instance || new ProductService();
        return this._instance;
    }

    public get(): Promise<Array<Product>> {
        return this._fetch({ url: "/api/product/get", authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { products: Array<Product> }).products;
        });
    }

    public getById(id): Promise<Product> {
        return this._fetch({ url: `/api/product/getbyid?id=${id}`, authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { product: Product }).product;
        });
    }

    public add(product) {
        return this._fetch({ url: `/api/product/add`, method: "POST", data: { product }, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return this._fetch({ url: `/api/product/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
