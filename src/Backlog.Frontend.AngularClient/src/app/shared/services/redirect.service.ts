﻿import { Injectable, Inject } from "@angular/core";
import { ActivatedRoute, Router } from '@angular/router';
import { constants } from "../constants";

@Injectable()
export class RedirectService {
    constructor(
        private _route: ActivatedRoute,
        private _router: Router,
        @Inject(constants.DEFAULT_PATH) public defaultPath:string
    ) {
    }

    loginUrl: string = "/login";
    lastPath: string;    
    setTenantUrl: string = "/tenants/set";
    setLoginUrl(value) { this.loginUrl = value; }
    setDefaultUrl(value) { this.defaultPath = value; }

    public redirectToLogin() {
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

    public redirectToDefault() {
        this._router.navigate([this.defaultPath]);
    }

    public redirectToSetTenant() {
        this._router.navigate([this.setTenantUrl]);
    }
}