import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Author } from "./author.model";
import { Observable } from "rxjs/Observable";
import { constants } from "../shared/constants";
import { catchError } from "rxjs/operators";

@Injectable()
export class AuthorsService {
    constructor(
        private _httpClient: HttpClient,
        @Inject(constants.BASE_URL) private _baseUrl:string)
    { }

    public addOrUpdate(options: { author: Partial<Author>}) {
        return this._httpClient
            .post(`${this._baseUrl}/api/authors/add`, options)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public get(): Observable<{ authors: Array<Partial<Author>> }> {
        return this._httpClient
            .get<{ authors: Array<Author> }>(`${this._baseUrl}/api/authors/get`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public getById(options: { id: number }): Observable<{ author:Partial<Author>}> {
        return this._httpClient
            .get<{author: Author}>(`${this._baseUrl}/api/authors/getById?id=${options.id}`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public remove(options: { author: Partial<Author>}) {
        return this._httpClient
            .delete(`${this._baseUrl}/api/authors/remove?id=${options.author.id}`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }
}
