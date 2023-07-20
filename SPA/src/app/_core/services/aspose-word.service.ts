import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { FunctionUtility } from '../utilities';
import { FileOutput, UploadFile } from '../models/upload-file';
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

    TimKiemVaThayThe() {
        return this.http.get(`${this.baseApi}/TimKiemVaThayThe`);
    }


    ThemHinhAnh(model: UploadFile) {
        let formData = this.functions.toFormData(model);
        return this.http.post<FileOutput>(`${this.baseApi}/ThemHinhAnh`, formData);
    }

    TrichXuatHinhAnh(model: UploadFile) {
        let formData = this.functions.toFormData(model);
        return this.http.post<FileOutput[]>(`${this.baseApi}/TrichXuatHinhAnh`, formData);
    }

    ChenVaThaoTacBieuDo(model: UploadFile) {
        let formData = this.functions.toFormData(model);
        return this.http.post<FileOutput>(`${this.baseApi}/ChenVaThaoTacBieuDo`, formData);
    }

    baoMat(model: UploadFile) {
        let formData = this.functions.toFormData(model);
        return this.http.post<FileOutput>(`${this.baseApi}/BaoMat`, formData);
    }

    BaoMatVoiCHUKISO(model: UploadFile) {
        let formData = this.functions.toFormData(model);
        return this.http.post<FileOutput>(`${this.baseApi}/BaoMatVoiCHUKISO`, formData);
    }
}
