import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Observable } from "rxjs";
import { OAuthHelper } from "../helpers";

import { apiCofiguration } from "../configuration";

@Injectable()
export class AuthenticationService {
    constructor(private _http: Http, private _oauthHelper: OAuthHelper) { }

    public tryToLogin(options: { username:string, password: string }) {
        return this._http
            .post(`${apiCofiguration.baseUrl}/api/user/token`, options)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public getCurrentUser() {
        return this._http
            .get(`${apiCofiguration.baseUrl}/api/user/current`, { headers: this._oauthHelper.getOAuthHeaders() })
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get baseUrl() { return apiCofiguration.baseUrl; }
}
