import { Component, ChangeDetectionStrategy, Input, Output, AfterViewInit, EventEmitter } from "@angular/core";

import {
    FormGroup,
    FormControl,
    Validators
} from "@angular/forms";

@Component({
    template: require("./epic-edit-form.component.html"),
    styles: [require("./epic-edit-form.component.scss")],
    selector: "epic-edit-form",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class EpicEditFormComponent {     
    @Input() public epic: any;
    @Output() public onSubmit = new EventEmitter();
    public form = new FormGroup({
        name: new FormControl("", [
            Validators.required
        ]),
        description: new FormControl("", [
            Validators.required
        ])
    });
}
