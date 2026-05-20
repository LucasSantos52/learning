import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { TaskService } from '@components/task-area/task.service';

@Component({
  standalone: false,
  selector: 'app-new-task',
  templateUrl: './new-task.html',
  styleUrls: ['./new-task.css'],
})
export class NewTask {
  @Input({ required: true }) userId: string = '';
  @Output() close = new EventEmitter<void>();

  enteredTitle: string = '';
  enteredSummary: string = '';
  enteredDueDate: string = '';

  private taskService = inject(TaskService);

  onCancel() {
    this.close.emit();
  }

  onSubmit() {
    this.taskService.addTask(
      {
        title: this.enteredTitle,
        summary: this.enteredSummary,
        dueDate: this.enteredDueDate,
      },
      this.userId,
    );
    this.close.emit();
  }
}
