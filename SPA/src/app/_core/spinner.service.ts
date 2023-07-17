import { Injectable } from '@angular/core';
import { NgxSpinnerService } from "ngx-spinner";
import { Spinner } from 'ngx-spinner/lib/ngx-spinner.enum';

@Injectable({
  providedIn: 'root'
})
export class SpinnerService {

  constructor(private _spinner: NgxSpinnerService) { }
  config: Spinner = {
    type: "square-jelly-box", //cog ,ball-spin-clockwise , ball-fussion , ball-clip-rotate-multiple , timer
    size: "large",
    bdColor: "rgba(100,149,237, .8)",
    color: "white",
    // template: "<img src='https://media.giphy.com/media/o8igknyuKs6aY/giphy.gif' />"
  }
  show() {
    this._spinner.show('loading', this.config);
  }

  hide() {
    this._spinner.hide('loading');
    // setTimeout(() => {
    //   /** spinner ends after 5 seconds */
    //   this._spinner.hide('loading');
    // }, 500);
  }
}
