import { Component } from "@angular/core";
import { Subject } from "rxjs/Subject";

@Component({
    templateUrl: "./author-item.component.html",
    styleUrls: ["./author-item.component.css"],
    selector: "ce-author-item"
})
export class AuthorItemComponent { 

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }
}
