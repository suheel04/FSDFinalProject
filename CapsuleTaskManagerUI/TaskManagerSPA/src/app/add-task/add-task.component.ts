import { Component, OnInit } from '@angular/core';
import { TaskManagerService } from '../shared/task-manager.service';
import { Task } from '../shared/task.model';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.css'],
  providers: [TaskManagerService]
})
export class AddTaskComponent implements OnInit {

  taskToEdit : Task;
  taskList: Task[];

  constructor(private taskManagerService : TaskManagerService,
    private route: ActivatedRoute,
    private router:Router,
    ) { 
      this.taskToEdit = new Task();
      
  }

  ngOnInit() {
    
    this.taskList = [new Task()];
    this.taskManagerService.getAllTasks().subscribe(data=>this.taskList=data);
  }

  onClickSubmit(){
    if(this.taskToEdit.ParentID == 0)
    {
      this.taskToEdit.ParentID = null;
    }
    this.taskManagerService.createTask(this.taskToEdit).subscribe(data=>{
      this.router.navigate(['/viewtask']);
      alert('Task added successfully');
    console.log(data)});
    console.log(this.taskToEdit.StartDate);
    
    
    console.log(this.taskToEdit.StartDate);
  }

}
