import { Component, Input } from '@angular/core';
import { ITask, IUser } from '../../models';
import { TaskItem } from '../task-item/task-item';
import { DUMMY_TASKS } from '../../dummy-tasks';
import { NewTask } from "../new-task/new-task";

@Component({
  selector: 'app-task-area',
  imports: [TaskItem, NewTask],
  templateUrl: './task-area.html',
  styleUrl: './task-area.css',
})
export class TaskArea {
  @Input({ required: true }) user: IUser | null = null;

  tasks: ITask[] = DUMMY_TASKS;

  get selectedUserTasks() {
    return this.tasks.filter((task) => task.userId === this.user?.id);
  }

  onCompleteTask(id: string) {
    this.tasks = this.tasks.filter((task) => task.id !== id);
  }

  addNewTask(task: ITask) {
    this.tasks = [...this.tasks, task];
  }
}
