import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Tile } from "./tile.model";
import { Observable } from "rxjs/Observable";
import { constants } from "../shared/constants";

@Injectable()
export class TilesService {
    constructor(
        private _httpClient: HttpClient,
        @Inject(constants.BASE_URL) private _baseUrl:string)
    { }

    public addOrUpdate(options: { tile: Partial<Tile>}) {
        return this._httpClient
            .post(`${this._baseUrl}/api/tiles/add`, options);
    }

    public get(): Observable<{ tiles: Array<Partial<Tile>> }> {
        return this._httpClient
            .get<{ tiles: Array<Tile> }>(`${this._baseUrl}/api/tiles/get`);
    }

    public getById(options: { id: number }): Observable<{ tile:Partial<Tile>}> {
        return this._httpClient
            .get<{tile: Tile}>(`${this._baseUrl}/api/tiles/getById?id=${options.id}`);
    }

    public remove(options: { tile: Partial<Tile>}) {
        return this._httpClient
            .delete(`${this._baseUrl}/api/tiles/remove?id=${options.tile.id}`);
    }
}
