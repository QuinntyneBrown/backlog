import { Article } from "./article.model";

export var articleActions = {
    ADD_SUCCESS: "[Article] Add Success",
    DELETE: "[Article] Delete",
    DELETE_SUCCESS: "[Article] Delete Success",
    SELECT: "[Article] Select"
};

export class ArticleDeleteSuccess extends CustomEvent {
    constructor(articleId: any) {
        super(articleActions.DELETE_SUCCESS, {
            detail: {
                articleId: articleId
            }
        });
    }
}

export class ArticleAddSuccess extends CustomEvent {
    constructor(article: Article) {
        super(articleActions.ADD_SUCCESS, {
            detail: {
                article: Article
            }
        });
    }
}

export class ArticleDeleteSelect extends CustomEvent {
    constructor(id: number) {
        super(articleActions.DELETE, {
            detail: {
                articleId: id,
            }
        });
    }
}

export class ArticleEditSelect extends CustomEvent {
    constructor(id: number) {
        super(articleActions.SELECT, {
            detail: {
                articleId: id,
                readonly: false,
            }
        });
    }
}

export class ArticleViewSelect extends CustomEvent {
    constructor(id: number) {
        super(articleActions.SELECT, {
            detail: {
                articleId: id,
                readonly: true
            }
        });
    }
}
