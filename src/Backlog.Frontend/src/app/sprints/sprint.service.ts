import { fetch } from "../utilities";
import { Sprint } from "./sprint.model";

export class SprintService {
    constructor(private _fetch = fetch) { }

    private static _instance: SprintService;

    public static get Instance() {
        this._instance = this._instance || new SprintService();
        return this._instance;
    }

    public get(): Promise<Array<Sprint>> {
        return this._fetch({ url: "/api/sprint/get", authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { sprints: Array<Sprint> }).sprints;
        });
    }

    public getById(id): Promise<Sprint> {
        return this._fetch({ url: `/api/sprint/getbyid?id=${id}`, authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { sprint: Sprint }).sprint;
        });
    }

    public add(sprint) {
        return this._fetch({ url: `/api/sprint/add`, method: "POST", data: { sprint }, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return this._fetch({ url: `/api/sprint/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
