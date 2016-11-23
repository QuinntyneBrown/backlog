import { User } from "./user.model";

export var userActions = {
    ADD_SUCCESS: "[User] Add Success",
    DELETE: "[User] Delete",
    DELETE_SUCCESS: "[User] Delete Success",
    SELECT: "[User] Select",
    LOGIN_SUCCESS: "[User] Login Success"
};

export class UserLoginSuccess extends CustomEvent {
    constructor(public accessToken) {
        super(userActions.LOGIN_SUCCESS, {
            detail: {
                accessToken: accessToken
            }
        });
    }
}

export class UserDeleteSuccess extends CustomEvent {
    constructor(userId: any) {
        super(userActions.DELETE_SUCCESS, {
            detail: {
                userId: userId
            }
        });
    }
}

export class UserAddSuccess extends CustomEvent {
    constructor(user: User) {
        super(userActions.ADD_SUCCESS, {
            detail: {
                user: User
            }
        });
    }
}

export class UserDeleteSelect extends CustomEvent {
    constructor(id: number) {
        super(userActions.DELETE, {
            detail: {
                userId: id,
            }
        });
    }
}

export class UserEditSelect extends CustomEvent {
    constructor(id: number) {
        super(userActions.SELECT, {
            detail: {
                userId: id,
                readonly: false,
            }
        });
    }
}

export class UserViewSelect extends CustomEvent {
    constructor(id: number) {
        super(userActions.SELECT, {
            detail: {
                userId: id,
                readonly: true
            }
        });
    }
}
