import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { HomePage } from "./home-page.model";
import { Observable } from "rxjs/Observable";
import { constants } from "../shared/constants";

@Injectable()
export class HomePagesService {
    constructor(
        private _httpClient: HttpClient,
        @Inject(constants.BASE_URL) private _baseUrl:string)
    { }

    public addOrUpdate(options: { homePage: Partial<HomePage>}) {
        return this._httpClient
            .post(`${this._baseUrl}/api/homePages/add`, options);
    }

    public get(): Observable<{ homePage: HomePage }> {
        return this._httpClient
            .get<{ homePage: HomePage }>(`${this._baseUrl}/api/homePages/get`);
    }

    public getById(options: { id: number }): Observable<{ homePage:Partial<HomePage>}> {
        return this._httpClient
            .get<{homePage: HomePage}>(`${this._baseUrl}/api/homePages/getById?id=${options.id}`);
    }

    public remove(options: { homePage: Partial<HomePage>}) {
        return this._httpClient
            .delete(`${this._baseUrl}/api/homePages/remove?id=${options.homePage.id}`);
    }
}
