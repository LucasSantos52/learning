import { Injectable } from '@angular/core';

import { INewTask } from '@models';
import { DUMMY_TASKS } from '../../dummy-tasks';

@Injectable({ providedIn: 'root' })
export class TaskService {
    private tasks = DUMMY_TASKS;

    constructor() {
        const tasks = localStorage.getItem('tasks');
        if (tasks) {
            this.tasks = JSON.parse(tasks);
        }
    }

    getUsertasks(userId: string) {
        return this.tasks.filter((task) => task.userId === userId);
    }

    addTask(newTask: INewTask, userId: string) {
        this.tasks.unshift({
            id: new Date().getTime().toString(),
            title: newTask.title,
            summary: newTask.summary,
            dueDate: newTask.dueDate,
            userId: userId
        });
        this.saveTasks();
    }

    removeTask(id: string) {
        this.tasks = this.tasks.filter((task) => task.id !== id);
        this.saveTasks();
    }

    private saveTasks(){
        localStorage.setItem('tasks', JSON.stringify(this.tasks));
    }
}