import { Component, OnInit } from '@angular/core';
import { TaskManagerService } from '../shared/task-manager.service';
import { Task } from '../shared/task.model';
import {User} from '../shared/user.model';
import {Project} from '../shared/project.model'
import { ActivatedRoute, Router } from '@angular/router';
import {UserService} from '../shared/user.service'
import {ProjectService} from '../shared/project.service'

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.css'],
  providers: [TaskManagerService, UserService,ProjectService]
})
export class AddTaskComponent implements OnInit {

  taskToEdit : Task;
  taskList: Task[];
  usersList : User[];
  ProjectList : Project[];

  constructor(private taskManagerService : TaskManagerService,
    private projectService : ProjectService,
    private userService : UserService,
    private route: ActivatedRoute,
    private router:Router,
    ) { 
      this.taskToEdit = new Task();
      
  }

  ngOnInit() {
    
    this.taskList = [new Task()];
    this.usersList = [new User()];
    this.ProjectList = [new Project()];
    this.taskManagerService.getAllTasks().subscribe(data=>this.taskList=data);
    this.userService.getAllUsers().subscribe(data=>this.usersList=data);
    this.projectService.getAllProjects().subscribe(data=>this.ProjectList=data);
    
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
