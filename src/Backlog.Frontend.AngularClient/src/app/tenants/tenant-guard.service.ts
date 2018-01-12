import { Injectable } from "@angular/core";
import {
    CanActivate,
    CanActivateChild,
    CanLoad,
    Route,
    ActivatedRouteSnapshot,
    RouterStateSnapshot
} from '@angular/router';

import { Storage } from "../shared/services/storage.service";
import { RedirectService } from "../shared/services/redirect.service";
import { Observable } from "rxjs";
import { constants } from "../shared/constants";

@Injectable()
export class TenantGuardService implements CanActivate {
    constructor(
        private _loginRedirectService: RedirectService,
        private _storage: Storage        
    ) { }

    public canActivate(
        next: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<boolean> {
        const tenant = this._storage.get({ name: constants.TENANT_KEY });
        
        if (tenant)
            return Observable.of(true);

        this._loginRedirectService.lastPath = state.url;
        this._loginRedirectService.redirectToSetTenant();

        return Observable.of(false);
    }
}