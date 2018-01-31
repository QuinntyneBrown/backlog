import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Brand } from "./brand.model";
import { Observable } from "rxjs/Observable";
import { constants } from "../shared/constants";
import { catchError } from "rxjs/operators";

@Injectable()
export class BrandsService {
    constructor(
        private _httpClient: HttpClient,
        @Inject(constants.BASE_URL) private _baseUrl:string)
    { }

    public addOrUpdate(options: { brand: Partial<Brand>}) {
        return this._httpClient
            .post(`${this._baseUrl}/api/brands/add`, options)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public get(): Observable<{ brands: Array<Partial<Brand>> }> {
        return this._httpClient
            .get<{ brands: Array<Brand> }>(`${this._baseUrl}/api/brands/get`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public getById(options: { id: number }): Observable<{ brand:Partial<Brand>}> {
        return this._httpClient
            .get<{brand: Brand}>(`${this._baseUrl}/api/brands/getById?id=${options.id}`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public remove(options: { brand: Partial<Brand>}) {
        return this._httpClient
            .delete(`${this._baseUrl}/api/brands/remove?id=${options.brand.id}`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }
}
