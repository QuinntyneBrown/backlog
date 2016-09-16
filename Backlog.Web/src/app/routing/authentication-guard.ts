import { Injectable } from '@angular/core';
import {
    CanActivate,
    Router,
    ActivatedRouteSnapshot,
    RouterStateSnapshot
} from '@angular/router'

import { AppStore } from "../store";
import { Observable } from 'rxjs/Observable';
import { LoginRedirectService } from "./login-redirect.service";

@Injectable()
export class AuthenticationGuard {    
    constructor(private _loginRedirectService: LoginRedirectService,
        private _router: Router,
        private _store: AppStore) {
        _store.token$.subscribe(token => this._token = token);
    }

    canActivate(
        next: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ) {
        if (this._token) {
            return Observable.of(true);
        }

        this._loginRedirectService.lastPath = state.url;
        this._router.navigate([this._loginRedirectService.loginUrl]);
        return Observable.of(false);
    }
    private _token: string;
}
