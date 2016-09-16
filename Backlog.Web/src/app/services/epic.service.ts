import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Epic } from "../models";
import { Observable } from "rxjs";
import { extractData } from "../utilities";

import { apiCofiguration } from "../configuration";


@Injectable()
export class EpicService {
    constructor(private _http: Http) { }

    public add(entity: Epic) {
        return this._http
            .post(`${apiCofiguration.baseUrl}/api/epic/add`, entity)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get() {
        return this._http
            .get(`${apiCofiguration.baseUrl}/api/epic/get`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public getById(options: { id: number }) {
        return this._http
            .get(`${apiCofiguration.baseUrl}/api/epic/getById?id=${options.id}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public remove(options: { id: number }) {
        return this._http
            .delete(`${apiCofiguration.baseUrl}/api/epic/remove?id=${options.id}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get baseUrl() { return apiCofiguration.baseUrl; }

}
