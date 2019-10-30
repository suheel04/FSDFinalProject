import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddTaskComponent } from './add-task.component';
import { FormsModule } from '@angular/forms';
import { TaskManagerService } from '../shared/task-manager.service';
import {BsDatepickerModule} from 'ngx-bootstrap/datepicker'
import { RouterModule } from '@angular/router';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('AddTaskComponent', () => {
  let component: AddTaskComponent;
  let fixture: ComponentFixture<AddTaskComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [ FormsModule,
         BsDatepickerModule.forRoot(), 
         RouterModule.forRoot([]),
         HttpClientTestingModule
        ],
      declarations: [ AddTaskComponent ],
      providers:[TaskManagerService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddTaskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
