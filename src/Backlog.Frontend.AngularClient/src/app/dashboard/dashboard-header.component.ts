import {
    Component,
    Input,
    OnInit,
    EventEmitter,
    Output,
    AfterViewInit,
    AfterContentInit,
    Renderer,
    ElementRef,
} from "@angular/core";

import { Dashboard } from "./dashboard.model";
import { DashboardsService } from "./dashboards.service";
import { Subject } from "rxjs";
import { dashboardEvents } from "./dashboard.events";
import { pluckOut } from "../shared/utilities/pluck-out";
import { Router } from "@angular/router";

@Component({
    templateUrl: "./dashboard-header.component.html",
    styleUrls: ["./dashboard-header.component.css"],
    selector: "ce-dashboard-header"
})
export class DashboardHeaderComponent {
    constructor(
        private _dashboardsService: DashboardsService,
        private _router: Router            
    ) {
        this.onDashboardRemoved = this.onDashboardRemoved.bind(this);
    }

    public ngOnInit() {
        this._dashboardsService
            .get()
            .takeUntil(this._ngUnsubscribe)
            .map(x => this.dashboards = x.dashboards)
            .subscribe();

        document.addEventListener(dashboardEvents.DASHBOARD_REMOVED, this.onDashboardRemoved);
    }

    public onDashboardRemoved($event) {        
        pluckOut({ items: this.dashboards, value: $event.detail.dashboard.id });
    }

    public tryToCreateDashboard() {
        this.createMode = true;
        this.currentDashboard = {};
    }

    public tryToSaveDashboard() {
        this.createMode = false;            
        this._dashboardsService
            .addOrUpdate({ dashboard: this.currentDashboard })
            .do(() => this.currentDashboard = null)
            .switchMap(() => this._dashboardsService.get())
            .map(x => this.dashboards = x.dashboards)
            .do(x => this._router.navigateByUrl(`/dashboard/${this.dashboards[this.dashboards.length - 1].id}`))
            .takeUntil(this._ngUnsubscribe)
            .subscribe();
    }

    public currentDashboard: Partial<Dashboard> = {};

    public dashboards: Array<Dashboard> = [];

    public createMode: boolean = false;

    private _ngUnsubscribe: Subject<void> = new Subject();

    public ngOnDestroy() {
        this._ngUnsubscribe.next();
    }
}