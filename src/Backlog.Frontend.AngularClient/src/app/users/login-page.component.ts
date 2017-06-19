import { Component, Input } from "@angular/core";

@Component({
    templateUrl: "./login-page.component.html",
    styleUrls: ["./login-page.component.css"],
    selector: "ce-login-page",
})
export class LoginPageComponent {
    constructor(
    ) { }

    public tryToLogin($event: { value: { username: string, password: string } }) {

    }
}
