import { FunctionUtility } from '../app/_core/function.utility';
import { Component } from '@angular/core';
import { AsposewordService } from './_core/asposeword.service';
import { SpinnerService } from './_core/spinner.service';
import { SweetAlertService } from './_core/sweet-alert.service';
import { Asposeword } from './_core/model/asposeword';

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
  constructor(
  ) { }

}


