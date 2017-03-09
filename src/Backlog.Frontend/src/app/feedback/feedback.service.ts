import { fetch } from "../utilities";
import { Feedback } from "./feedback.model";

export class FeedbackService {
    constructor(private _fetch = fetch) { }

    private static _instance: FeedbackService;

    public static get Instance() {
        this._instance = this._instance || new FeedbackService();
        return this._instance;
    }

    public get(options: { username: string }): Promise<Array<Feedback>> {
        return fetch({ url: `/api/feedback/getbyusername?username=${options.username}`, authRequired: true }).then((results: string) => {
            return (JSON.parse(results) as { feedbacks: Array<Feedback> }).feedbacks;
        });
    }

    public getById(id): Promise<Feedback> {
        return this._fetch({ url: `/api/feedback/getbyid?id=${id}`, authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { feedback: Feedback }).feedback;
        });
    }

    public add(feedback) {
        return this._fetch({ url: `/api/feedback/add`, method: "POST", data: { feedback }, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return this._fetch({ url: `/api/feedback/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
