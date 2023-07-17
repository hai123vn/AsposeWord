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

  title = 'SPA';

  data: Word[] = [
    {
      key: 'Transfer',
      title: 'Thay đổi định dạng',
      desc: 'Chuyển đổi định dạng từ file Word sang các dạng file khác như: Excel, PDF, ...'
    },
    {
      key: 'SearchPlace',
      title: 'Tìm kiếm - Thay thế',
      desc: 'Tìm kiếm và thay thế các từ khoá trong word và trả ra 1 file mới'
    },
    {
      key: 'Word',
      title: 'Văn bản',
      desc: 'Tạo mới vẵn bản trống '
    },
    {
      key: 'Picture',
      title: 'Hình ảnh',
      desc: 'Chèn hình ảnh vào trong file word'
    },
    {
      key: 'Shap',
      title: 'biểu đồ',
      desc: 'Tạo và thao tác với bản đồ'
    },
    {
      key: 'Security',
      title: 'Bảo mật',
      desc: 'Cấu hình file word chỉ có thể đọc , hoặc hạn chế chỉnh sửa'
    }
  ]
}
