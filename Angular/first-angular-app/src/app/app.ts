import { Component } from '@angular/core';

import { DUMMY_USERS } from './dummy-users';
import { HeaderComponent, User, TaskArea } from '@components';
import { IUser } from '@models';

@Component({
  selector: 'app-root',
  imports: [HeaderComponent, User, TaskArea],
  templateUrl: './app.html',
  styleUrls: ['./app.css'],
})
export class App {
  users = DUMMY_USERS;
  selectedUser?: IUser;

  onSelectUser(selectedUser: IUser | null) {
    this.selectedUser = selectedUser || undefined;
  }
}
