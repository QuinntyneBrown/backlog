import { Component, ChangeDetectionStrategy, Input, Output, AfterViewInit, EventEmitter, Renderer, ElementRef } from "@angular/core";

import {
    FormGroup,
    FormControl,
    Validators
} from "@angular/forms";

import { HtmlContent } from "../models";

@Component({
    template: require("./html-content-edit-form.component.html"),
    styles: [require("./html-content-edit-form.component.scss")],
    selector: "html-content-edit-form",
})
export class HtmlContentEditFormComponent implements AfterViewInit  { 

    constructor(private _renderer: Renderer, private _elementRef: ElementRef) { } 

    public get name(): HTMLElement {
        return this._elementRef.nativeElement.querySelector("#name");
    }

    ngAfterViewInit() {
        this._renderer.invokeElementMethod(this.name, 'focus', []);
    }
	    
    @Input() public htmlContent: HtmlContent;
    @Output() public onSubmit = new EventEmitter();
    public form = new FormGroup({
        name: new FormControl("", [
            Validators.required
        ])
    });
}
