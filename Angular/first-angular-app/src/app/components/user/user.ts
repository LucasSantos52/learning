import { Component, EventEmitter, Input, Output, computed, input, output } from '@angular/core';
import { IUser } from '../../models';

@Component({
  selector: 'app-user',
  imports: [],
  templateUrl: './user.html',
  styleUrls: ['./user.css'],
})
export class User {
  @Input({ required: true }) user: IUser | null = null;
  selected = input.required<boolean>();
  @Output() selectUser = new EventEmitter<string>();

  get imagePath() {
    return this.user ? 'users/' + this.user.avatar : '';
  }

  onSelectUser() {
    if (this.user) {
      this.selectUser.emit(this.user.id);
    }
  }
}



// using signals - usando signals

// import { Component, signal, computed } from '@angular/core';

// import { DUMMY_USERS } from '../../dummy-users';

// @Component({
//   selector: 'app-user',
//   imports: [],
//   templateUrl: './user.html',
//   styleUrls: ['./user.css'],
// })
// export class User {
//   selectedUser = signal(DUMMY_USERS[0]);

  // avatar = input.required<string>();
  // name = input.required<string>();
  // selectUser = output<string>();

  // imagePath = computed(() => 'users/' + this.avatar());

//   imagePath = computed(() => 'users/' + this.selectedUser().avatar);

//   // get imagePath() {
//   //   return 'users/' + this.selectedUser.avatar;
//   // }

//   onSelectUser() {
//     const randomIndex = Math.floor(Math.random() * DUMMY_USERS.length);
//     this.selectedUser.set(DUMMY_USERS[randomIndex]);
//   }
// }
