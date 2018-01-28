import { Component } from "@angular/core";
import { Subject } from "rxjs/Subject";
import { ApiService } from "./api.service";

@Component({
    templateUrl: "./home-page.component.html",
    styleUrls: ["./home-page.component.css"],
    selector: "ce-home-page"
})
export class HomePageComponent { 
    constructor(private _apiService: ApiService) {

    }
    ngOnInit() {
        this._apiService
            .getHomePage()
            .takeUntil(this._ngUnsubscribe)
            .map(x => this.homePage = x.homePage)
            .subscribe();

    }
    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }

    public homePage: any = {};
}
