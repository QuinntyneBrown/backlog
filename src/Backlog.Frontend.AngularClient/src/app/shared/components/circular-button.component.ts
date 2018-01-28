import { Component } from "@angular/core";
import { Subject } from "rxjs/Subject";

@Component({
    templateUrl: "./circular-button.component.html",
    styleUrls: ["./circular-button.component.css"],
    selector: "ce-circular-button"
})
export class CircularButtonComponent { 

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }
}
