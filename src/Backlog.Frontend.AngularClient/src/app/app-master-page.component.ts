import { Component } from "@angular/core";
import { Subject } from "rxjs/Subject";
import { Router } from "@angular/router";
import { PopoverService } from "./shared/services/popover.service";
import { dropDownMenuEvents } from "./shared";

@Component({
    templateUrl: "./app-master-page.component.html",
    styleUrls: ["./app-master-page.component.css"],
    selector: "ce-app-master-page"
})
export class AppMasterPageComponent { 
    constructor(
        public _router: Router,
        public popoverService: PopoverService
    ) {
        this.handleDropDownMenuItemClick = this.handleDropDownMenuItemClick.bind(this);
    }

    ngOnInit() {
        document.addEventListener(dropDownMenuEvents.DROP_DOWN_MENU_ITEM_CLICK, this.handleDropDownMenuItemClick);

    }
    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }

    public onClick($event) {
        this.targetHTMLElement = $event.nativeElement.querySelector('h1') as HTMLElement;
        this.popoverService.show({ target: this.targetHTMLElement, html: "<ce-drop-down-menu></ce-drop-down-menu>" })
            .then(() => { });
    }

    public onCurrentUserClick($event) {
        this.targetHTMLElement = $event.nativeElement.querySelector('.current-user a') as HTMLElement;
        this.popoverService.show({ target: this.targetHTMLElement, html: "<ce-drop-down-menu></ce-drop-down-menu>" })
            .then(() => { });
    }

    public handleDropDownMenuItemClick($event) {
        this.popoverService.hide();
        this._router.navigateByUrl($event["detail"].url);
    }

    public targetHTMLElement: HTMLElement;
}
