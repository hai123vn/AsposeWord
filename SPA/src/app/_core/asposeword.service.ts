import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AsposewordService {
  apiUrl: string = `${environment.apiUrl}AsposeWord`;
  constructor(private http: HttpClient) { }


  uploadFile(file: File) {
    const formData = new FormData();
    formData.append("file", file);
    return this.http.post<string[]>(`${this.apiUrl}/ConvertToPDF`, formData)
  }

  downloadWordChuyenDoi(fileName: string) {
    return this.http.post(`${this.apiUrl}/DownloadFile`, {}, { responseType: 'blob', params: { fileName } })
  }
}
