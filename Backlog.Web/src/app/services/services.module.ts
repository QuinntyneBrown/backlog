import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { HttpModule } from "@angular/http";

import { AuthenticationService } from "./authentication.service";
import { ContentService } from "./content.service";
import { EpicService } from "./epic.service";
import { StoryService } from "./story.service";
import { DigitalAssetService } from "./digital-asset.service";
import { HtmlContentService } from "./html-content.service";

const providers = [
    AuthenticationService,
    ContentService,
    EpicService,
    StoryService,
    DigitalAssetService,
    HtmlContentService
];

@NgModule({
    imports: [CommonModule, HttpModule],
	providers: providers
})
export class ServicesModule { }
