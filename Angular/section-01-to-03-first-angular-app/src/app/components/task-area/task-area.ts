import { Component, Input } from '@angular/core';

import { IUser } from '../../models';
import { TaskService } from "./task.service";

@Component({
  standalone: false,
  selector: 'app-task-area',  
  templateUrl: './task-area.html',
  styleUrl: './task-area.css',
})
export class TaskArea {
  @Input({ required: true }) user: IUser | null = null;
  isAddingTask = false;

  constructor(private taskService: TaskService) {}
 
  get selectedUserTasks() {
    return this.taskService.getUsertasks(this.user!.id);
  }

  onStartAddTask() {
    this.isAddingTask = true;
  }

  onCloseAddTask() {
    this.isAddingTask = false;
  }
}
