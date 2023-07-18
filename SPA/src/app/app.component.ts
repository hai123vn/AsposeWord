import { FunctionUtility } from '../app/_core/function.utility';
import { Component } from '@angular/core';
import { AsposewordService } from './_core/asposeword.service';
import { SpinnerService } from './_core/spinner.service';
import { SweetAlertService } from './_core/sweet-alert.service';
import { Asposeword } from './_core/model/asposeword';

// export interface Word {
//   key: string;
//   title: string;
//   desc: string;
// }

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  title = 'SPA';
  list: string[] = [];
  fileWord: File;

  constructor(
    private service: AsposewordService,
    private functionUtility: FunctionUtility,
    private spinerService: SpinnerService,
    private alertService: SweetAlertService
  ) { }

  onFileChange(event: any) {
    this.fileWord = event.target.files[0];
    console.log(this.fileWord);
    this.service.uploadFile(this.fileWord).subscribe({
      next: (res) => {
        console.log(res);
        this.list = res;
      },
      error: () => {
      }
    })
  }

  download() {

  }
}

