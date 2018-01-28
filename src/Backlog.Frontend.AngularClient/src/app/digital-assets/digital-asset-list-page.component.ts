import { Component, Inject } from "@angular/core";
import { Subject } from "rxjs/Subject";
import { DigitalAssetsService } from "./digital-assets.service";
import { Router } from "@angular/router";
import { pluckOut } from "../shared/utilities/pluck-out";
import { DigitalAsset } from "./digital-asset.model";
import { constants } from "../shared";
import { Storage } from "../shared/services/storage.service";

@Component({
    templateUrl: "./digital-asset-list-page.component.html",
    styleUrls: [
        "../shared/components/page.css",
        "./digital-asset-list-page.component.css"
    ],
    selector: "ce-digital-asset-list-page"
})
export class DigitalAssetListPageComponent { 
    constructor(
        private _router: Router,
        private _digitalAssetsService: DigitalAssetsService,
        private _storage: Storage,
        @Inject(constants.BASE_URL) private _baseUrl:string) { }

    public handleViewClick($event: { digitalAsset: DigitalAsset }) {
        window.open(`${$event.digitalAsset.url}&oAuthToken=${this.oauthToken}&tenantUniqueId=${this.tenantUniqueId}`, "_blank", "", true);
    }

    public handleEditClick($event) {
        this._router.navigateByUrl(`/digitalassets/edit/${$event.digitalAsset.id}`);
    }

    public handleDeleteClick($event) {
        this._digitalAssetsService.remove({ digitalAsset: $event.digitalAsset })
            .takeUntil(this._ngUnsubscribe)
            .subscribe();

        pluckOut({ items: this.digitalAssets, value: $event.digitalAsset.id });
    }

    public ngOnInit() {
        this._digitalAssetsService.get()
            .takeUntil(this._ngUnsubscribe)
            .subscribe((data) => this.digitalAssets = data.digitalAssets);
    }

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }

    public get oauthToken() { return this._storage.get({ name: constants.ACCESS_TOKEN_KEY }); }

    public get tenantUniqueId() {
        return this._storage.get({ name: constants.TENANT_KEY });
    }

    public digitalAssets: Array<Partial<DigitalAsset>> = [];
}
