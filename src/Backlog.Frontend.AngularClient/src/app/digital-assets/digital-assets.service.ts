import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { DigitalAsset } from "./digital-asset.model";
import { Observable } from "rxjs/Observable";
import { constants } from "../shared/constants";

@Injectable()
export class DigitalAssetsService {
    constructor(
        private _httpClient: HttpClient,
        @Inject(constants.BASE_URL) private _baseUrl:string)
    { }

    public addOrUpdate(options: { digitalAsset: Partial<DigitalAsset>}) {
        return this._httpClient
            .post(`${this._baseUrl}/api/digitalassets/add`, options);
    }

    public upload(options: { data: any }) {
        return this._httpClient
            .post <{ digitalAssets: Array<any> }>(`${this._baseUrl}/api/digitalassets/upload`, options.data);
    }

    public get(): Observable<{ digitalAssets: Array<Partial<DigitalAsset>> }> {
        return this._httpClient
            .get<{ digitalAssets: Array<DigitalAsset> }>(`${this._baseUrl}/api/digitalassets/get`);
    }

    public getById(options: { id: number }): Observable<{ digitalAsset:Partial<DigitalAsset>}> {
        return this._httpClient
            .get<{digitalAsset: DigitalAsset}>(`${this._baseUrl}/api/digitalassets/getById?id=${options.id}`);
    }

    public remove(options: { digitalAsset: Partial<DigitalAsset>}) {
        return this._httpClient
            .delete(`${this._baseUrl}/api/digitalassets/remove?id=${options.digitalAsset.id}`);
    }
}
