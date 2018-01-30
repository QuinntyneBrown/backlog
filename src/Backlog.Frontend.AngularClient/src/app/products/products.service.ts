import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Product } from "./product.model";
import { Observable } from "rxjs/Observable";
import { constants } from "../shared/constants";
import { catchError } from "rxjs/operators";

@Injectable()
export class ProductsService {
    constructor(
        private _httpClient: HttpClient,
        @Inject(constants.BASE_URL) private _baseUrl:string)
    { }

    public addOrUpdate(options: { product: Partial<Product>}) {
        return this._httpClient
            .post(`${this._baseUrl}/api/products/add`, options)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public get(): Observable<{ products: Array<Partial<Product>> }> {
        return this._httpClient
            .get<{ products: Array<Product> }>(`${this._baseUrl}/api/products/get`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public getById(options: { id: number }): Observable<{ product:Partial<Product>}> {
        return this._httpClient
            .get<{product: Product}>(`${this._baseUrl}/api/products/getById?id=${options.id}`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public remove(options: { product: Partial<Product>}) {
        return this._httpClient
            .delete(`${this._baseUrl}/api/products/remove?id=${options.product.id}`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }
}
