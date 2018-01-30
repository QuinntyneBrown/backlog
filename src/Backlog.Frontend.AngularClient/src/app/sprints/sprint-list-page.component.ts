import { Component } from "@angular/core";
import { Subject } from "rxjs/Subject";
import { SprintsService } from "./sprints.service";
import { Router } from "@angular/router";
import { pluckOut } from "../shared/utilities/pluck-out";

@Component({
    templateUrl: "./sprint-list-page.component.html",
    styleUrls: [
        "../shared/components/page.css",
        "./sprint-list-page.component.css"
    ],
    selector: "ce-sprint-list-page"
})
export class SprintListPageComponent { 
    constructor(
        private _router: Router,
        private _sprintsService: SprintsService) { }

    public handleEditClick($event) {        
        this._router.navigateByUrl(`/sprints/edit/${$event.sprint.id}`);
    }

    public handleDeleteClick($event) {
        this._sprintsService.remove({ sprint: $event.sprint })
            .takeUntil(this._ngUnsubscribe)
            .subscribe();

        pluckOut({ items: this.sprints, value: $event.sprint.id });
    }

    public ngOnInit() {
        this._sprintsService.get()
            .takeUntil(this._ngUnsubscribe)
            .map(data => this.sprints = data.sprints)
            .subscribe();
    }

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }

    public sprints: Array<any> = [];
}
