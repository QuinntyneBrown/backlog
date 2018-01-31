import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Category } from "./category.model";
import { Observable } from "rxjs/Observable";
import { constants } from "../shared/constants";
import { catchError } from "rxjs/operators";

@Injectable()
export class CategoriesService {
    constructor(
        private _httpClient: HttpClient,
        @Inject(constants.BASE_URL) private _baseUrl:string)
    { }

    public addOrUpdate(options: { category: Partial<Category>}) {
        return this._httpClient
            .post(`${this._baseUrl}/api/categories/add`, options)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public get(): Observable<{ categories: Array<Partial<Category>> }> {
        return this._httpClient
            .get<{ categories: Array<Category> }>(`${this._baseUrl}/api/categories/get`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public getById(options: { id: number }): Observable<{ category:Partial<Category>}> {
        return this._httpClient
            .get<{ category: Category }>(`${this._baseUrl}/api/categories/getById?id=${options.id}`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public remove(options: { category: Partial<Category>}) {
        return this._httpClient
            .delete(`${this._baseUrl}/api/categories/remove?id=${options.category.id}`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }
}
