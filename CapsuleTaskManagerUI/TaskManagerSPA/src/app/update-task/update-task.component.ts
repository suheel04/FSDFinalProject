import { Component, OnInit } from '@angular/core';
import { TaskManagerService } from '../shared/task-manager.service';
import { Task } from '../shared/task.model';
import { ActivatedRoute, Router } from '@angular/router';



@Component({
  selector: 'app-update-task',
  templateUrl: './update-task.component.html',
  styleUrls: ['./update-task.component.css'],
  providers: [TaskManagerService]
})
export class UpdateTaskComponent implements OnInit {

    taskToEdit : Task;
    taskList : Task[];

  constructor(
    private taskManagerService : TaskManagerService, 
    private route: ActivatedRoute,
    private router:Router,
    ) { 
    
  }
 
  ngOnInit() {
    const param = this.route.snapshot.paramMap.get('TaskID');
    console.log(param);
    this.taskToEdit = new Task();
    this.taskList = [new Task()];
    this.taskManagerService.getTaskById(Number.parseInt(param)).subscribe(rp=>this.taskToEdit = rp);
    this.taskManagerService.getAllTasks().subscribe(data=>this.taskList=data);
  }
  onClickSubmit(){
    this.taskManagerService.updateTask(this.taskToEdit).subscribe(data=>{
      this.router.navigate(['/viewtask']);
      alert('Task update successfully');
    console.log(data)});
    console.log(this.taskToEdit.StartDate);
  }

}
