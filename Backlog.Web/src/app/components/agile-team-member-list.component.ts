import { Component, Input, Output, EventEmitter } from "@angular/core";
import { AgileTeamMember } from "../models";

@Component({
    template: require("./agile-team-member-list.component.html"),
    styles: [require("./agile-team-member-list.component.scss")],
    selector: "agile-team-member-list"
})
export class AgileTeamMemberListComponent {     
    @Input() public entities: Array<AgileTeamMember> = [];
    @Output() onDelete: EventEmitter<{ value: AgileTeamMember }> = new EventEmitter<{ value: AgileTeamMember }>();
    @Output() onSelect: EventEmitter<{ value: AgileTeamMember }> = new EventEmitter<{ value: AgileTeamMember }>();
    @Output() onEdit: EventEmitter<{ value: AgileTeamMember }> = new EventEmitter<{ value: AgileTeamMember }>();
}
