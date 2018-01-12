import { Component, ChangeDetectionStrategy, Input } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { RedirectService } from "../shared/services/redirect.service";
import { Storage } from "../shared/services";
import { constants } from "../shared/constants";

function formEncode(data: any) {
    var pairs = [];
    for (var name in data) {
        pairs.push(encodeURIComponent(name) + '=' + encodeURIComponent(data[name]));
    }
    return pairs.join('&').replace(/%20/g, '+');
}

@Component({
    templateUrl: "./login-shell.component.html",
    styleUrls: ["./login-shell.component.css"],
    selector: "ce-login-shell"
})
export class LoginShellComponent {
    constructor(
        private _client: HttpClient,
        private _loginRedirectService: RedirectService,
        private _storage: Storage
    ) { }

    public ngOnInit() {
        const loginCredentials = this._storage.get({ name: constants.LOGIN_CREDENTIALS_KEY });
        
        if (loginCredentials && loginCredentials.rememberMe) {
            this.username = loginCredentials.username;
            this.password = loginCredentials.password;
            this.rememberMe = loginCredentials.rememberMe;
        }
    }

    public tryToLogin($event: { value: { username: string, password: string, rememberMe: boolean } }) {

        this._storage.put({ name: constants.LOGIN_CREDENTIALS_KEY, value: $event.value.rememberMe ? $event.value : null });


        Object.assign($event.value, { "grant_type": "password" });

        const headers = new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded');

        this._client.post("/api/users/token", formEncode($event.value), { headers })
            .map((response) => {
                this._storage.put({ name: constants.ACCESS_TOKEN_KEY, value: response["access_token"] });
            })
            .toPromise()
            .then(() => {
                this._loginRedirectService.redirectPreLogin();
            });
    }

    public username: string = "";

    public password: string = "";

    public rememberMe: boolean = false;
}
