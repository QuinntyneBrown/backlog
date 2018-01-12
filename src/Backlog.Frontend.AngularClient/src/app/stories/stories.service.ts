import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Story } from "./story.model";
import { Observable } from "rxjs/Observable";

@Injectable()
export class StoriesService {
    constructor(private _httpClient: HttpClient)
    { }

    public addOrUpdate(options: { story: Story, correlationId: string }) {
        return this._httpClient
            .post(`${this._baseUrl}/api/stories/add`, options);
    }

    public get(): Observable<{ stories: Array<Story> }> {
        //console.log(`${this._baseUrl}/api/stories/get`);

        return this._httpClient
            .get<{ stories: Array<Story> }>(`${this._baseUrl}/api/stories/get`);
    }

    public getById(options: { id: number }): Observable<{ story:Story}> {
        return this._httpClient
            .get<{ story: Story }>(`${this._baseUrl}/api/stories/getById?id=${options.id}`);
    }

    public remove(options: { story: Story }) {
        return this._httpClient
            .delete(`${this._baseUrl}/api/stories/remove?id=${options.story.id}`);
    }

    public get _baseUrl() { return ""; }
}
