import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { FunctionUtility } from '../utilities';
import { UploadFile } from '../models/upload-file';

@Injectable({
  providedIn: 'root'
})
export class AsposeWordService {

  baseApi: string = `${environment.apiUrl}Word`
  constructor(private http: HttpClient, private functions: FunctionUtility) { }


  convertToPDF(model: UploadFile) {
    let formData = this.functions.toFormData(model);
    return this.http.post<string[]>(`${this.baseApi}/ConvertToPDF`, formData);
  }

  downloadFile(fileName: string) {
    return this.http.post(`${this.baseApi}/DownloadFile`, {}, { responseType: 'blob', params: { fileName } });
  }

  TimKiemVaThayThe() {
    return this.http.get(`${this.baseApi}/TimKiemVaThayThe`);
  }


  ThemHinhAnh() {
    return this.http.get(`${this.baseApi}/ThemHinhAnh`);
  }

  TrichXuatHinhAnh() {
    return this.http.get(`${this.baseApi}/TrichXuatHinhAnh`);
  }

  ChenVaThaoTacBieuDo() {
    return this.http.get(`${this.baseApi}/ChenVaThaoTacBieuDo`);
  }

  BaoMat() {
    return this.http.get(`${this.baseApi}/BaoMat`);
  }

  BaoMatVoiCHUKISO() {
    return this.http.get(`${this.baseApi}/BaoMatVoiCHUKISO`);
  }
}
