import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { StoriesService } from "./stories.service";
import { Story } from "./story.model";
import { FormControl } from "@angular/forms";
import { Subject } from "rxjs/Subject";

@Component({
    templateUrl: "./story-edit-page.component.html",
    styleUrls: [
        "../shared/components/forms.css",
        "../shared/components/page.css",
        "./story-edit-page.component.css"
    ],
    selector: "ce-story-edit-page"
})
export class StoryEditPageComponent {
    constructor(
        private _activatedRoute: ActivatedRoute,
        private _storiesService: StoriesService,
        private _router: Router
    ) {
        this._activatedRoute.params
            .takeUntil(this._ngUnsubscribe)
            .filter(params => params["id"] != null)
            .switchMap(params => this._storiesService.getById({ id: params["id"] }))
            .map(x => this.story = x.story)
            .do(() => {
                this.descriptionFormControl.setValue(this.story.description);                
                this.nameFormControl.setValue(this.story.name);
            })
            .subscribe();
    }

    public ngAfterViewInit() {
        this.descriptionFormControl.patchValue(this.story.description);        
        this.nameFormControl.patchValue(this.story.name);
    }

    public tryToSave() {
        const story: Partial<Story> = {
            id: this.story.id,
            name: this.nameFormControl.value,
            description: this.descriptionFormControl.value,            
        };
        
        this._storiesService.addOrUpdate({story})
            .do(() => this._router.navigateByUrl("/stories/list"))
            .takeUntil(this._ngUnsubscribe)
            .subscribe();
    }

    public tryToRemove() {
        this._storiesService.remove({ story: this.story })
            .do(() => this._router.navigateByUrl("/stories/list"))
            .takeUntil(this._ngUnsubscribe)
            .subscribe();
    }

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
        this._ngUnsubscribe.next();     
    }

    public descriptionFormControl: FormControl = new FormControl('');
    
    public nameFormControl: FormControl = new FormControl('');

    public story: Partial<Story> = {

        description: `<p><strong>As a </strong>product owner</p> <p><strong>I want/can</strong> &lt;action&gt;</p> <p><strong>so that</strong> &lt;reason&gt;</p>`
    };
}
