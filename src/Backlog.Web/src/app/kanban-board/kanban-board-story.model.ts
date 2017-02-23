import { KanbanBoardTask } from "./kanban-board-task.model";

export class KanbanBoardStory { 
	public id:number;
    public name: string;
    public description: string;
    public tasks: Array<KanbanBoardTask> = [];
}
