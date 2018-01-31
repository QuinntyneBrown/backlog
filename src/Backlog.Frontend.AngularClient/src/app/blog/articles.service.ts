import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Article } from "./article.model";
import { Observable } from "rxjs/Observable";
import { constants } from "../shared/constants";
import { catchError } from "rxjs/operators";

@Injectable()
export class ArticlesService {
    constructor(
        private _httpClient: HttpClient,
        @Inject(constants.BASE_URL) private _baseUrl:string)
    { }

    public addOrUpdate(options: { article: Partial<Article>}) {
        return this._httpClient
            .post(`${this._baseUrl}/api/articles/add`, options)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public get(): Observable<{ articles: Array<Partial<Article>> }> {
        return this._httpClient
            .get<{ articles: Array<Article> }>(`${this._baseUrl}/api/articles/get`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public getById(options: { id: number }): Observable<{ article:Partial<Article>}> {
        return this._httpClient
            .get<{article: Article}>(`${this._baseUrl}/api/articles/getById?id=${options.id}`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public remove(options: { article: Partial<Article>}) {
        return this._httpClient
            .delete(`${this._baseUrl}/api/articles/remove?id=${options.article.id}`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }
}
