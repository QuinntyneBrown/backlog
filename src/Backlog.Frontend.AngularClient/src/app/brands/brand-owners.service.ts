import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { BrandOwner } from "./brand-owner.model";
import { Observable } from "rxjs/Observable";
import { constants } from "../shared/constants";
import { catchError } from "rxjs/operators";

@Injectable()
export class BrandOwnersService {
    constructor(
        private _httpClient: HttpClient,
        @Inject(constants.BASE_URL) private _baseUrl:string)
    { }

    public addOrUpdate(options: { brandOwner: Partial<BrandOwner>}) {
        return this._httpClient
            .post(`${this._baseUrl}/api/brandowners/add`, options)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public get(): Observable<{ brandOwners: Array<Partial<BrandOwner>> }> {
        return this._httpClient
            .get<{ brandOwners: Array<BrandOwner> }>(`${this._baseUrl}/api/brandowners/get`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public getById(options: { id: number }): Observable<{ brandOwner:Partial<BrandOwner>}> {
        return this._httpClient
            .get<{ brandOwner: BrandOwner }>(`${this._baseUrl}/api/brandowners/getById?id=${options.id}`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public remove(options: { brandOwner: Partial<BrandOwner>}) {
        return this._httpClient
            .delete(`${this._baseUrl}/api/brandowners/remove?id=${options.brandOwner.id}`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }
}
