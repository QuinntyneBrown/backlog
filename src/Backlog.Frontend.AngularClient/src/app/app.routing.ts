import { Routes, RouterModule } from '@angular/router';
import { HomePageComponent } from "./home";

export const routes: Routes = [
    {
        path: '',
        pathMatch: 'full',
        component: HomePageComponent
    }
];

export const routing = RouterModule.forRoot(routes, { useHash: false });