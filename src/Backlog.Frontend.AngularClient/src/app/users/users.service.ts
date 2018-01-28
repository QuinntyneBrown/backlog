import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { User } from "./user.model";
import { Observable } from "rxjs/Observable";
import { constants } from "../shared/constants";

@Injectable()
export class UsersService {
    constructor(
        private _httpClient: HttpClient,
        @Inject(constants.BASE_URL) private _baseUrl: string)
    { }

    public addOrUpdate(options: { user: Partial<User>}) {
        return this._httpClient
            .post(`${this._baseUrl}/api/users/add`, options);
    }

    public get(): Observable<{ users: Array<Partial<User>> }> {
        return this._httpClient
            .get<{ users: Array<Partial<User>> }>(`${this._baseUrl}/api/users/get`);
    }

    public getById(options: { id: number }): Observable<{ user: Partial<User>}> {
        return this._httpClient
            .get<{ user: Partial<User>}>(`${this._baseUrl}/api/users/getById?id=${options.id}`);
    }

    public remove(options: { user: Partial<User>}) {
        return this._httpClient
            .delete(`${this._baseUrl}/api/users/remove?id=${options.user.id}`);
    }   
}
