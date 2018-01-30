import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Epic } from "./epic.model";
import { Observable } from "rxjs/Observable";
import { constants } from "../shared/constants";
import { catchError } from "rxjs/operators";

@Injectable()
export class EpicsService {
    constructor(
        private _httpClient: HttpClient,
        @Inject(constants.BASE_URL) private _baseUrl:string)
    { }

    public addOrUpdate(options: { epic: Partial<Epic>}) {
        return this._httpClient
            .post(`${this._baseUrl}/api/epics/add`, options)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public get(): Observable<{ epics: Array<Partial<Epic>> }> {
        return this._httpClient
            .get<{ epics: Array<Epic> }>(`${this._baseUrl}/api/epics/get`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public getById(options: { id: number }): Observable<{ epic:Partial<Epic>}> {
        return this._httpClient
            .get<{epic: Epic}>(`${this._baseUrl}/api/epics/getById?id=${options.id}`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public remove(options: { epic: Partial<Epic>}) {
        return this._httpClient
            .delete(`${this._baseUrl}/api/epics/remove?id=${options.epic.id}`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }
}
