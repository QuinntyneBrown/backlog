import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { HttpModule } from "@angular/http";

import { ContentService } from "./content.service";
import { EpicService } from "./epic.service";
import { StoryService } from "./story.service";

const providers = [
    ContentService,
    EpicService,
    StoryService
];

@NgModule({
    imports: [CommonModule, HttpModule],
	providers: providers
})
export class ServicesModule { }
