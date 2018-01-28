import { Component, EventEmitter, Output, ElementRef } from "@angular/core";
import { Subject } from "rxjs/Subject";
import { constants } from "../constants";
import { Storage } from "../services/storage.service";

@Component({
    templateUrl: "./header.component.html",
    styleUrls: ["./header.component.css"],
    selector: "ce-header"
})
export class HeaderComponent { 
    constructor(
        public elementRef: ElementRef,
        public _storage:Storage
    ) {

    }
    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }

    @Output()
    public clicked: EventEmitter<any> = new EventEmitter();

    @Output()
    public currentUserClicked: EventEmitter<any> = new EventEmitter();

    public get currentUserName() {
        return this._storage.get({ name: constants.CURRENT_USER_KEY }).name;
    }

    public get currentUserAvatarImageUrl() {
        return this._storage.get({ name: constants.CURRENT_USER_KEY }).profile.avatarImageUrl;
    }
}
