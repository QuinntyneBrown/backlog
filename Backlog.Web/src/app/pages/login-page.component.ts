import { Component, ChangeDetectionStrategy, Input } from "@angular/core";
import { AuthenticationActions } from "../actions";
import { AppStore } from "../store";
import { LoginRedirectService } from "../routing";

@Component({
    template: require("./login-page.component.html"),
    styles: [require("./login-page.component.scss")],
    selector: "login-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class LoginPageComponent {
    constructor(
        private _authenticationActions: AuthenticationActions,
        private _loginRedirectService: LoginRedirectService,
        private _store: AppStore
    ) {
        _store.currentUser$.subscribe(currentUser => {
            if (currentUser)
                this._loginRedirectService.redirectPreLogin();
        });
    }

    public tryToLogin($event: { value: { username: string, password: string } }) {
        this._authenticationActions.tryToLogin({
            username: $event.value.username,
            password: $event.value.password
        });
    }
}
