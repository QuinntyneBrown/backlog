import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { EpicsService } from "./epics.service";
import { Epic } from "./epic.model";
import { FormControl } from "@angular/forms";
import { Subject } from "rxjs/Subject";

@Component({
    templateUrl: "./epic-edit-page.component.html",
    styleUrls: [
        "../shared/components/forms.css",
        "../shared/components/page.css",
        "./epic-edit-page.component.css"
    ],
    selector: "ce-epic-edit-page"
})
export class EpicEditPageComponent {
    constructor(
        private _activatedRoute: ActivatedRoute,
        private _epicsService: EpicsService,
        private _router: Router
    ) {
        this._activatedRoute.params
            .takeUntil(this._ngUnsubscribe)
            .filter(params => params["id"] != null)
            .switchMap(params => this._epicsService.getById({ id: params["id"] }))
            .map(x => this.epic = x.epic)
            .do(() => {        
                this.nameFormControl.setValue(this.epic.name);
            })
            .subscribe();
    }

    public ngAfterViewInit() {
        this.nameFormControl.patchValue(this.epic.name);
    }

    public tryToSave() {
        const epic: Partial<Epic> = {
            id: this.epic.id,
            name: this.nameFormControl.value,
        };
        
        this._epicsService.addOrUpdate({epic})
            .do(() => this._router.navigateByUrl("/epics/list"))
            .takeUntil(this._ngUnsubscribe)
            .subscribe();
    }

    public tryToRemove() {
        this._epicsService.remove({ epic: this.epic })
            .do(() => this._router.navigateByUrl("/epics/list"))
            .takeUntil(this._ngUnsubscribe)
            .subscribe();
    }

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
        this._ngUnsubscribe.next();     
    }

    
    public nameFormControl: FormControl = new FormControl('');

    public epic: Partial<Epic> = {};
}
