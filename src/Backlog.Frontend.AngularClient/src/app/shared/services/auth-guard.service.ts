import { Injectable } from "@angular/core";
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Storage } from "./storage.service";
import { RedirectService } from "./redirect.service";
import { Observable } from "rxjs";
import { constants } from "../constants";
import * as jwtDecode from "jwt-decode";

@Injectable()
export class AuthGuardService implements CanActivate {
    constructor(
        private _storage: Storage,
        private _redirectService: RedirectService
    ) { }

    public canActivate(
        next: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<boolean> {
        const token = this._storage.get({ name: constants.ACCESS_TOKEN_KEY });
        
        if (token)
            return Observable.of(true);
        
        this._redirectService.lastPath = state.url;
        this._redirectService.redirectToLogin();

        return Observable.of(false);
    }
}