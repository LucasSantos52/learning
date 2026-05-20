import { NgModule } from "@angular/core";
import { Button } from "./button/button";
import { NewTask } from "./new-task/new-task";
import { TaskArea } from "./task-area/task-area";
import { TaskItem } from "./task-item/task-item";
import { User } from "./user/user";
import { HeaderComponent } from "./header/header";
import { SharedModule } from "../shared/shared.module";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";

@NgModule({
    declarations: [Button, HeaderComponent, NewTask, TaskArea, TaskItem, User],
    exports: [Button, HeaderComponent, TaskArea, User],
    imports: [CommonModule, FormsModule,SharedModule]
})
export class ComponentsModule {}