import { Component, ElementRef } from "@angular/core";
import { Subject } from "rxjs/Subject";
import { DigitalAssetsService } from "./digital-assets.service";
import { Router } from "@angular/router";

@Component({
    templateUrl: "./digital-asset-upload-page.component.html",
    styleUrls: [
        "../shared/components/page.css",
        "./digital-asset-upload-page.component.css"
    ],
    selector: "ce-digital-asset-upload-page"
})
export class DigitalAssetUploadPageComponent { 
    constructor(
        private _elementRef: ElementRef,
        private _digitalAssetsService: DigitalAssetsService,
        private _router: Router
    ) {
        this.onDragOver = this.onDragOver.bind(this);
        this.onDrop = this.onDrop.bind(this);
    }

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    
    public ngAfterViewInit() {
        this._elementRef.nativeElement.addEventListener("dragover", this.onDragOver);
        this._elementRef.nativeElement.addEventListener("drop", this.onDrop, false);
    }

    public ngOnDestroy() {
        this._ngUnsubscribe.next();
        this._elementRef.nativeElement.removeEventListener("dragover", this.onDragOver);
        this._elementRef.nativeElement.removeEventListener("drop", this.onDrop, false);
    }

    public onDragOver(e: DragEvent) {
        e.stopPropagation();
        e.preventDefault();
    }

    public async onDrop(e: DragEvent) {
        e.stopPropagation();
        e.preventDefault();

        if (e.dataTransfer && e.dataTransfer.files) {
            const packageFiles = function (fileList: FileList) {
                let formData = new FormData();
                for (var i = 0; i < fileList.length; i++) {
                    formData.append(fileList[i].name, fileList[i]);
                }
                return formData;
            }

            const data = packageFiles(e.dataTransfer.files);

            this._digitalAssetsService.upload({ data })
                .takeUntil(this._ngUnsubscribe)
                .subscribe(x => this._router.navigateByUrl("/digitalassets/list"));

        }
    }
}
