import { Routes, RouterModule } from '@angular/router';

import {
    LandingPageComponent,
    EpicEditPageComponent,
    EpicAddExistingStoriesPageComponent,
    StoryDetailPageComponent,
    StoryEditPageComponent,
    StoryListPageComponent,
    EpicDetailPageComponent,
    DigitalAssetUploadPageComponent    
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
        path: 'epic/:id',
        pathMatch: 'full',
        component: EpicEditPageComponent
    },
    {
        path: 'epic/:id/addexistingstories',
        pathMatch: 'full',
        component: EpicAddExistingStoriesPageComponent
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

    DigitalAssetUploadPageComponent
];

