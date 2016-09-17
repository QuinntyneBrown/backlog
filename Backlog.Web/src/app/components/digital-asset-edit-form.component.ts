import { Component, ChangeDetectionStrategy, Input, Output, AfterViewInit, EventEmitter, Renderer, ElementRef } from "@angular/core";

import {
    FormGroup,
    FormControl,
    Validators
} from "@angular/forms";

import { DigitalAsset } from "../models";

@Component({
    template: require("./digital-asset-edit-form.component.html"),
    styles: [require("./digital-asset-edit-form.component.scss")],
    selector: "digital-asset-edit-form",
})
export class DigitalAssetEditFormComponent implements AfterViewInit  { 

    constructor(private _renderer: Renderer, private _elementRef: ElementRef) { } 

    public get name(): HTMLElement {
        return this._elementRef.nativeElement.querySelector("#name");
    }

    ngAfterViewInit() {
        this._renderer.invokeElementMethod(this.name, 'focus', []);
    }
	    
    @Input() public digitalAsset: DigitalAsset;
    @Output() public onSubmit = new EventEmitter();
    public form = new FormGroup({
        name: new FormControl("", [
            Validators.required
        ])
    });
}
