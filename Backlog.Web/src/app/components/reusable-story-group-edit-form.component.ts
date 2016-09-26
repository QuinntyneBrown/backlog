import { Component, ChangeDetectionStrategy, Input, Output, AfterViewInit, EventEmitter, Renderer, ElementRef } from "@angular/core";

import {
    FormGroup,
    FormControl,
    Validators
} from "@angular/forms";

import { ReusableStoryGroup } from "../models";

@Component({
    template: require("./reusable-story-group-edit-form.component.html"),
    styles: [require("./reusable-story-group-edit-form.component.scss")],
    selector: "reusable-story-group-edit-form",
})
export class ReusableStoryGroupEditFormComponent implements AfterViewInit  { 

    constructor(private _renderer: Renderer, private _elementRef: ElementRef) { } 

    public get name(): HTMLElement {
        return this._elementRef.nativeElement.querySelector("#name");
    }

    ngAfterViewInit() {
        this._renderer.invokeElementMethod(this.name, 'focus', []);
    }
	    
    @Input() public reusableStoryGroup: ReusableStoryGroup;
    @Output() public onSubmit = new EventEmitter();
    public form = new FormGroup({
		id: new FormControl("", []),
        name: new FormControl("", [
            Validators.required
        ])
    });
}
