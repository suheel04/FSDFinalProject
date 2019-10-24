import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Task } from './task.model';

@Injectable({
  providedIn: 'root'
})
export class TaskManagerService {
  
  baseURL: string = 'http://localhost:53262/api/TaskManager/';
  tasks: Observable<Task[]>;
  constructor(private http: HttpClient) { }
  
  getAllTasks():any {
    return this.http.get<Task[]>(this.baseURL + 'GetTask');
  }

  getTaskById(taskId: number): Observable<Task> {  
    return this.http.get<Task>(this.baseURL + 'GetTask/?taskID=' + taskId);  
  }  

  createTask(taskData: Task) {  
    console.log(JSON.stringify(taskData));
    return this.http.post(this.baseURL, taskData);  
  } 

  updateTask(taskData: Task) {  
    console.log(taskData.TaskID);
   
    return this.http.put(this.baseURL+'UpdateTask/',taskData);  
  }  

  endTask(taskId: number) {  
    console.log("ending task");
    return this.http.delete(this.baseURL + 'EndTask/?ID=' + taskId);  
  } 

  Delete(taskId: number) {  
    console.log("Delete task");
    return this.http.get(this.baseURL + 'DeleteTask/?deleteID=' + taskId);  
  } 

}
