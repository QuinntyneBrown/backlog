import { Component } from "@angular/core";
import { Subject } from "rxjs/Subject";
import { StoriesService } from "./stories.service";

@Component({
    templateUrl: "./story-list-page.component.html",
    styleUrls: [
        "../shared/page.css",
        "./story-list-page.component.css"
    ],
    selector: "ce-story-list-page"
})
export class StoryListPageComponent { 
    constructor(private _storiesService: StoriesService) {

    }

    public ngOnInit() {
        this._storiesService.get()
            //.takeUntil(this._ngUnsubscribe)
            .subscribe((data) => {

            });
    }
    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }
}
