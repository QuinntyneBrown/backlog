export class Story { 
    public id: number;
    public epicId: number;
    public completedDate: string;
    public name: string;
    public priority: string;
    public points: string;
    public architecturePoints: string;
    public description: string; 
    public notes: string;
    public digitalAssets: Array<any> = [];
}
