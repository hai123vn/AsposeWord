import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { FunctionUtility } from '../utilities';
import { FileOutput, NDWord, UploadFile } from '../models/upload-file';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AsposeWordService {

  baseApi: string = `${environment.apiUrl}Word`
  constructor(private http: HttpClient, private functions: FunctionUtility) { }


  convertToPDF(model: UploadFile) {
    let formData = this.functions.toFormData(model);
    return this.http.post<FileOutput[]>(`${this.baseApi}/ConvertToPDF`, formData);
  }

  downloadFile(model: FileOutput) {
    return this.http.post(`${this.baseApi}/DownloadFile`, model, { responseType: 'blob' });
  }

  TimKiemVaThayThe(model: UploadFile, param: NDWord) {
    let params = new HttpParams().appendAll({ ...param })
    let formData = this.functions.toFormData(model);
    return this.http.post<FileOutput>(`${this.baseApi}/TimKiemVaThayThe`, formData, { params });
  }

  ChenVanBan(model: UploadFile) {
    let formData = this.functions.toFormData(model);
    return this.http.post<FileOutput[]>(`${this.baseApi}/ChenVanBan`, formData);
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

  baoMat(model: UploadFile) {
    let formData = this.functions.toFormData(model);
    return this.http.post<FileOutput>(`${this.baseApi}/BaoMat`, formData);
  }

  BaoMatVoiCHUKISO() {
    return this.http.get(`${this.baseApi}/BaoMatVoiCHUKISO`);
  }
}
