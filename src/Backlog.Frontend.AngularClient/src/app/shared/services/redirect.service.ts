﻿﻿import { Injectable } from "@angular/core";
import { ActivatedRoute, Router } from '@angular/router';

@Injectable()
export class RedirectService {
    constructor(
        private _route: ActivatedRoute,
        private _router: Router) {
    }

    loginUrl: string = "/login";
    lastPath: string;
    defaultPath: string = "/";
    setTenantUrl: string = "/tenants/set";
    setLoginUrl(value) { this.loginUrl = value; }
    setDefaultUrl(value) { this.defaultPath = value; }

    public redirectToLogin() {
        console.log("redirect to login?");
        this._router.navigate([this.loginUrl]);
    }

    public redirectPreLogin() {
        if (this.lastPath && this.lastPath != this.loginUrl) {
            this._router.navigate([this.lastPath]);
            this.lastPath = "";
        } else {
            this._router.navigate([this.defaultPath]);
        }
    }  

    public redirectToSetTenant() {
        this._router.navigate([this.setTenantUrl]);
    }
}