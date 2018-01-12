import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs/Observable";

@Injectable()
export class TenantsService {
    constructor(private _httpClient: HttpClient)
    {

    }

    public set(options: { uniqueId: string }) {
        return this._httpClient
            .post(`${this._baseUrl}/api/tenants/set`, options);
    }

    public get _baseUrl() { return window["__BASE_URL__"]; }
}
