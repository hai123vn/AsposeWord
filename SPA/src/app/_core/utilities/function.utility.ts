import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
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

  /**
   *Trả ra ngày hiện tại, chỉ lấy năm tháng ngày: yyyy/MM/dd
   */
  getToDay() {
    const toDay =
      new Date().getFullYear().toString() +
      "/" +
      (new Date().getMonth() + 1).toString() +
      "/" +
      new Date().getDate().toString();
    return toDay;
  }

  /**
   *Trả ra ngày với tham số truyền vào là ngày muốn format, chỉ lấy năm tháng ngày: yyyy/MM/dd
   */
  getDateFormat(date: Date) {
    return (
      date.getFullYear() +
      "/" +
      (date.getMonth() + 1 < 10
        ? "0" + (date.getMonth() + 1)
        : date.getMonth() + 1) +
      "/" +
      (date.getDate() < 10 ? "0" + date.getDate() : date.getDate())
    );
  }

  /**
   *Trả ra ngày với tham số truyền vào là ngày muốn format string: yyyy/MM/dd HH:mm:ss
   */
  getDateTimeFormat(date: Date) {
    return (
      date.getFullYear() +
      "/" +
      (date.getMonth() + 1 < 10
        ? "0" + (date.getMonth() + 1)
        : date.getMonth() + 1) +
      "/" +
      (date.getDate() < 10 ? "0" + date.getDate() : date.getDate()) +
      " " +
      (date.getHours() < 10 ? "0" + date.getHours() : date.getHours()) +
      ":" +
      (date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes()) +
      ":" +
      (date.getSeconds() < 10 ? "0" + date.getSeconds() : date.getSeconds())
    );
  }

  getUTCDate(d?: Date) {
    let date = d ? d : new Date();
    return new Date(
      Date.UTC(
        date.getFullYear(),
        date.getMonth(),
        date.getDate(),
        date.getHours(),
        date.getMinutes(),
        date.getSeconds()
      )
    );
  }

  /**
   * Nhập vào kiểu chuỗi hoặc số dạng 123456789 sẽ trả về 123,456,789
   */
  convertNumber(amount: any) {
    return String(amount).replace(
      /(?<!\..*)(\d)(?=(?:\d{3})+(?:\.|$))/g,
      "$1,"
    );
  }

  /**
   * Check 1 string có phải empty hoặc null hoặc undefined ko.
   */
  IsNullOrEmpty(str: any) {
    return !str || /^\s*$/.test(str);
  }

  /**
   * Kiểm tra số lượng phần ở trang hiện tại, nếu bằng 1 thì cho pageNumber lùi 1 trang
   * @param pagination
   */
  // calculatePagination(pagination: Pagination) {
  //   // Kiểm tra trang hiện tại phải là trang cuối không và trang hiện tại không phải là trang 1
  //   if (
  //     pagination.pageNumber === pagination.totalPage &&
  //     pagination.pageNumber !== 1
  //   ) {
  //     // Lấy ra số lượng phần tử hiện tại của trang
  //     let currentItemQty =
  //       pagination.totalCount -
  //       (pagination.pageNumber - 1) * pagination.pageSize;

  //     // Nếu bằng 1 thì lùi 1 trang
  //     if (currentItemQty === 1) {
  //       pagination.pageNumber--;
  //     }
  //   }
  // }

  /**
   * Thêm hoặc xóa class tác động vào id element trên DOM
   * * @param id 
   * * @param className
   * * @param type => Value bằng true thì add class. Value bằng false thì xóa class
   */
  // changeDomClassList(id: string, className: string, type: boolean) {
  //   type
  //     ? document.getElementById(id).classList.add(className)
  //     : document.getElementById(id).classList.remove(className);
  // }

  /**
   * Append property FormData
   * If property type Date => Convert value to String
   * * @param formValue
   */
  toFormData(obj: any, form?: FormData, namespace?: string) {
    let fd = form || new FormData();
    let formKey: string;
    for (var property in obj) {
      if (obj.hasOwnProperty(property)) {
        // namespaced key property
        if (!isNaN(property as any)) {
          // obj is an array
          formKey = namespace ? `${namespace}[${property}]` : property;
        } else {
          // obj is an object
          formKey = namespace ? `${namespace}.${property}` : property;
        }
        if (obj[property] instanceof Date) {
          // the property is a date, so convert it to a string
          fd.append(formKey, obj[property].toISOString());
        } else if (typeof obj[property] === 'object' && !(obj[property] instanceof File)) {
          // the property is an object or an array, but not a File, use recursivity
          this.toFormData(obj[property], fd, formKey);
        } else {
          // the property is a string, number or a File object
          fd.append(formKey, obj[property]);
        }
      }
    }
    return fd;
  }

  /**
   * Append property HttpParams
   * * @param formValue
   */
  ToParams(formValue: any) {
    let params = new HttpParams();
    for (const key of Object.keys(formValue)) {
      const value = formValue[key];
      params = params.append(key, value);
    }
    return params;
  }

  exportExcel(result: Blob, fileName: string) {
    if (result.size == 0) {
      this.spinnerService.hide();
      // return this.snotify.warning('No Data', "Warning")
    }
    if (result.type !== 'application/xlsx') {
      this.spinnerService.hide();
      // return this.snotify.error(result.type.toString(), "Error");
    }
    const blob = new Blob([result]);
    const url = window.URL.createObjectURL(blob);
    const link = document.createElement('a');
    link.href = url;
    link.setAttribute('download', `${fileName}.xlsx`);
    document.body.appendChild(link);
    link.click();
  }


  download(result: Blob, fileName: string) {
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

export const NgxBootstrapSize = {
  Screen_XL: 'modal-xl',
  Screen_LG: 'modal-lg',
  Screen_MD: 'modal-md',
  Screen_SM: 'modal-sm',
  Screen_XL_CENTER: 'modal-xl modal-dialog-centered',
  Screen_LG_CENTER: 'modal-lg modal-dialog-centered',
  Screen_MD_CENTER: 'modal-md modal-dialog-centered',
  Screen_SM_CENTER: 'modal-sm modal-dialog-centered',
}
