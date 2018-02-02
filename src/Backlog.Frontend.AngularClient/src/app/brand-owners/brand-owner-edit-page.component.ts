import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { BrandOwnersService } from "./brand-owners.service";
import { BrandOwner } from "./brand-owner.model";
import { FormControl } from "@angular/forms";
import { Subject } from "rxjs/Subject";

@Component({
    templateUrl: "./brand-owner-edit-page.component.html",
    styleUrls: [
        "../shared/components/forms.css",
        "../shared/components/page.css",
        "./brand-owner-edit-page.component.css"
    ],
    selector: "ce-brand-owner-edit-page"
})
export class BrandOwnerEditPageComponent {
    constructor(
        private _activatedRoute: ActivatedRoute,
        private _brandOwnersService: BrandOwnersService,
        private _router: Router
    ) {
        this._activatedRoute.params
            .takeUntil(this._ngUnsubscribe)
            .filter(params => params["id"] != null)
            .switchMap(params => this._brandOwnersService.getById({ id: params["id"] }))
            .map(x => this.brandOwner = x.brandOwner)
            .do(() => {        
                this.nameFormControl.setValue(this.brandOwner.name);
            })
            .subscribe();
    }

    public ngAfterViewInit() {
        this.nameFormControl.patchValue(this.brandOwner.name);
    }

    public tryToSave() {
        const brandOwner: Partial<BrandOwner> = {
            id: this.brandOwner.id,
            name: this.nameFormControl.value,
        };
        
        this._brandOwnersService.addOrUpdate({brandOwner})
            .do(() => this._router.navigateByUrl("/brandOwners/list"))
            .takeUntil(this._ngUnsubscribe)
            .subscribe();
    }

    public tryToRemove() {
        this._brandOwnersService.remove({ brandOwner: this.brandOwner })
            .do(() => this._router.navigateByUrl("/brandOwners/list"))
            .takeUntil(this._ngUnsubscribe)
            .subscribe();
    }

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
        this._ngUnsubscribe.next();     
    }

    
    public nameFormControl: FormControl = new FormControl('');

    public brandOwner: Partial<BrandOwner> = {};
}
