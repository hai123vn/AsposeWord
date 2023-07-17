import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AsposewordService {
  apiUrl: string = `${environment.apiUrl}AsposeWord`;
  constructor(private http: HttpClient) { }

  downloadWordChuyenDoi() {
    console.log('vo');

    return this.http.get(`${this.apiUrl}/ConvertToPDF`, { responseType: 'blob' })
  }
}
