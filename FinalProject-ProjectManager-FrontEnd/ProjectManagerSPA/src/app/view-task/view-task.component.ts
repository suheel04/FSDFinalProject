import { Component, OnInit } from '@angular/core';
import { TaskManagerService } from '../shared/task-manager.service';
import { Task } from '../shared/task.model';
import { ActivatedRoute, Router } from '@angular/router';



@Component({
  selector: 'app-view-task',
  templateUrl: './view-task.component.html',
  styleUrls: ['./view-task.component.css'],
  providers: [TaskManagerService]
})
export class ViewTaskComponent implements OnInit {  

  errorMessage = '';
  _taskFilter = '';
  get taskFilter(): string {
    return this._taskFilter;
  }
  set taskFilter(value: string) {
    this._taskFilter = value;
    this.filteredTasks = this._taskFilter ? this.performFilter(this._taskFilter) : this.tasks;
  }
 
  filteredTasks: Task[] = [];
  tasks: Task[] = [];

  constructor(private taskManagerService : TaskManagerService,
    private route: ActivatedRoute,
    private router:Router,) { }

  ngOnInit() {

    this.GetTasks();
  }

  GetTasks(){
    this.taskManagerService.getAllTasks().subscribe(
      rp=>
      {debugger;
        this.tasks = rp;
        this.filteredTasks = rp;
        console.log(this.filteredTasks);
      },
      error => {debugger;this.errorMessage = <any>error}
      );
  }

  performFilter(filterBy: any): Task[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.tasks.filter((task: Task) =>
    task.ProjectName.toLocaleLowerCase().indexOf(this._taskFilter) !== -1    
    
     
    );
  }

  EndTask(taskToEnd : Task) : void{
    this.taskManagerService.endTask(taskToEnd.TaskID).subscribe(data=>{
     alert('Task ended successfully');
     this.GetTasks();
     this.performFilter('update');
    console.log(data)});
    
  } 

  Delete(taskToEnd : Task) : void{
    this.taskManagerService.Delete(taskToEnd.TaskID).subscribe(data=>{
     alert('Task ended successfully');
     this.GetTasks();
     this.performFilter('update');
    console.log(data)});
    
  } 

  onSort(id: number){   
    switch (id) {
      case 1:
        this.filteredTasks = this.filteredTasks.sort((x,y)=> {return new Date(x.StartDate).getTime() - new 
          Date(y.StartDate).getTime()})
        break;
      case 2:
      this.filteredTasks = this.filteredTasks.sort((x,y)=> this.sortDate(x.EndDate,y.EndDate));
        break;
      case 3:
      this.filteredTasks = this.filteredTasks.sort((x,y)=>x.Priority-y.Priority);
        break;   
      case 4:
      this.filteredTasks = this.filteredTasks.sort((x,y)=>x.IsCompleted?1:-1);
        break; 
      default:
        break;
    }
  }

  sortDate(x: Date, y: Date)
  {
   
    
    return new Date(x).getTime() - new Date(y).getTime()
  }

}
