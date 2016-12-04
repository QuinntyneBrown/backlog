import { fetch } from "../utilities";
import { KanbanBoard } from "./kanban-board.model";

export class KanbanBoardService {
    
    private static _instance: KanbanBoardService;

    public static get Instance() {
        this._instance = this._instance || new this();
        return this._instance;
    }

    public get() {
        return fetch({ url: "/api/kanban-board/get", authRequired: true });
    }    
}
