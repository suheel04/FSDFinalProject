import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewTaskComponent } from './view-task.component';
import { FormsModule } from '@angular/forms';
import { TaskManagerService } from '../shared/task-manager.service';
import {BsDatepickerModule} from 'ngx-bootstrap/datepicker'
import { RouterModule } from '@angular/router';
import { HttpClientTestingModule } from '@angular/common/http/testing';
describe('ViewTaskComponent', () => {
  let component: ViewTaskComponent;
  let fixture: ComponentFixture<ViewTaskComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [ FormsModule,
        BsDatepickerModule.forRoot(), 
        RouterModule.forRoot([]),
        HttpClientTestingModule
       ],
      declarations: [ ViewTaskComponent ],
      providers:[TaskManagerService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewTaskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
