import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddTaskComponent } from './add-task/add-task.component';
import { ViewTaskComponent } from './view-task/view-task.component';
import { UpdateTaskComponent } from './update-task/update-task.component';

const routes: Routes = [
  {path:'viewtask', component: ViewTaskComponent},
  {path: 'addtask', component: AddTaskComponent},
  {path: 'updatetask/:TaskID', component: UpdateTaskComponent},
  {path: '**', component: ViewTaskComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routeComponent = [ViewTaskComponent, AddTaskComponent, UpdateTaskComponent]
