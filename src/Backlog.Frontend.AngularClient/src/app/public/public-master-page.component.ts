import { Component } from "@angular/core";
import { Subject } from "rxjs/Subject";

@Component({
    templateUrl: "./public-master-page.component.html",
    styleUrls: ["./public-master-page.component.css"],
    selector: "ce-public-master-page"
})
export class PublicMasterPageComponent { 

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }
}
