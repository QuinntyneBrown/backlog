import { Task } from "./task.model";

export var taskActions = {
    ADD: "[Task] Add",
    ADD_SUCCESS: "[Task] Add Success",
    DELETE: "[Task] Delete",
    DELETE_SUCCESS: "[Task] Delete Success",
    EDIT: "[Task] Edit",
    EDIT_SUCCESS: "[Task] Edit Success",
    VIEW: "[Task] Edit",
    VIEW_SUCCESS: "[Task] View Success",
    SELECT: "[Task] Select"
};

export class TaskDelete extends CustomEvent {
    constructor(id: number) {
        super(taskActions.DELETE, {
            detail: {
                taskId: id,
            },
            bubbles: true
        });
    }
}

export class TaskDeleteSuccess extends CustomEvent {
    constructor(taskId: any) {
        super(taskActions.DELETE_SUCCESS, {
            detail: {
                taskId: taskId
            },
            bubbles: true
        });
    }
}

export class TaskAdd extends CustomEvent {
    constructor(task: Task) {
        super(taskActions.ADD, {
            detail: { task },
            bubbles:true
        });
    }
}

export class TaskAddSuccess extends CustomEvent {
    constructor(task: Task) {
        super(taskActions.ADD_SUCCESS, {
            detail: {
                task: Task
            },
            bubbles: true
        });
    }
}

export class TaskEdit extends CustomEvent {
    constructor(id: number) {
        super(taskActions.EDIT, {
            detail: {
                taskId: id,
                readonly: false,
            },
            bubbles: true
        });
    }
}


export class TaskView extends CustomEvent {
    constructor(id: number) {
        super(taskActions.VIEW, {
            detail: {
                taskId: id,
                readonly: true
            },
            bubbles: true
        });
    }
}
