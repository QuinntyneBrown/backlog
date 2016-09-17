import { Component, ChangeDetectionStrategy, Input, Output, OnInit, AfterViewInit, EventEmitter, Renderer, ElementRef } from "@angular/core";

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
export class StoryEditFormComponent implements AfterViewInit, OnInit  { 

    constructor(private _renderer: Renderer, private _elementRef: ElementRef) { } 

    ngOnInit() {
        if (this.story && this.story.id)
            this.description = this.story.description;
    }
    public get name(): HTMLElement {
        return this._elementRef.nativeElement.querySelector("#name");
    }

    ngAfterViewInit() {
        this._renderer.invokeElementMethod(this.name, 'focus', []);

        if (this.story && this.story.id) {
            this.form.patchValue({ id: this.story.id })
            this.form.patchValue({ name: this.story.name });
            this.form.patchValue({ priority: this.story.priority });
        }
    }
	    
    @Input() public story: Story;
    @Output() public onSubmit = new EventEmitter();
    @Output() public onCancel = new EventEmitter();

    public description: string = "<p><strong>As a</strong> &lt;user/product owner&gt;</p> <p><strong>I want/can</strong> &lt;action&gt;</p> <p><strong>So that </strong>&lt;reason&gt;</p>"
    public form = new FormGroup({
        id: new FormControl("", []),
        name: new FormControl("", []),
        priority: new FormControl("", [])
    });

    public tryToSubmit() {
        this.onSubmit.emit({
            value: Object.assign({}, this.form.value, { description: this.description })
        });
    }

    public tryToCancel() {
        this.onCancel.emit();
    }
}
