import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { HomePage } from "./home-page.model";
import { constants } from "../shared/constants";

@Injectable()
export class ApiService {
    constructor(
        @Inject(constants.BASE_URL) private _baseUrl:string,
        private _client: HttpClient) {
    }

    public getHomePage() {
        return this._client.get <{ homePage: any }>(`${this._baseUrl}/api/homepages/get`);
    }
    
}
