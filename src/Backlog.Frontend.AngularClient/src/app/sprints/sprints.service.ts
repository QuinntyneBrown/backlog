import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Sprint } from "./sprint.model";
import { Observable } from "rxjs/Observable";
import { constants } from "../shared/constants";
import { catchError } from "rxjs/operators";

@Injectable()
export class SprintsService {
    constructor(
        private _httpClient: HttpClient,
        @Inject(constants.BASE_URL) private _baseUrl:string)
    { }

    public addOrUpdate(options: { sprint: Partial<Sprint>}) {
        return this._httpClient
            .post(`${this._baseUrl}/api/sprints/add`, options)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public get(): Observable<{ sprints: Array<Partial<Sprint>> }> {
        return this._httpClient
            .get<{ sprints: Array<Sprint> }>(`${this._baseUrl}/api/sprints/get`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public getById(options: { id: number }): Observable<{ sprint:Partial<Sprint>}> {
        return this._httpClient
            .get<{sprint: Sprint}>(`${this._baseUrl}/api/sprints/getById?id=${options.id}`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }

    public remove(options: { sprint: Partial<Sprint>}) {
        return this._httpClient
            .delete(`${this._baseUrl}/api/sprints/remove?id=${options.sprint.id}`)
            .pipe(
                catchError((error) => Observable.throw(error.json()))
            );
    }
}
