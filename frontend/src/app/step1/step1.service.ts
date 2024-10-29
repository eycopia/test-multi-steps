import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Step1DTO {
  aplicacion: string;
  tipoAfiliacion: string;
  nombre: string;
  rubro: string;
}

@Injectable({
  providedIn: 'root'
})
export class Step1Service {
  private apiUrl = 'http://localhost:5000/api/Step1';

  constructor(private http: HttpClient) {}

  submitForm(data: Step1DTO): Observable<any> {
    return this.http.post(this.apiUrl, data);
  }
}
