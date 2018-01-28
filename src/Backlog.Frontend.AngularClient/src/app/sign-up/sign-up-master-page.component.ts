import { Component } from "@angular/core";
import { Subject } from "rxjs/Subject";

@Component({
    templateUrl: "./sign-up-master-page.component.html",
    styleUrls: ["./sign-up-master-page.component.css"],
    selector: "ce-sign-up-master-page"
})
export class SignUpMasterPageComponent { 

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }
}
