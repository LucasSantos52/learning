import { Component } from '@angular/core';

import { DUMMY_USERS } from './dummy-users';
import { IUser } from '@models';

@Component({
  selector: 'app-root',  
  templateUrl: './app.html',
  styleUrls: ['./app.css'],
  standalone: false
})
export class App {
  users = DUMMY_USERS;
  selectedUser?: IUser;

  onSelectUser(selectedUser: IUser | null) {
    this.selectedUser = selectedUser || undefined;
  }
}
