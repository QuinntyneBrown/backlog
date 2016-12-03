import { TaskStatus } from "./task-status.model";

export class Task { 
    public id: number;
    public taskStatusId: number;
    public storyId: number;
    public name: string = "";
    public description: string = "";
    public startDate: string;    
    public completedDate: string;
    public taskStatus: TaskStatus;
}
