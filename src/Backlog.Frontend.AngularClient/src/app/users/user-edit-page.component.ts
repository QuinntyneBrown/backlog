import { Router, ActivatedRoute } from "@angular/router";
import { Subject } from "rxjs/Subject";
import { UsersService } from "./users.service";
import { User } from "./user.model";
import {
    Component,
    Input,
    OnInit,
    EventEmitter,
    Output,
    AfterViewInit,
    AfterContentInit,
    Renderer,
    ElementRef,
} from "@angular/core";

import { FormGroup, FormControl, Validators } from "@angular/forms";

@Component({
    templateUrl: "./user-edit-page.component.html",
    styleUrls: [
        "../shared/components/page.css",
        "../shared/components/forms.css",
        "./user-edit-page.component.css"],
    selector: "ce-user-edit-page"
})
export class UserEditPageComponent {
    constructor(
        private _activatedRoute: ActivatedRoute,
        private _usersService: UsersService,
        private _router: Router
    ) {
        this._activatedRoute.params
            .takeUntil(this._ngUnsubscribe)
            .filter(params => params["id"] != null)
            .switchMap(params => this._usersService.getById({ id: params["id"] }))
            .map(x => this.user = x.user)
            .subscribe();
    }
    
    public tryToSave() {
        this.user.profile.avatarImageUrl = this.form.value.imageUrl;

        this._usersService.addOrUpdate({ user: this.user })
            .takeUntil(this._ngUnsubscribe)
            .subscribe();
    }

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
        this._ngUnsubscribe.next();
    }
    
    public form = new FormGroup({
        id: new FormControl('',[Validators.required]),
        imageUrl: new FormControl('', [])
    });

    public _user: Partial<User> = {};

    @Input("user")
    public set user(value) {
        this._user = value;

        this.form.patchValue({
            id: this._user.id,
            imageUrl: this._user.profile.avatarImageUrl
        });
    }

    public get user() {
        return this._user;
    }
}
