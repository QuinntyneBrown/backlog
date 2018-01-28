import { Injectable } from "@angular/core";
import { DashboardTile } from "./dashboard-tile.model";
import { tileTypes } from "../tiles/constants";
import { HomePageDashboardTileComponent } from "./home-page-dashboard-tile.component";
import { DigitalAssetsDashboardTileComponent } from "./digital-assets-dashboard-tile.component";

@Injectable()
export class DashboardTileElementFactory {    
    public create(options: { dashboardTile: Partial<DashboardTile> }): HTMLElement {        
        switch (options.dashboardTile.tile.name) {
            case "Home Page":
                return new HomePageDashboardTileComponent() as HTMLElement;

            case "Digital Assets":
                return new DigitalAssetsDashboardTileComponent() as HTMLElement;

            default:
                throw new Error("Not Implemented!");
        }        
    }
}