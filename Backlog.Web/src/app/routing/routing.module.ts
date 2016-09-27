import { Routes, RouterModule } from '@angular/router';

import {
    LandingPageComponent,
    EpicEditPageComponent,
    EpicAddExistingStoriesPageComponent,
    StoryDetailPageComponent,
    StoryEditPageComponent,
    StoryListPageComponent,
    EpicDetailPageComponent,
    DigitalAssetUploadPageComponent,

    AgileTeamEditPageComponent,
    AgileTeamListPageComponent,

    AgileTeamMemberEditPageComponent,
    AgileTeamMemberListPageComponent,

    ReusableStoryGroupEditPageComponent,
    ReusableStoryGroupListPageComponent,

    ProjectEditPageComponent,
    ProjectListPageComponent
} from "../pages";

export const routes: Routes = [
    {
        path: '',
        pathMatch: 'full',
        redirectTo:'epics'
    },
    {
        path: 'epics',
        pathMatch: 'full',
        component: LandingPageComponent
    },
    {
        path: 'epic/:id/addexistingstories',
        pathMatch: 'full',
        component: EpicAddExistingStoriesPageComponent
    },
    {
        path: 'epic/:id',
        pathMatch: 'full',
        component: EpicEditPageComponent
    },
    {
        path: 'epic',
        pathMatch: 'full',
        component: EpicEditPageComponent
    },
    {
        path: 'epic/detail/:id',
        pathMatch: 'full',
        component: EpicDetailPageComponent
    },
    {
        path: 'epic/:epicId/story/:id',
        pathMatch: 'full',
        component: StoryEditPageComponent
    },
    {
        path: 'epic/:epicId/story',
        pathMatch: 'full',
        component: StoryEditPageComponent
    },
    {
        path: 'epic/:epicId/stories',
        pathMatch: 'full',
        component: StoryListPageComponent
    },
    {
        path: 'stories',
        pathMatch: 'full',
        component: StoryListPageComponent
    },
    {
        path: 'story',
        pathMatch: 'full',
        component: StoryEditPageComponent
    },
    {
        path: 'story/:id',
        pathMatch: 'full',
        component: StoryEditPageComponent
    },
    {
        path: 'reusablestorygroups',
        pathMatch: 'full',
        component: ReusableStoryGroupListPageComponent
    },
    {
        path: 'reusablestorygroup',
        pathMatch: 'full',
        component: ReusableStoryGroupEditPageComponent
    },
    {
        path: 'reusablestorygroup/:id',
        pathMatch: 'full',
        component: ReusableStoryGroupEditPageComponent
    },
    {
        path: 'agileteams',
        pathMatch: 'full',
        component: AgileTeamListPageComponent
    },
    {
        path: 'agileteam',
        pathMatch: 'full',
        component: AgileTeamMemberEditPageComponent
    },
    {
        path: 'agileteam/:id',
        pathMatch: 'full',
        component: AgileTeamEditPageComponent
    },

    {
        path: 'projects',
        pathMatch: 'full',
        component: ProjectListPageComponent
    },
    {
        path: 'project',
        pathMatch: 'full',
        component: ProjectEditPageComponent
    },
    {
        path: 'story/:id',
        pathMatch: 'full',
        component: ProjectEditPageComponent
    },
    {
        path: 'story/detail/:id',
        pathMatch: 'full',
        component: StoryDetailPageComponent
    },
    {
        path: 'digitalasset/upload/:id',
        pathMatch: 'full',
        component: DigitalAssetUploadPageComponent
    }
];

export const RoutingModule = RouterModule.forRoot([
    ...routes
]);

export const routedComponents = [
    LandingPageComponent,
    EpicEditPageComponent,
    EpicDetailPageComponent,
    EpicAddExistingStoriesPageComponent,
    StoryEditPageComponent,
    StoryListPageComponent,
    StoryDetailPageComponent,

    DigitalAssetUploadPageComponent,

    ReusableStoryGroupEditPageComponent,
    ReusableStoryGroupListPageComponent,
    ProjectEditPageComponent,
    ProjectListPageComponent,

    AgileTeamEditPageComponent,
    AgileTeamListPageComponent,
    AgileTeamMemberEditPageComponent,
    AgileTeamMemberListPageComponent
];

