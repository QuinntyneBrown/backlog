import { Component } from "@angular/core";
import { Subject } from "rxjs/Subject";

@Component({
    templateUrl: "./page-not-found.component.html",
    styleUrls: [
        "./shared/components/page.css",
        "./page-not-found.component.css"
    ],
    selector: "ce-page-not-found"
})
export class PageNotFoundComponent { 

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }
}
