import { fetch } from "../utilities";
import { Story } from "./story.model";

export class StoryService {
    constructor(private _fetch = fetch) { }

    private static _instance: StoryService;

    public static get Instance() {
        this._instance = this._instance || new StoryService();
        return this._instance;
    }

    public get(): Promise<Array<Story>> {
        return this._fetch({ url: "/api/stories/get", authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { stories: Array<Story> }).stories;
        });
    }

    public getById(id): Promise<Story> {
        return this._fetch({ url: `/api/stories/getbyid?id=${id}`, authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { story: Story }).story;
        });
    }

    public add(story) {
        return this._fetch({ url: `/api/stories/add`, method: "POST", data: { story }, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return this._fetch({ url: `/api/stories/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }

    public removeDigitalAsset(options: { id: number }) {
        return this._fetch({ url: `/api/digitalassets/remove?id=${options.id}`, method: "DELETE", authRequired: true });
    }
}
