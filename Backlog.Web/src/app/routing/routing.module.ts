import { Routes, RouterModule } from '@angular/router';

import {
    LandingPageComponent,
    EpicEditPageComponent,
    StoryEditPageComponent,
    StoryListPageComponent
    
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
        path: 'epic',
        pathMatch: 'full',
        component: EpicEditPageComponent
    },
    {
        path: 'epic/:epicId/story/:storyId',
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
    }
];

export const RoutingModule = RouterModule.forRoot([
    ...routes
]);

export const routedComponents = [
    LandingPageComponent,
    EpicEditPageComponent,
    StoryEditPageComponent,
    StoryListPageComponent
];

