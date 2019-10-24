import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Project  } from './project.model';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {
  baseURL: string = 'http://localhost:53262/api/ProjectManager/';
  constructor(private http: HttpClient) { }

  getAllProjects():any {
    return this.http.get<Project[]>(this.baseURL + 'GetProject');
  }

  getProjectById(projectID: number): Observable<Project> {  
    return this.http.get<Project>(this.baseURL + 'GetProject/?projectID=' + projectID);  
  }  

  createProject(projectData: Project) {  
    console.log(JSON.stringify(projectData));
    return this.http.post(this.baseURL, projectData);  
  } 

  updateProject(projectData: Project) { 
    return this.http.put(this.baseURL+'UpdateProject/',projectData);  
  }  

  suspendProject(projectID: number) {  
    return this.http.get<Project>(this.baseURL + 'SuspendProject/?suspendProjectID=' + projectID);  
  }  


 
} 

