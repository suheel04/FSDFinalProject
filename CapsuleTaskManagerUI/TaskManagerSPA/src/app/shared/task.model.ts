export class Task {
    TaskID : number = 0;
    ParentID ?: number = 0  
    TaskName : string;
    StartDate? : Date;
    EndDate? : Date;
    Priority : number;
    IsCompleted :boolean;
    ParentTaskName : string;    
}
