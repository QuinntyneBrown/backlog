import { Component } from "@angular/core";
import { Subject } from "rxjs/Subject";

@Component({
    templateUrl: "./header.component.html",
    styleUrls: ["./header.component.css"],
    selector: "ce-header"
})
export class HeaderComponent { 

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }
}
