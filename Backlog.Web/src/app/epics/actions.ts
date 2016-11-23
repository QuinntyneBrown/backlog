import { Epic } from "./epic.model";

export var epicActions = {
    ADD_SUCCESS: "[Epic] Add Success",
    DELETE: "[Epic] Delete",
    DELETE_SUCCESS: "[Epic] Delete Success",
    SELECT: "[Epic] Select"
};

export class EpicDeleteSuccess extends CustomEvent {
    constructor(epicId: any) {
        super(epicActions.DELETE_SUCCESS, {
            detail: {
                epicId: epicId
            }
        });
    }
}

export class EpicAddSuccess extends CustomEvent {
    constructor(epic: Epic) {
        super(epicActions.ADD_SUCCESS, {
            detail: {
                epic: Epic
            }
        });
    }
}

export class EpicDeleteSelect extends CustomEvent {
    constructor(id: number) {
        super(epicActions.DELETE, {
            detail: {
                epicId: id,
            }
        });
    }
}

export class EpicEditSelect extends CustomEvent {
    constructor(id: number) {
        super(epicActions.SELECT, {
            detail: {
                epicId: id,
                readonly: false,
            }
        });
    }
}

export class EpicViewSelect extends CustomEvent {
    constructor(id: number) {
        super(epicActions.SELECT, {
            detail: {
                epicId: id,
                readonly: true
            }
        });
    }
}
