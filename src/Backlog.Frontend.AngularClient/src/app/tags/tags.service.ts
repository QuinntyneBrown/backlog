import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Tag } from "./tag.model";
import { Observable } from "rxjs/Observable";
import { constants } from "../shared/constants";
import { catchError } from "rxjs/operators";

@Injectable()
export class TagsService {
    constructor(
        private _httpClient: HttpClient,
        @Inject(constants.BASE_URL) private _baseUrl:string)
    { }

    public addOrUpdate(options: { tag: Partial<Tag>}) {
        return this._httpClient
            .post(`${this._baseUrl}/api/tags/add`, options)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public get(): Observable<{ tags: Array<Partial<Tag>> }> {
        return this._httpClient
            .get<{ tags: Array<Tag> }>(`${this._baseUrl}/api/tags/get`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public getById(options: { id: number }): Observable<{ tag:Partial<Tag>}> {
        return this._httpClient
            .get<{tag: Tag}>(`${this._baseUrl}/api/tags/getById?id=${options.id}`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public remove(options: { tag: Partial<Tag>}) {
        return this._httpClient
            .delete(`${this._baseUrl}/api/tags/remove?id=${options.tag.id}`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }
}
