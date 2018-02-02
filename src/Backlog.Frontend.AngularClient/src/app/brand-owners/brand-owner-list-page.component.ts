import { Component } from "@angular/core";
import { Subject } from "rxjs/Subject";
import { BrandOwnersService } from "./brand-owners.service";
import { Router } from "@angular/router";
import { pluckOut } from "../shared/utilities/pluck-out";

@Component({
    templateUrl: "./brand-owner-list-page.component.html",
    styleUrls: [
        "../shared/components/page.css",
        "./brand-owner-list-page.component.css"
    ],
    selector: "ce-brand-owner-list-page"
})
export class BrandOwnerListPageComponent { 
    constructor(
        private _router: Router,
        private _brandOwnersService: BrandOwnersService) { }

    public handleEditClick($event) {        
        this._router.navigateByUrl(`/brandowners/edit/${$event.brandOwner.id}`);
    }

    public handleDeleteClick($event) {
        this._brandOwnersService.remove({ brandOwner: $event.brandOwner })
            .takeUntil(this._ngUnsubscribe)
            .subscribe();

        pluckOut({ items: this.brandOwners, value: $event.brandOwner.id });
    }

    public ngOnInit() {
        this._brandOwnersService.get()
            .takeUntil(this._ngUnsubscribe)
            .map(data => this.brandOwners = data.brandOwners)
            .subscribe();
    }

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }

    public brandOwners: Array<any> = [];
}
