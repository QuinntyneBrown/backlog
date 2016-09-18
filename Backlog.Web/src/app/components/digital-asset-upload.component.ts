import {
    Component,
    ChangeDetectionStrategy,
    Input,
    OnDestroy,
    OnInit,
    Output,
    ElementRef,
    EventEmitter
} from "@angular/core";

@Component({
    template: require("./digital-asset-upload.component.html"),
    styles: [require("./digital-asset-upload.component.scss")],
    selector: "digital-asset-upload"
})
export class DigitalAssetUploadComponent implements OnInit, OnDestroy {
    constructor(private _elementRef: ElementRef) { }

    @Output()
    public onUpload: EventEmitter<any> = new EventEmitter();

    ngOnInit() {
        this.drop.addEventListener("dragover", (dragEvent: DragEvent) => {
            dragEvent.stopPropagation();
            dragEvent.preventDefault();
        }, false);

        this.drop.addEventListener("drop", this.upload, false);
    }

    ngOnDestroy() { this.drop.removeEventListener("drop", this.upload, false); }

    upload = (dragEvent: DragEvent) => {
        dragEvent.stopPropagation();
        dragEvent.preventDefault();

        if (dragEvent.dataTransfer && dragEvent.dataTransfer.files) {
            var packageFiles = function (fileList: FileList) {
                var formData = new FormData();
                for (var i = 0; i < fileList.length; i++) {
                    formData.append(fileList[i].name, fileList[i]);
                }
                return formData;
            }
            var files = packageFiles(dragEvent.dataTransfer.files);
            this.onUpload.emit({files: files});
        }        
    }

    get drop() { return $(this._elementRef.nativeElement).find(".drop-zone")[0]; }
}