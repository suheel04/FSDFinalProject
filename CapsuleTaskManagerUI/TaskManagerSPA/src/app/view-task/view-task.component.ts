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

  _ParentTaskFilter = '';
  get ParentTaskFilter(): string {
    return this._ParentTaskFilter;
  }
  set ParentTaskFilter(value: string) {
    this._ParentTaskFilter = value;
    this.filteredTasks = this._ParentTaskFilter ? this.performFilter(this._ParentTaskFilter) : this.tasks;
  }

  _PriorityFrom;
  get PriorityFromFilter (): number {
    return this._PriorityFrom;
  }
  set PriorityFromFilter(value: number) {
    this._PriorityFrom = value;
    this.filteredTasks = this._PriorityFrom ? this.performFilter(this._PriorityFrom) : this.tasks;
  }

  _PriorityTo;
  get PriorityToFilter (): number {
    return this._PriorityTo;
  }
  set PriorityToFilter(value: number) {
    this._PriorityTo = value;
    this.filteredTasks = this._PriorityTo ? this.performFilter(this._PriorityTo) : this.tasks;
  }

  _StartDateFilter: Date;
  get StartDateFilter (): Date {
    return this._StartDateFilter;
  }
  set StartDateFilter(value: Date) {
    this._StartDateFilter = value;
    this.filteredTasks = this._StartDateFilter ? this.performFilter(this._StartDateFilter) : this.tasks;
  }

  _EndDateFilter;
  get EndDateFilter (): number {
    return this._EndDateFilter;
  }
  set EndDateFilter(value: number) {
    this._EndDateFilter = value;
    this.filteredTasks = this._EndDateFilter ? this.performFilter(this._EndDateFilter) : this.tasks;
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
      {
        //this.tasks = rp;
       //this.filteredTasks = rp;  
       this.tasks = rp.filter( function (e1) {
        return e1.TaskID != null;
      });
        this.filteredTasks = rp.filter( function (e1) {
          return e1.TaskID != null;
        });
      },
      error => this.errorMessage = <any>error
      );
  }

  performFilter(filterBy: any): Task[] {
    filterBy = filterBy.toLocaleLowerCase();
   
    let sDate = new Date(this._StartDateFilter);
    let eDate = new Date(this._EndDateFilter);  

    return this.filteredTasks.filter((task: Task) =>
    task && task.TaskName.toLocaleLowerCase().indexOf(this._taskFilter) !== -1 
    && task.ParentTaskName.toLocaleLowerCase().indexOf(this._ParentTaskFilter) !== -1
    && (this._PriorityFrom == null || task.Priority >= this._PriorityFrom)
    && (this._PriorityTo == null || task.Priority <= this._PriorityTo)   
    && (this._StartDateFilter == null || 
        (
          new Date(task.StartDate).getDay() == sDate.getDay()
           && new Date(task.StartDate).getMonth() == sDate.getMonth()
           && new Date(task.StartDate).getFullYear() == sDate.getFullYear()
        )
      )
      && (this._EndDateFilter == null || 
        (
          new Date(task.EndDate).getDay() == eDate.getDay()
          && new Date(task.EndDate).getMonth() == eDate.getMonth()
          && new Date(task.EndDate).getFullYear() == eDate.getFullYear()
        )
      )
    
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

  // taskSearch(){
  //   if(this.taskFilter != ''){
  //   this.filteredTasks = this.filteredTasks.filter(res => {
  //   return res.TaskName.toLocaleLowerCase().match(this.taskFilter.toLocaleLowerCase());
  //   });
  // }
  // else{
  //   return this.filteredTasks = this.filteredTasks.filter(res => res.TaskID  != null);
  // }
  // }

}
