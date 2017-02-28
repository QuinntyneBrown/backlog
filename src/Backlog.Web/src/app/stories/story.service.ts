import { fetch } from "../utilities";
import { Story } from "./story.model";

export class StoryService {
    
    private static _instance: StoryService;

    public static get Instance() {
        this._instance = this._instance || new StoryService();
        return this._instance;
    }

    public get() {
        return fetch({ url: "/api/story/get" });
    }

    public getById(id) {
        return fetch({ url: `/api/story/getbyid?id=${id}`, authRequired: true });
    }

    public add(story) {
        return fetch({ url: `/api/story/add`, method: "POST", data: { story }, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return fetch({ url: `/api/story/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }

    public removeDigitalAsset(options: { id: number }) {
        return fetch({ url: `/api/digitalasset/remove?id=${options.id}`, method: "DELETE", authRequired: true });
    }
    
}
