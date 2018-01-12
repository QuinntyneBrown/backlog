import { Component } from "@angular/core";
import { Storage } from "../shared/services/storage.service";
import { constants } from "../shared/constants";
import { RedirectService } from "../shared/services/redirect.service";
import { TenantsService } from "./tenants.service";

import { FormGroup, FormControl, Validators } from "@angular/forms";

@Component({
    templateUrl: "./set-tenant-shell.component.html",
    styleUrls: ["./set-tenant-shell.component.css"],
    selector: "ce-set-tenant-shell"
})
export class SetTenantShellComponent {
    constructor(
        private _redirectService: RedirectService,
        private _storage: Storage) { }

    public form = new FormGroup({
        id: new FormControl("", [Validators.required])
    });

    tryToSubmit($event) {
        this._storage.put({ name: constants.TENANT_KEY, value: $event.detail.tenant.id });
        this._redirectService.redirectPreLogin();
    }
}
