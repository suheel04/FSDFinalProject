import { Component, OnInit } from '@angular/core';
import {  UserService } from '../shared/user.service';
import { User } from '../shared/user.model';
import {Project} from '../shared/project.model'
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import {ProjectService} from '../shared/project.service'

@Component({
  selector: 'app-add-project',
  templateUrl: './add-project.component.html',
  styleUrls: ['./add-project.component.css'],
  providers: [UserService,ProjectService]
})
export class AddProjectComponent implements OnInit {
  errorMessage = '';
  _projectFilter = '';
  get projectFilter(): string {
    return this._projectFilter;
  }
  set projectFilter(value: string) {
    this._projectFilter = value;
    this.filterdProject = this._projectFilter ? this.performFilter(this._projectFilter) : this.projects;
  }

  projectToAdd : Project;  
  filterdProject: Project[] = [];
  projects: Project[] = [];
  usersList : User[];


  constructor(private userService : UserService,
    private projectService : ProjectService,
    private route: ActivatedRoute,
    private router:Router,
    ) { 
      this.projectToAdd = new Project();
      
  }

  ngOnInit() {    
    this.userService.getAllUsers().subscribe(data=>this.usersList=data);
    this.GetProjects();
  }

  performFilter(filterBy: any): Project[] {
    return this.projects.filter((project: Project) =>
    project.ProjectName.toLocaleLowerCase().indexOf(this._projectFilter) !== -1 );
  }

  GetProjects(){
    this.projectService.getAllProjects().subscribe(
      rp=>
      {debugger;
        this.projects = rp;
        this.filterdProject = rp;
        console.log(this.projects);
      },
      error => this.errorMessage = <any>error
      );
  }
  onClickSubmit(myForm: NgForm){   
    if(this.projectToAdd.ProjectID <= 0)
    {
      alert(this.projectToAdd.UserID);
      this.projectService.createProject(this.projectToAdd).subscribe(data=>{
        this.GetProjects();     
        alert('Project added successfully');
        this.projectToAdd = new Project();
        myForm.resetForm();
      });
    }  
    else{
      this.projectService.updateProject(this.projectToAdd).subscribe(data=>{
        this.GetProjects();
        alert('Project updated successfully');
        this.projectToAdd = new Project();       
        myForm.resetForm();
    });  
    
  }
}

onSetDateChecked(ev: any){
  if(ev.target.checked){
    this.projectToAdd.StartDate = new Date();
    this.projectToAdd.EndDate = new Date();
    this.projectToAdd.EndDate.setDate(this.projectToAdd.EndDate.getDate()+1);
  }
  else
  {
    this.projectToAdd.StartDate =null;
    this.projectToAdd.EndDate =null;
  }
}
  onSort(id: number){   
    switch (id) {
      case 1:
          this.filterdProject = this.filterdProject.sort((x,y)=> 
            {return new Date(x.StartDate).getTime() - new Date(y.StartDate).getTime()})
        break;
      case 2:
          this.filterdProject = this.filterdProject.sort((x,y)=> 
            {return new Date(x.EndDate).getTime() - new Date(y.EndDate).getTime()})
        break;
      case 3:
          this.filterdProject = this.filterdProject.sort((x,y)=>x.Priority-y.Priority);
        break;    
      case 4:
          this.filterdProject = this.filterdProject.sort((x,y)=>x.IsComplete?1:-1);
        break;    
      default:
        break;
    }
  }

  Edit(editProject: Project){   
    this.projectToAdd =editProject;
  }

  Suspend(SuspendProject: Project){   
    this.projectService.suspendProject(SuspendProject.ProjectID).subscribe(data=>{
      this.GetProjects();
       alert('Project Suspended');
    });
  }
  
  Reset(myForm: NgForm)
  {
    this.GetProjects();
    this.projectToAdd= new Project();
    myForm.resetForm();
  }
    

}
