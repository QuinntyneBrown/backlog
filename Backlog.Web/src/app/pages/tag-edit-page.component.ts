import { Component, Input } from "@angular/core";
import { TagActions } from "../actions";
import { Router } from "@angular/router";

@Component({
    template: require("./tag-edit-page.component.html"),
    styles: [require("./tag-edit-page.component.scss")],
    selector: "tag-edit-page"
})
export class TagEditPageComponent { 
    constructor(private _tagActions: TagActions, private _router: Router) { }

    public onSubmit($event: any) {
        this._tagActions.add({
            id: $event.value.id,
            name: $event.value.name
        });

        setTimeout(() => { this._router.navigate(["/tags"]); }, 0);
        
    }
}
