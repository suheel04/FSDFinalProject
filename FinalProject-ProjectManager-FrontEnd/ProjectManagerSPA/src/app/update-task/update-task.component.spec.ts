import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateTaskComponent } from './update-task.component';
import { FormsModule } from '@angular/forms';
import { TaskManagerService } from '../shared/task-manager.service';
import {BsDatepickerModule} from 'ngx-bootstrap/datepicker'
import { RouterModule } from '@angular/router';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('UpdateTaskComponent', () => {
  let component: UpdateTaskComponent;
  let fixture: ComponentFixture<UpdateTaskComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [ FormsModule,
        BsDatepickerModule.forRoot(), 
        RouterModule.forRoot([]),
        HttpClientTestingModule
       ],
      declarations: [ UpdateTaskComponent ],
      providers:[TaskManagerService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateTaskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
