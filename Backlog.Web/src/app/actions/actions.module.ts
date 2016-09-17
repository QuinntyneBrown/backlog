import { NgModule } from '@angular/core';
import { ContentActions } from "./content.actions";
import { EpicActions } from "./epic.actions";
import { StoryActions } from "./story.actions";
import { DigitalAssetActions } from "./digital-asset.actions";
import { HtmlContentActions } from "./html-content.actions";

const providers = [
    ContentActions,
    EpicActions,
    StoryActions,
    DigitalAssetActions,
    HtmlContentActions
];

@NgModule({
	providers: providers
})
export class ActionsModule { }
