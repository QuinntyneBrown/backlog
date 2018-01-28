import { Component } from "@angular/core";
import { Subject } from "rxjs/Subject";

@Component({
    templateUrl: "./dashboard-master-page.component.html",
    styleUrls: ["./dashboard-master-page.component.css"],
    selector: "ce-dashboard-master-page"
})
export class DashboardMasterPageComponent { 

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }
}
