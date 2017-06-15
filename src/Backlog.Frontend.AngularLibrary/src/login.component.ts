import { Component, NgModule } from '@angular/core';

@Component({
    selector: 'ce-login',
    templateUrl: ".\login.component.html"
})
export class LoginComponent { }

@NgModule({
    declarations: [LoginComponent],
    exports: [LoginComponent]
})
export class LoginModule {
}