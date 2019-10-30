import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Task } from './task.model';

@Injectable({
  providedIn: 'root'
})
export class TaskManagerService {
  
  controllerRoute: string = 'http://localhost:5500/api/TaskManager/';
  tasks: Observable<Task[]>;
  constructor(private http: HttpClient) { }
  
  getAllTasks():any {
    return this.http.get<Task[]>(this.controllerRoute + 'GetTask');
  }

  getTaskById(taskId: number): Observable<Task> {  
    return this.http.get<Task>(this.controllerRoute + 'GetTask/?taskID=' + taskId);  
  }  

  createTask(taskEntity: Task) {  
    debugger;
    return this.http.post("http://localhost:5500/api/TaskManager/TaskEntity", taskEntity);  
  } 

  updateTask(taskData: Task) {  
    console.log(taskData.TaskID);
   
    return this.http.put(this.controllerRoute+'UpdateTask/',taskData);  
  }  

  endTask(taskId: number) {  
    console.log("ending task");
    return this.http.delete(this.controllerRoute + 'EndTask/?ID=' + taskId);  
  } 

  Delete(taskId: number) {  
    console.log("Delete task");
    return this.http.get(this.controllerRoute + 'DeleteTask/?deleteID=' + taskId);  
  } 

}
