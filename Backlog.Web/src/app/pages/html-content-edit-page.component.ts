import { Component, Input } from "@angular/core";
import { HtmlContentActions } from "../actions";
import { Router } from "@angular/router";

@Component({
    template: require("./html-content-edit-page.component.html"),
    styles: [require("./html-content-edit-page.component.scss")],
    selector: "html-content-edit-page"
})
export class HtmlContentEditPageComponent { 
    constructor(private _htmlContentActions: HtmlContentActions, private _router: Router) { }

    public onSubmit($event: any) {
        this._htmlContentActions.add({
            id: $event.value.id,
            name: $event.value.name
        });

        setTimeout(() => { this._router.navigate(["/htmlContents"]); }, 0);
        
    }
}
