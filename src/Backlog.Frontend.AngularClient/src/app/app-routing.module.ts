import { Routes, RouterModule } from '@angular/router';
import { LoginModule } from "./login/login.module";
import { AppMasterPageComponent } from "./app-master-page.component";
import { AuthGuardService } from "./shared/services/auth-guard.service";
import { TenantGuardService } from "./tenants/tenant-guard.service";
import { PageNotFoundComponent } from "./page-not-found.component";

const canActivate =  [
    TenantGuardService,
    AuthGuardService
];

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
        path: 'signup',
        canActivate: [
            TenantGuardService
        ],
        loadChildren: "./sign-up/sign-up.module#SignUpModule"
    },
    {
        path: 'dashboard',
        canActivate,
        loadChildren: "./dashboard/dashboard.module#DashboardModule"
    },
    {
        path: '',
        pathMatch:'full',
        loadChildren:"./public/public.module#PublicModule"
        
    },
    {
        path: 'tasks',
        canActivate,
        component: AppMasterPageComponent,
        children: [
            {
                path: '',
                loadChildren: "./tasks/tasks.module#TasksModule"
            }
        ]
    },
    {
        path: 'stories',
        canActivate,
        component: AppMasterPageComponent,
        children: [
            {
                path: '',
                loadChildren: "./stories/stories.module#StoriesModule"
            }
        ]
    },
    {
        path: 'digitalassets',
        canActivate,
        component: AppMasterPageComponent,
        children: [
            {
                path: '',
                loadChildren: "./digital-assets/digital-assets.module#DigitalAssetsModule"
            }
        ]
    },
    {
        path: 'users',
        canActivate,
        component: AppMasterPageComponent,
        children: [
            {
                path: '',
                loadChildren: "./users/users.module#UsersModule"
            }
        ]
    },
    {
        path: 'homepage',
        canActivate,
        component: AppMasterPageComponent,
        children: [
            {
                path: '',
                loadChildren: "./home-pages/home-pages.module#HomePagesModule"
            }
        ]
    }
    , {
        path: '**',
        pathMatch: 'full',
        component: PageNotFoundComponent
    }
];

export const routing = RouterModule.forRoot(routes, { useHash: false });