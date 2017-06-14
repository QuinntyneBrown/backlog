import { Routes, RouterModule } from '@angular/router';
import { LeadComponent } from "./leads";

export const routes: Routes = [
    {
        path: '',
        pathMatch: 'full',
        component: LeadComponent,
    }
];

export const routing = RouterModule.forRoot(routes, { useHash: false });