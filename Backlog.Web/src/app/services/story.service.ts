import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Story } from "../models";
import { Observable } from "rxjs";
import { extractData } from "../utilities";

import { apiCofiguration } from "../configuration";


@Injectable()
export class StoryService {
    constructor(private _http: Http) { }

    public add(entity: Story) {
        return this._http
            .post(`${apiCofiguration.baseUrl}/api/story/add`, entity)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get() {
        return this._http
            .get(`${apiCofiguration.baseUrl}/api/story/get`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public getById(options: { id: number }) {
        return this._http
            .get(`${apiCofiguration.baseUrl}/api/story/getById?id=${options.id}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public remove(options: { id: number }) {
        return this._http
            .delete(`${apiCofiguration.baseUrl}/api/story/remove?id=${options.id}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get baseUrl() { return apiCofiguration.baseUrl; }

}
