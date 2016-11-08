import { fetch } from "../utilities";
import { Project } from "./project.model";

export class ProjectService {
    
    private static _instance: ProjectService;

    public static get Instance() {
        this._instance = this._instance || new ProjectService();
        return this._instance;
    }

    public get() {
        return fetch({ url: "/api/project/get", authRequired: true });
    }

    public getById(id) {
        return fetch({ url: `/api/project/getbyid?id=${id}`, authRequired: true });
    }

    public add(entity) {
        return fetch({ url: `/api/project/add`, method: "POST", data: entity, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return fetch({ url: `/api/project/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
