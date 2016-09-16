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
        component: LandingPageComponent
    },
    {
        path:'epic/:id',
        component: EpicEditPageComponent
    },
    {
        path: 'epic',
        pathMatch: 'full',
        component: EpicEditPageComponent
    },
    {
        path: 'epic/:epicId/story/:storyId',
        component: StoryEditPageComponent
    },
    {
        path: 'epic/:epicId/story',
        component: StoryEditPageComponent
    },
    {
        path: 'epic/:epicId/stories',
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

