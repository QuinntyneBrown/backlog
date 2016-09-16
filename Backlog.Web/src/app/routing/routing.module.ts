import { Routes, RouterModule } from '@angular/router';

import {
    LandingPageComponent,
    EpicEditPageComponent,
    StoryEditPageComponent
    
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
        path: 'story/:id',
        component: StoryEditPageComponent
    },
    {
        path: 'story',
        component: StoryEditPageComponent
    }
];

export const RoutingModule = RouterModule.forRoot([
    ...routes
]);

export const routedComponents = [
    LandingPageComponent,
    EpicEditPageComponent,
    StoryEditPageComponent
];

