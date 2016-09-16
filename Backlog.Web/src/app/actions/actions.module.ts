import { NgModule } from '@angular/core';
import { ContentActions } from "./content.actions";
import { EpicActions } from "./epic.actions";
import { StoryActions } from "./story.actions";

const providers = [
    ContentActions,
    EpicActions,
    StoryActions
];

@NgModule({
	providers: providers
})
export class ActionsModule { }
