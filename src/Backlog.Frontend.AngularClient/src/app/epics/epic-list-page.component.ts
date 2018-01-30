import { Component } from "@angular/core";
import { Subject } from "rxjs/Subject";
import { EpicsService } from "./epics.service";
import { Router } from "@angular/router";
import { pluckOut } from "../shared/utilities/pluck-out";
import { Epic } from "./epic.model";

@Component({
    templateUrl: "./epic-list-page.component.html",
    styleUrls: [
        "../shared/components/page.css",
        "./epic-list-page.component.css"
    ],
    selector: "ce-epic-list-page"
})
export class EpicListPageComponent { 
    constructor(
        private _router: Router,
        private _epicsService: EpicsService) { }

    public handleEditClick($event) {        
        this._router.navigateByUrl(`/epics/edit/${$event.epic.id}`);
    }

    public handleDeleteClick($event) {
        this._epicsService.remove({ epic: $event.epic })
            .takeUntil(this._ngUnsubscribe)
            .subscribe();

        pluckOut({ items: this.epics, value: $event.epic.id });
    }

    public ngOnInit() {
        this._epicsService.get()
            .takeUntil(this._ngUnsubscribe)
            .do(data => this.epics = data.epics)
            .subscribe();
    }

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }

    public epics: Array<Partial<Epic>> = [];
}
