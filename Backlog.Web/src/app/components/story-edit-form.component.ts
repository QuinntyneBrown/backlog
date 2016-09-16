import { Component, ChangeDetectionStrategy, Input, Output, AfterViewInit, EventEmitter, Renderer, ElementRef } from "@angular/core";

import {
    FormGroup,
    FormControl,
    Validators
} from "@angular/forms";

import { Story } from "../models";

@Component({
    template: require("./story-edit-form.component.html"),
    styles: [require("./story-edit-form.component.scss")],
    selector: "story-edit-form",
})
export class StoryEditFormComponent implements AfterViewInit  { 

    constructor(private _renderer: Renderer, private _elementRef: ElementRef) { } 

    public get name(): HTMLElement {
        return this._elementRef.nativeElement.querySelector("#name");
    }

    ngAfterViewInit() {
        this._renderer.invokeElementMethod(this.name, 'focus', []);
    }
	    
    @Input() public story: Story;
    @Output() public onSubmit = new EventEmitter();
    public form = new FormGroup({
        name: new FormControl("", [
            Validators.required
        ])
    });
}
