import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { DashboardTile } from "./dashboard-tile.model";
import { Observable } from "rxjs/Observable";
import { constants } from "../shared/constants";

@Injectable()
export class DashboardTilesService {
    constructor(
        private _httpClient: HttpClient,
        @Inject(constants.BASE_URL) private _baseUrl:string)
    { }

    public addOrUpdate(options: { dashboardTile: Partial<DashboardTile>}) {
        return this._httpClient
            .post(`${this._baseUrl}/api/dashboardTiles/add`, options);
    }

    public get(): Observable<{ dashboardTiles: Array<Partial<DashboardTile>> }> {
        return this._httpClient
            .get<{ dashboardTiles: Array<DashboardTile> }>(`${this._baseUrl}/api/dashboardTiles/get`);
    }

    public getById(options: { id: number }): Observable<{ dashboardTile:Partial<DashboardTile>}> {
        return this._httpClient
            .get<{dashboardTile: DashboardTile}>(`${this._baseUrl}/api/dashboardTiles/getById?id=${options.id}`);
    }

    public remove(options: { dashboardTile: Partial<DashboardTile>}) {
        return this._httpClient
            .delete(`${this._baseUrl}/api/dashboardTiles/remove?id=${options.dashboardTile.id}`);
    }
}
