import { Project } from "./project.model";

export var projectActions = {
    ADD_SUCCESS: "[Project] Add Success",
    DELETE: "[Project] Delete",
    DELETE_SUCCESS: "[Project] Delete Success",
    SELECT: "[Project] Select"
};

export class ProjectDeleteSuccess extends CustomEvent {
    constructor(projectId: any) {
        super(projectActions.DELETE_SUCCESS, {
            detail: {
                projectId: projectId
            }
        });
    }
}

export class ProjectAddSuccess extends CustomEvent {
    constructor(project: Project) {
        super(projectActions.ADD_SUCCESS, {
            detail: {
                project: Project
            }
        });
    }
}

export class ProjectDeleteSelect extends CustomEvent {
    constructor(id: number) {
        super(projectActions.DELETE, {
            detail: {
                projectId: id,
            }
        });
    }
}

export class ProjectEditSelect extends CustomEvent {
    constructor(id: number) {
        super(projectActions.SELECT, {
            detail: {
                projectId: id,
                readonly: false,
            }
        });
    }
}

export class ProjectViewSelect extends CustomEvent {
    constructor(id: number) {
        super(projectActions.SELECT, {
            detail: {
                projectId: id,
                readonly: true
            }
        });
    }
}
