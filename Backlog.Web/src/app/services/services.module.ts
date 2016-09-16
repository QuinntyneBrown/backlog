import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { HttpModule } from "@angular/http";

import { EpicService } from "./epic.service";
import { StoryService } from "./story.service";

const providers = [
    EpicService,
    StoryService
];

@NgModule({
    imports: [CommonModule, HttpModule],
	providers: providers
})
export class ServicesModule { }
