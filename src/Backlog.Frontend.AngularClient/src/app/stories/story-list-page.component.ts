import { Component } from "@angular/core";
import { Subject } from "rxjs/Subject";
import { StoriesService } from "./stories.service";
import { Router } from "@angular/router";
import { pluckOut } from "../shared/utilities/pluck-out";

@Component({
    templateUrl: "./story-list-page.component.html",
    styleUrls: [
        "../shared/components/page.css",
        "./story-list-page.component.css"
    ],
    selector: "ce-story-list-page"
})
export class StoryListPageComponent { 
    constructor(
        private _router: Router,
        private _storiesService: StoriesService) {

    }

    public handleEditClick($event) {        
        this._router.navigateByUrl(`/stories/edit/${$event.story.id}`);
    }

    public handleDeleteClick($event) {
        this._storiesService.remove({ story: $event.story })
            .takeUntil(this._ngUnsubscribe)
            .subscribe();

        pluckOut({ items: this.stories, value: $event.story.id });
    }

    public ngOnInit() {
        this._storiesService.get()
            .takeUntil(this._ngUnsubscribe)
            .subscribe((data) => {
                this.stories = data.stories;
            });
    }
    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }

    public stories: Array<any> = [];
}
