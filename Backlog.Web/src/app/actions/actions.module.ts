import { NgModule } from '@angular/core';
import { ContentActions } from "./content.actions";
import { EpicActions } from "./epic.actions";
import { StoryActions } from "./story.actions";
import { DigitalAssetActions } from "./digital-asset.actions";
import { HtmlContentActions } from "./html-content.actions";
import { ReusableStoryGroupActions } from "./reusable-story-group.actions";
import { ProjectActions } from "./project.actions";
import { AgileTeamActions } from "./agile-team.actions";
import { AgileTeamMemberActions } from "./agile-team-member.actions";

const providers = [
    AgileTeamActions,
    AgileTeamMemberActions,
    ContentActions,
    EpicActions,
    StoryActions,
    DigitalAssetActions,
    HtmlContentActions,
    ReusableStoryGroupActions,
    ProjectActions
];

@NgModule({
	providers: providers
})
export class ActionsModule { }
