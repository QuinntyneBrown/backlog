import { Component } from "@angular/core";
import { Subject } from "rxjs/Subject";

@Component({
    templateUrl: "./public-header.component.html",
    styleUrls: ["./public-header.component.css"],
    selector: "ce-public-header"
})
export class PublicHeaderComponent { 

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }
}
