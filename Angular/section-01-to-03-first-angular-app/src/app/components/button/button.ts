import { Component } from '@angular/core';

@Component({
  standalone: false,
  selector: 'button[appButton]',  
  template: '<ng-content />',
  styleUrls: ['./button.css'],
})
export class Button {}
