import { Component } from "@angular/core";
import { Subject } from "rxjs/Subject";

@Component({
    templateUrl: "./story.component.html",
    styleUrls: ["./story.component.css"],
    selector: "ce-story"
})
export class StoryComponent { 

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }
}
