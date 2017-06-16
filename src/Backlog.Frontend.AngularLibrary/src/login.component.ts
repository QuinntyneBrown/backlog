import { Component, NgModule } from '@angular/core';

@Component({
    selector: 'ce-login',
    template:'<h1>Login</h1>'
})
export class LoginComponent { }

@NgModule({
    declarations: [LoginComponent],
    exports: [LoginComponent]
})
export class LoginModule {}