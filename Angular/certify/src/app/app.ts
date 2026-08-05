import { Component, signal } from '@angular/core';
import { Canvas } from "./components";

@Component({
  selector: 'app-root',
  imports: [Canvas],
  templateUrl: './app.html',
  styleUrls: ['./app.scss']
})
export class App {
  protected readonly title = signal('certify');
}
