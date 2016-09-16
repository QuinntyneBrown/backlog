import { NgModule } from '@angular/core';
import { HttpModule } from "@angular/http";

import { OAuthHelper } from "./oauth-helper";

const providers = [OAuthHelper];

@NgModule({
    imports: [HttpModule],
	providers: providers
})
export class HelpersModule { }
