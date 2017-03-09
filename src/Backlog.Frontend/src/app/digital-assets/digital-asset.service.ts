import { fetch } from "../utilities";
import { DigitalAsset } from "./digital-asset.model";

export class DigitalAssetService {
    
    private static _instance: DigitalAssetService;

    public static get Instance() {
        this._instance = this._instance || new this();
        return this._instance;
    }

    public get() {
        return fetch({ url: "/api/digitalasset/get" });
    }

    public upload(options: {data: FormData}) {
        return fetch({
            url: "/api/digitalasset/upload",
            method: "POST",
            headers: {},
            authRequired: true,
            data: options.data,
            isObjectData: true
        })
    }

    public getById(id) {
        return fetch({ url: `/api/digitalasset/getbyid?id=${id}`, authRequired: true });
    }

    public add(digitalAsset) {
        return fetch({ url: `/api/digitalasset/add`, method: "POST", data: { digitalAsset }, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return fetch({ url: `/api/digitalasset/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }  
}