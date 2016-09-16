import { Component, Input } from "@angular/core";
import { ThemeActions } from "../actions";
import { Router } from "@angular/router";

@Component({
    template: require("./theme-edit-page.component.html"),
    styles: [require("./theme-edit-page.component.scss")],
    selector: "theme-edit-page"
})
export class ThemeEditPageComponent { 
    constructor(private _themeActions: ThemeActions, private _router: Router) { }

    public onSubmit($event: any) {
        this._themeActions.add({
            id: $event.value.id,
            name: $event.value.name
        });

        setTimeout(() => { this._router.navigate(["/themes"]); }, 0);
        
    }
}
