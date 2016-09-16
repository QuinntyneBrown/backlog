import { NgModule } from '@angular/core';
import { EpicActions } from "./epic.actions";
import { StoryActions } from "./story.actions";

const providers = [EpicActions, StoryActions];

@NgModule({
	providers: providers
})
export class ActionsModule { }
