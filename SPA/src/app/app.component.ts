import { FunctionUtility } from '../app/_core/function.utility';
import { Component } from '@angular/core';
import { AsposewordService } from './_core/asposeword.service';
import { SpinnerService } from './_core/spinner.service';
import { SweetAlertService } from './_core/sweet-alert.service';

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

  // data: Word[] = [
  //   {
  //     key: 'ConvertToPDF',
  //     title: 'Thay đổi định dạng',
  //     desc: 'Chuyển đổi định dạng từ file Word sang các dạng file khác như: Excel, PDF, ...'
  //   },
  //   {
  //     key: 'TimKiemVaThayThe',
  //     title: 'Tìm kiếm - Thay thế',
  //     desc: 'Tìm kiếm và thay thế các từ khoá trong word và trả ra 1 file mới'
  //   },
  //   {
  //     key: 'Word',
  //     title: 'Văn bản',
  //     desc: 'Tạo mới vẵn bản trống '
  //   },
  //   {
  //     key: 'ThemHinhAnh',
  //     title: 'Hình ảnh',
  //     desc: 'Chèn hình ảnh vào trong file word'
  //   },
  //   {
  //     key: 'Shap',
  //     title: 'biểu đồ',
  //     desc: 'Tạo và thao tác với bản đồ'
  //   },
  //   {
  //     key: 'Security',
  //     title: 'Bảo mật',
  //     desc: 'Cấu hình file word chỉ có thể đọc , hoặc hạn chế chỉnh sửa'
  //   }
  // ]
  constructor(
    private service: AsposewordService,
    private functionUtility: FunctionUtility,
    private spinerService: SpinnerService,
    private alertService: SweetAlertService
  ) { }

  download() {
    this.spinerService.show();
    this.service.downloadWordChuyenDoi().subscribe({
      next: (res: Blob) => {
        console.log(res)
        const fileName = "ABCXYZ"
        this.functionUtility.download(res, fileName);
        this.spinerService.hide();
      },
      error: (e) => {
        console.log(e);

        this.spinerService.hide();
        this.alertService.showError("Lỗi kia ní ơiiiii");
      }
    })
  }
}

