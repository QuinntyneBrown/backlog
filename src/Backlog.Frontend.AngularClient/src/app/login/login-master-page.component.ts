import { Component, ChangeDetectionStrategy, Input, Inject } from "@angular/core";
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
    templateUrl: "./login-master-page.component.html",
    styleUrls: ["./login-master-page.component.css"],
    selector: "ce-login-master-page"
})
export class LoginMasterPageComponent {
    constructor(
        private _client: HttpClient,
        private _loginRedirectService: RedirectService,
        private _storage: Storage,
        @Inject(constants.BASE_URL) private _baseUrl:string
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

        this._client.post(`${this._baseUrl}/api/users/token`, formEncode($event.value), { headers })            
            .do(response => this._storage.put({ name: constants.ACCESS_TOKEN_KEY, value: response["access_token"] }))
            .switchMap(() => this._client.get(`${this._baseUrl}/api/users/current`))
            .do(response => this._storage.put({ name: constants.CURRENT_USER_KEY, value: response["user"] }))            
            .toPromise()
            .then(() => this._loginRedirectService.redirectPreLogin());
    }

    public username: string = "";

    public password: string = "";

    public rememberMe: boolean = false;
}
