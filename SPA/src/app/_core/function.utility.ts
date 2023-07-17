import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { NgxSpinnerService } from "ngx-spinner";

@Injectable({
  providedIn: "root",
})
export class FunctionUtility {
  /**
   *Hàm tiện ích
   */
  constructor(
    private http: HttpClient,
    // private snotify: NgSnotifyService,
    private spinnerService: NgxSpinnerService,
    // private translateService: TranslateService
  ) { }


  download(result: Blob, fileName: string) {
    this.spinnerService.show();
    if (result.size == 0) {
      this.spinnerService.hide();
    }
    const blob = new Blob([result]);
    const url = window.URL.createObjectURL(blob);
    const link = document.createElement('a');
    link.href = url;
    link.setAttribute('download', fileName);
    document.body.appendChild(link);
    link.click();
  }
}

