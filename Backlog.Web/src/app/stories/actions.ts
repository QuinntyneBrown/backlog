import { Story } from "./story.model";

export var storyActions = {
    ADD_SUCCESS: "[Story] Add Success",
    DELETE: "[Story] Delete",
    DELETE_SUCCESS: "[Story] Delete Success",
    SELECT: "[Story] Select"
};

export class StoryDeleteSuccess extends CustomEvent {
    constructor(storyId: any) {
        super(storyActions.DELETE_SUCCESS, {
            detail: {
                storyId: storyId
            }
        });
    }
}

export class StoryAddSuccess extends CustomEvent {
    constructor(story: Story) {
        super(storyActions.ADD_SUCCESS, {
            detail: {
                story: Story
            }
        });
    }
}

export class StoryDeleteSelect extends CustomEvent {
    constructor(id: number) {
        super(storyActions.DELETE, {
            detail: {
                storyId: id,
            }
        });
    }
}

export class StoryEditSelect extends CustomEvent {
    constructor(id: number) {
        super(storyActions.SELECT, {
            detail: {
                storyId: id,
                readonly: false,
            }
        });
    }
}

export class StoryViewSelect extends CustomEvent {
    constructor(id: number) {
        super(storyActions.SELECT, {
            detail: {
                storyId: id,
                readonly: true
            }
        });
    }
}
