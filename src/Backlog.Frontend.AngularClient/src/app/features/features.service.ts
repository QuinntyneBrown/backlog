import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Feature } from "./feature.model";
import { Observable } from "rxjs/Observable";
import { constants } from "../shared/constants";
import { catchError } from "rxjs/operators";

@Injectable()
export class FeaturesService {
    constructor(
        private _httpClient: HttpClient,
        @Inject(constants.BASE_URL) private _baseUrl:string)
    { }

    public addOrUpdate(options: { feature: Partial<Feature>}) {
        return this._httpClient
            .post(`${this._baseUrl}/api/features/add`, options)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public get(): Observable<{ features: Array<Partial<Feature>> }> {
        return this._httpClient
            .get<{ features: Array<Feature> }>(`${this._baseUrl}/api/features/get`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public getById(options: { id: number }): Observable<{ feature:Partial<Feature>}> {
        return this._httpClient
            .get<{feature: Feature}>(`${this._baseUrl}/api/features/getById?id=${options.id}`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public remove(options: { feature: Partial<Feature>}) {
        return this._httpClient
            .delete(`${this._baseUrl}/api/features/remove?id=${options.feature.id}`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }
}
