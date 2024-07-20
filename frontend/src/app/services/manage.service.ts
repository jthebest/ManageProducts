import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ManageService {
  [x: string]: any;
  private apiUrl = 'http://localhost:5201/api/manages';

  constructor(private http: HttpClient) {}

  getManages(): Observable<any> {
    return this.http.get(this.apiUrl);
  }

  createManage(Manage: any): Observable<any> {
    return this.http.post(this.apiUrl, Manage);
  }

  updateManage(id: number, Manage: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, Manage);
  }

  deleteManage(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
