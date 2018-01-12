import { Routes, RouterModule } from '@angular/router';
import { LoginModule } from "./login/login.module";
import { AppShellComponent } from "./app-shell.component";
import { AuthGuardService } from "./shared/services/auth-guard.service";
import { TenantGuardService } from "./tenants/tenant-guard.service";

export const routes: Routes = [
    {
        path: 'tenants',
        loadChildren: './tenants/tenants.module#TenantsModule'
    },
    {
        path: 'login',
        canActivate: [
            TenantGuardService
        ],
        loadChildren: "./login/login.module#LoginModule"
    },
    {
        path: '',
        canActivate: [
            TenantGuardService,
            AuthGuardService
        ],
        component: AppShellComponent,
        children: [
            { path: '', redirectTo: 'stories', pathMatch: 'full' },
            {
                path: 'tasks',
                loadChildren: "./tasks/tasks.module#TasksModule"
            },
            {
                path: 'stories',
                loadChildren: "./stories/stories.module#StoriesModule"
            }
        ]
    }
];

export const routing = RouterModule.forRoot(routes, { useHash: false });