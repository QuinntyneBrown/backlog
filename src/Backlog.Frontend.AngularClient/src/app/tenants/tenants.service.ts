import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs/Observable";
import { constants } from "../shared/constants";

@Injectable()
export class TenantsService {
    constructor(
        private _httpClient: HttpClient,
        @Inject(constants.BASE_URL) private _baseUrl:string
    ) { }

    public verify(options: { uniqueId: string }) {
        return this._httpClient
            .post(`${this._baseUrl}/api/tenants/verify`, options);
    }
}
