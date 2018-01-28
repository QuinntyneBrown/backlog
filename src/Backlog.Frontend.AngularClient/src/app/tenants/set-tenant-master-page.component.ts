import { Component } from "@angular/core";
import { Storage } from "../shared/services/storage.service";
import { constants } from "../shared/constants";
import { RedirectService } from "../shared/services/redirect.service";
import { TenantsService } from "./tenants.service";

import { FormGroup, FormControl, Validators } from "@angular/forms";

@Component({
    templateUrl: "./set-tenant-master-page.component.html",
    styleUrls: [
        "../shared/components/forms.css",
        "./set-tenant-master-page.component.css"
    ],
    selector: "ce-set-tenant-master-page"
})
export class SetTenantMasterPageComponent {
    constructor(
        private _redirectService: RedirectService,
        private _storage: Storage,
        private _tenantsService: TenantsService
    ) { }

    public form = new FormGroup({
        id: new FormControl("", [Validators.required])
    });

    public tryToSubmit($event) {
        const uniqueId = $event.detail.tenant.id;
        this._tenantsService.verify({ uniqueId })
            .do(() => {
                this._storage.put({ name: constants.TENANT_KEY, value: uniqueId });
                this._redirectService.redirectPreLogin();
            })
            .subscribe();        
    }
}