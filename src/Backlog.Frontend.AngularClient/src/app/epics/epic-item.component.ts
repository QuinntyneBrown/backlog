import { Component } from "@angular/core";
import { Subject } from "rxjs/Subject";

@Component({
    templateUrl: "./epic-item.component.html",
    styleUrls: ["./epic-item.component.css"],
    selector: "ce-epic-item"
})
export class EpicItemComponent { 

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }
}
