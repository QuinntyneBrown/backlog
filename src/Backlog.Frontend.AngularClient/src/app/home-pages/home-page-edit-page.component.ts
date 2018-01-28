import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { HomePagesService } from "./home-pages.service";
import { Subject } from "rxjs";
import { RedirectService } from "../shared/services/redirect.service";

@Component({
    templateUrl: "./home-page-edit-page.component.html",
    styleUrls: [
        "../shared/components/forms.css",
        "../shared/components/page.css",
        "./home-page-edit-page.component.css"],
    selector: "ce-home-page-edit-page"
})
export class HomePageEditPageComponent {
    constructor(private _homePagesService: HomePagesService,
        private _router: Router,
        private _redirectService: RedirectService
    ) { }

    public ngOnInit() {
        this._homePagesService.get()
            .takeUntil(this._ngUnsubscribe)
            .map(x => this.homePage = x.homePage || { avatarImageUrl: null })
            .subscribe();
    }

    public tryToSave($event) {        
        this._homePagesService
            .addOrUpdate({ homePage: this.homePage })
            .takeUntil(this._ngUnsubscribe)
            .do(() => this._redirectService.redirectToDefault())
            .subscribe();
    }

    public ngOnDestroy() {
        this._ngUnsubscribe.next();
    }

    public homePage:any = {
        avatarImageUrl: null
    };

    private _ngUnsubscribe: Subject<void> = new Subject();
}
