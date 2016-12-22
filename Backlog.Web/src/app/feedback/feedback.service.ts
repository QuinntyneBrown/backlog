import { fetch } from "../utilities";
import { Feedback } from "./feedback.model";

export class FeedbackService {
    
    private static _instance: FeedbackService;

    public static get Instance() {
        this._instance = this._instance || new FeedbackService();
        return this._instance;
    }

    public get(options: { username:string }) {
        return fetch({ url: `/api/feedback/getbyusername?username=${options.username}`, authRequired: true });
    }

    public getById(id) {
        return fetch({ url: `/api/feedback/getbyid?id=${id}`, authRequired: true });
    }

    public add(entity) {
        return fetch({ url: `/api/feedback/add`, method: "POST", data: entity, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return fetch({ url: `/api/feedback/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
