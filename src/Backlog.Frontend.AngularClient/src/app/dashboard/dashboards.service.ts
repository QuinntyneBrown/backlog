import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Dashboard } from "./dashboard.model";
import { Observable } from "rxjs/Observable";
import { constants } from "../shared/constants";

@Injectable()
export class DashboardsService {
    constructor(
        private _httpClient: HttpClient,
        @Inject(constants.BASE_URL) private _baseUrl:string
    ) { }

    public addOrUpdate(options: { dashboard: Partial<Dashboard>}) {
        return this._httpClient
            .post(`${this._baseUrl}/api/dashboards/add`, options);
    }

    public get(): Observable<{ dashboards: Array<Dashboard> }> {
        return this._httpClient
            .get<{ dashboards: Array<Dashboard> }>(`${this._baseUrl}/api/dashboards/get`);
    }

    public getDefault(): Observable<{ dashboard: Dashboard }> {
        return this._httpClient
            .get<{ dashboard: Dashboard }>(`${this._baseUrl}/api/dashboards/getDefault`);
    }

    public getById(options: { id: number }): Observable<{ dashboard:Dashboard}> {
        return this._httpClient
            .get<{dashboard: Dashboard}>(`${this._baseUrl}/api/dashboards/getById?id=${options.id}`);
    }

    public remove(options: { dashboard: Partial<Dashboard>}) {
        return this._httpClient
            .delete(`${this._baseUrl}/api/dashboards/remove?id=${options.dashboard.id}`);
    }    
}
