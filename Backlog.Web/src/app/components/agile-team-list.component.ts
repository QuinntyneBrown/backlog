import { Component, Input, Output, EventEmitter } from "@angular/core";
import { AgileTeam } from "../models";

@Component({
    template: require("./agile-team-list.component.html"),
    styles: [require("./agile-team-list.component.scss")],
    selector: "agile-team-list"
})
export class AgileTeamListComponent {     
    @Input() public entities: Array<AgileTeam> = [];
    @Output() onDelete: EventEmitter<{ value: AgileTeam }> = new EventEmitter<{ value: AgileTeam }>();
    @Output() onSelect: EventEmitter<{ value: AgileTeam }> = new EventEmitter<{ value: AgileTeam }>();
    @Output() onEdit: EventEmitter<{ value: AgileTeam }> = new EventEmitter<{ value: AgileTeam }>();
}
