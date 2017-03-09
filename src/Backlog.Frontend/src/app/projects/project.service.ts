import { fetch } from "../utilities";
import { Project } from "./project.model";

export class ProjectService {
    constructor(private _fetch = fetch) { }

    private static _instance: ProjectService;

    public static get Instance() {
        this._instance = this._instance || new ProjectService();
        return this._instance;
    }

    public get(): Promise<Array<Project>> {
        return this._fetch({ url: "/api/project/get", authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { projects: Array<Project> }).projects;
        });
    }

    public getById(id): Promise<Project> {
        return this._fetch({ url: `/api/project/getbyid?id=${id}`, authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { project: Project }).project;
        });
    }

    public add(project) {
        return this._fetch({ url: `/api/project/add`, method: "POST", data: { project }, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return this._fetch({ url: `/api/project/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
