import { Component, ElementRef, AfterViewInit, Input, forwardRef, Inject} from "@angular/core";
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from "@angular/forms";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { constants } from "../constants";
import { Subject } from "rxjs/Subject";

@Component({
    templateUrl: "./digital-asset-input-url.component.html",
    styleUrls: [
        "../components/forms.css",
        "./digital-asset-input-url.component.css"
    ],
    providers: [
        {
            provide: NG_VALUE_ACCESSOR,
            useExisting: forwardRef(() => DigitalAssetInputUrlComponent),
            multi: true
        }
    ],
    selector: "ce-digital-asset-input-url"
})
export class DigitalAssetInputUrlComponent implements ControlValueAccessor {
    constructor(
        private _elementRef: ElementRef,
        private _client: HttpClient,
        @Inject(constants.BASE_URL)private _baseUrl:string
    ) {
        this.onDragOver = this.onDragOver.bind(this);
        this.onDrop = this.onDrop.bind(this);
        this.handleKeyUp = this.handleKeyUp.bind(this);
    }

    public handleKeyUp() { this.onChangeCallback(this.inputElement.value); }

    public get value() { return this.inputElement.value; }
    
    public writeValue(value: any): void { this.inputElement.value = value; }

    public registerOnChange(fn: any): void { this.onChangeCallback = fn; }

    public registerOnTouched(fn: any): void { this.onTouchedCallback = fn; }

    public setDisabledState?(isDisabled: boolean): void { this.inputElement.disabled = isDisabled; }

    public onTouchedCallback: () => void = () => { };

    public onChangeCallback: (_: any) => void = () => { };
  
    public ngAfterViewInit() {        
        this._elementRef.nativeElement.addEventListener("dragover", this.onDragOver);
        this._elementRef.nativeElement.addEventListener("drop", this.onDrop, false);
        this.inputElement.addEventListener("keyup", this.handleKeyUp);
    }

    public ngOnDestroy() {
        this._elementRef.nativeElement.removeEventListener("dragover", this.onDragOver);
        this._elementRef.nativeElement.removeEventListener("drop", this.onDrop, false);
        this.inputElement.removeEventListener("keyup", this.handleKeyUp);
        this._ngUnsubscribe.next();
    }

    public onDragOver(e: DragEvent) {
        e.stopPropagation();
        e.preventDefault();
    }

    public onDrop(e: DragEvent) {
        e.stopPropagation();
        e.preventDefault();

        if (e.dataTransfer && e.dataTransfer.files) {
            const packageFiles = function (fileList: FileList) {
                let formData = new FormData();
                for (let i = 0; i < fileList.length; i++) {
                    formData.append(fileList[i].name, fileList[i]);
                }
                return formData;
            }

            const data = packageFiles(e.dataTransfer.files);
            
            this._client.post<{ digitalAssets: Array<{ url: string }> }>(`${this._baseUrl}/api/digitalassets/upload`, data, { headers: new HttpHeaders().set("IsSecure", "false") })
                .takeUntil(this._ngUnsubscribe)
                .map((x: { digitalAssets: Array<{ url: string }> }) => {
                    this.inputElement.value = x.digitalAssets[0].url;
                    this.onChangeCallback(this.inputElement.value);
                })
                .subscribe();            
        }
    }
    
    public get inputElement(): HTMLInputElement { return this._elementRef.nativeElement.querySelector("input"); }

    private _ngUnsubscribe: Subject<void> = new Subject();    
}
