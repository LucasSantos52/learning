import { Component, inject, Input } from '@angular/core';

import { ITask } from '@models';
import { TaskService } from '@components/task-area/task.service';

@Component({
  standalone: false,
  selector: 'app-task-item',  
  templateUrl: './task-item.html',
  styleUrls: ['./task-item.css'],
})
export class TaskItem {
  @Input({ required: true }) task!: ITask;
  private taskService = inject(TaskService);

  onCompleteTask() {
    this.taskService.removeTask(this.task.id!);
  }
}
