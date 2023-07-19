import { Component } from '@angular/core';

export interface Word {
  key: string;
  title: string;
  desc: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Aspose Word';
}
