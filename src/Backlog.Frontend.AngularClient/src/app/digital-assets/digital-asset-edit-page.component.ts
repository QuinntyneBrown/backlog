import { Component } from "@angular/core";
import { DigitalAssetsService } from "./digital-assets.service";
import { Router,ActivatedRoute } from "@angular/router";
import { Subject } from "rxjs";
import { DigitalAsset } from "./digital-asset.model";

@Component({
    templateUrl: "./digital-asset-edit-page.component.html",
    styleUrls: [
        "../shared/components/page.css",
        "./digital-asset-edit-page.component.css"
    ],
    selector: "ce-digital-asset-edit-page"
})
export class DigitalAssetEditPageComponent {
    constructor(private _digitalAssetsService: DigitalAssetsService,
        private _router: Router,
        private _activatedRoute: ActivatedRoute
    ) { }

    public ngOnInit() {
        if (this._activatedRoute.snapshot.params["id"])            
            this._digitalAssetsService.getById({ id: this._activatedRoute.snapshot.params["id"] })
                .takeUntil(this._ngUnSubscribe)
                .subscribe(x => this.digitalAsset = x.digitalAsset);        
    }

    public tryToSave($event) {        
        this._digitalAssetsService
            .addOrUpdate({ digitalAsset: $event.detail.digitalAsset })
            .takeUntil(this._ngUnSubscribe)
            .do(() => this._router.navigateByUrl("/digitalassets/list"))
            .subscribe();        
    }

    public digitalAsset: Partial<DigitalAsset> = {};

    private _ngUnSubscribe: Subject<void> = new Subject();

    public ngOnDestroy() {
        this._ngUnSubscribe.next();
    }
}
