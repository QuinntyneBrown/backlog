import { Component } from "@angular/core";
import { PopoverService } from "./shared/services/popover.service";

@Component({
    templateUrl: "./app.component.html",
    styleUrls: ["./app.component.css"],
    selector: "app"
})
export class AppComponent {
    constructor(popoverService: PopoverService) { }
}
