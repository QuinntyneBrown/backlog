import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { DashboardTilesService } from "./dashboard-tiles.service";
import { DashboardTileElementFactory } from "./dashboard-tile-element-factory";

import "./digital-assets-dashboard-tile.component";
import "./home-page-dashboard-tile.component";
import "./dashboard-tile-header.component";
import "./dashboard-tile-menu.component";
import "./configure-dashboard-tile-modal.component";
import "./products-dashboard-tile.component";

const declarations = [

];

@NgModule({
    imports: [
        CommonModule,
        HttpClientModule
    ],
    providers: [
        DashboardTilesService,
        DashboardTileElementFactory
    ],
    declarations,
    exports: declarations
})
export class DashboardTilesModule {

}