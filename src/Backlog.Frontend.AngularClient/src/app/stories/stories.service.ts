import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Story } from "./story.model";
import { Observable } from "rxjs/Observable";
import { constants } from "../shared/constants";

@Injectable()
export class StoriesService {
    constructor(
        private _httpClient: HttpClient,
        @Inject(constants.BASE_URL) private _baseUrl: string
    )
    { }

    public addOrUpdate(options: { story: Partial<Story> }) {
        return this._httpClient
            .post(`${this._baseUrl}/api/stories/add`, options);
    }

    public get(): Observable<{ stories: Array<Partial<Story>> }> {        
        return this._httpClient
            .get<{ stories: Array<Story> }>(`${this._baseUrl}/api/stories/get`);
    }

    public getById(options: { id: number }): Observable<{ story:Partial<Story>}> {
        return this._httpClient
            .get<{ story: Story }>(`${this._baseUrl}/api/stories/getById?id=${options.id}`);
    }

    public remove(options: { story: Partial<Story> }) {
        return this._httpClient
            .delete(`${this._baseUrl}/api/stories/remove?id=${options.story.id}`);
    }    
}
