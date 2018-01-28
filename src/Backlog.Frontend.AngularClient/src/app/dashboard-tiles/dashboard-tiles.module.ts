import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { DashboardTilesService } from "./dashboard-tiles.service";
import { DashboardTileElementFactory } from "./dashboard-tile-element-factory";
import { DigitalAssetsDashboardTileComponent } from "./digital-assets-dashboard-tile.component";
import { HomePageDashboardTileComponent } from "./home-page-dashboard-tile.component";

const customElements:Array<any> = [
    DigitalAssetsDashboardTileComponent,
    HomePageDashboardTileComponent
];

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