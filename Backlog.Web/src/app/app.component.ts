import { Component, ChangeDetectionStrategy, Input, OnInit, ViewEncapsulation } from "@angular/core";
import { AppStore } from "./store";
import { ContentActions } from "./actions";
import { Router } from "@angular/router";

@Component({
    template: require("./app.component.html"),
    styles: [require("./app.component.scss")],
    selector: "app",
    changeDetection: ChangeDetectionStrategy.OnPush,
    encapsulation: ViewEncapsulation.None
})
export class AppComponent implements OnInit {
    constructor(
        private _store: AppStore,
        private _contentActions: ContentActions,
        private _router: Router
    ) { }

    ngOnInit() {
        this._contentActions.getByType({ type: "AppShell" });

        this._router.events.subscribe((x:any) => {

        });
    }

    public get appShell$() {
        return this._store.contentByType$("AppShell");
    }

    public get title$() {
        return this.appShell$.map((appShell: any) => {
            return appShell.title;
        });
    }

    public get menuItems$() {
        return this.appShell$.map((appShell: any) => {
            return appShell.menuItems;
        });
    }
}
