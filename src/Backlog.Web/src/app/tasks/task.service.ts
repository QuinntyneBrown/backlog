import { fetch } from "../utilities";
import { Task } from "./task.model";

export class TaskService {
    
    private static _instance: TaskService;

    public static get Instance() {
        this._instance = this._instance || new this();
        return this._instance;
    }

    public get() {
        return fetch({ url: "/api/task/get", authRequired: true });
    }

    public getTaskStatuses() {
        return fetch({ url: "/api/task/gettaskstatuses", authRequired: true });
    }

    public getByStoryId(storyid) {
        return fetch({ url: `api/task/getbystoryid?storyid=${storyid}`, authRequired: true });
    }

    public getById(id) {
        return fetch({ url: `/api/task/getbyid?id=${id}`, authRequired: true });
    }

    public add(entity) {
        return fetch({ url: `/api/task/add`, method: "POST", data: entity, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return fetch({ url: `/api/task/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
