import { Component, EventEmitter, input, Output } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormControl } from '@angular/forms';

import { ITask } from '../../models/ITask';

@Component({
  selector: 'app-new-task',
  imports: [ReactiveFormsModule],
  templateUrl: './new-task.html',
  styleUrl: './new-task.css',
})
export class NewTask {
  visible = input.required<boolean>();
  @Output() addNew = new EventEmitter<ITask>();
  
  form = new FormGroup({
    title: new FormControl(''),
    summary: new FormControl(''),
    dueDate: new FormControl(''),
  });
  
  onAddTask() {
    console.log(this.form.value);
    //this.addNew.emit(task);
  }

}
