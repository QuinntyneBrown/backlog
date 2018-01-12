import { Component } from "@angular/core";
import { Subject } from "rxjs/Subject";

@Component({
    templateUrl: "./app-shell.component.html",
    styleUrls: ["./app-shell.component.css"],
    selector: "ce-app-shell"
})
export class AppShellComponent { 

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }
}
