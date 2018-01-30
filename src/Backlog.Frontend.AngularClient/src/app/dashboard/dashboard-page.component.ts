import { Component, ElementRef } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { DashboardsService } from "./dashboards.service";
import { Dashboard } from "./dashboard.model";
import { FormControl } from "@angular/forms";
import { Subject } from "rxjs/Subject";
import { dashboardEvents } from "./dashboard.events";
import { ModalService } from "../shared/services/modal.service";
import { tilesEvents } from "../tiles/tiles.events";
import { DashboardTilesService } from "../dashboard-tiles/dashboard-tiles.service";
import { Observable } from "rxjs";
import { forkJoin } from "rxjs/observable/forkJoin";
import { Tile } from "../tiles/tile.model";
import { DashboardTileElementFactory } from "../dashboard-tiles/dashboard-tile-element-factory";
import { constants } from "../dashboard-tiles/constants";

@Component({
    templateUrl: "./dashboard-page.component.html",
    styleUrls: ["./dashboard-page.component.css"],
    selector: "ce-dashboard-page"
})
export class DashboardPageComponent { 
    constructor(
        private _activatedRoute: ActivatedRoute,
        private _dashboardsService: DashboardsService,
        private _dashboardTileElementFactory: DashboardTileElementFactory,
        private _dashboardTilesService: DashboardTilesService,
        private _elementRef: ElementRef,
        private _router: Router,
        private _modalService: ModalService
    ) {
        this.handleTilesSelected = this.handleTilesSelected.bind(this);
        this.navigateByUrl = this.navigateByUrl.bind(this);
    }
    public navigateByUrl($event) {
        this._router.navigateByUrl($event.detail.url);
    }

    ngAfterViewInit() {        
        document.addEventListener(tilesEvents.TILES_SELECTED, this.handleTilesSelected);
        this._elementRef.nativeElement.addEventListener(constants.NAVIGATE_BY_URL, this.navigateByUrl);

        this._activatedRoute.params
            .takeUntil(this._ngUnsubscribe)
            .switchMap(params => {
                return params["id"]
                    ? this._dashboardsService.getById({ id: params["id"] })
                    : this._dashboardsService.getDefault();
            })
            .map(x => { this.dashboard = x.dashboard || {} })
            .do(() => {
                while (this.sectioHTMLElement.firstChild)
                    this.sectioHTMLElement.removeChild(this.sectioHTMLElement.firstChild);

                this.dashboard.dashboardTiles.forEach((dashboardTile) => {
                    let el = this._dashboardTileElementFactory.create({ dashboardTile });
                    el.setAttribute("dashboard-tile", JSON.stringify(dashboardTile));
                    this.sectioHTMLElement.appendChild(el);
                });
            })
            .subscribe();        
    }

    public get sectioHTMLElement() { return this._elementRef.nativeElement.querySelector("section") as HTMLElement; }

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    public ngOnDestroy() {
        document.removeEventListener(tilesEvents.TILES_SELECTED, this.handleTilesSelected);
        this._elementRef.nativeElement.removeEventListener(constants.NAVIGATE_BY_URL, this.navigateByUrl);
        this._ngUnsubscribe.next();	
    }

    public handleTilesSelected($event) {          
        const observables = Array.from($event.detail.tiles,(x:any) => this._dashboardTilesService
            .addOrUpdate({ dashboardTile: { tileId: x.tileId, dashboardId: this.dashboard.id } }));

        forkJoin(observables)
            .takeUntil(this._ngUnsubscribe)
            .switchMap(() => this.dashboard.id
                ? this._dashboardsService.getById({ id: this.dashboard.id })
                : this._dashboardsService.getDefault())
            .map((x) => this.dashboard = x.dashboard)
            .do(() => {
                while (this.sectioHTMLElement.firstChild)
                    this.sectioHTMLElement.removeChild(this.sectioHTMLElement.firstChild);

                this.dashboard.dashboardTiles.forEach((dashboardTile) => {
                    let el = this._dashboardTileElementFactory.create({ dashboardTile });
                    el.setAttribute("dashboard-tile", JSON.stringify(dashboardTile));
                    this.sectioHTMLElement.appendChild(el);
                });
            })
            .subscribe();
    }

    public tryToDeleteDashboard() {
        this._dashboardsService
            .remove({ dashboard: this.dashboard })
            .takeUntil(this._ngUnsubscribe)
            .do(() => document.dispatchEvent(new CustomEvent(dashboardEvents.DASHBOARD_REMOVED, {
                bubbles: true,
                cancelable: true,
                scoped: true,
                detail: { dashboard: this.dashboard }                
            })))
            .do(() => this._router.navigateByUrl("/dashboard"))
            .subscribe();
    }

    public handleOpenTileSelectionModalButtonClick($event) {
        this._modalService.open({ html: "<ce-tile-selection-modal></ce-tile-selection-modal>" });
    }

    public dashboard: Partial<Dashboard> = {};
}