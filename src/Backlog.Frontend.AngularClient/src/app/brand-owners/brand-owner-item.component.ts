import { Component } from "@angular/core";
import { Subject } from "rxjs/Subject";

@Component({
    templateUrl: "./brand-owner-item.component.html",
    styleUrls: ["./brand-owner-item.component.css"],
    selector: "ce-brand-owner-item"
})
export class BrandOwnerItemComponent { 

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }
}
