import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { StoriesService } from "./stories.service";
import { Story } from "./story.model";

@Component({
    templateUrl: "./story-edit-page.component.html",
    styleUrls: ["./story-edit-page.component.css"],
    selector: "ce-story-edit-page"
})
export class StoryEditPageComponent {
    constructor(
        private _storiesService: StoriesService
    ) { }

    public async ngOnInit() {

    }

    public tryToSave($event) {

    }

    public story:Partial<Story> = {};
}
