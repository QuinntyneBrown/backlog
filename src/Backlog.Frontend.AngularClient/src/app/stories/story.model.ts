import { Task } from "../tasks/task.model";

export type Story = { 
    id:any;    
    name: string;
    description: string;
    slug: string;
    acceptanceCriteria: string;
    points: number;
    completedDate: Date;
    startDate: Date;
    tasks: Array<Partial<Task>>;
}
