import { Tile } from "../tiles/tile.model";

export type DashboardTile = { 
    id:any;
    tileId: any;
    dashboardId: any;
    name: string;
    top: number;
    left: number;
    width: number;
    height: number;
    tile: Tile;
}
