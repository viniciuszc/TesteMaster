import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Rota } from '../models/rota.model';

@Injectable({
  providedIn: 'root'
})
export class RotaService {
  private apiUrl = 'https://localhost:44353/api/rota';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Rota[]> {
    return this.http.get<Rota[]>(this.apiUrl);
  }

  getById(id: number): Observable<Rota> {
    return this.http.get<Rota>(`${this.apiUrl}/${id}`);
  }

  add(rota: Rota): Observable<Rota> {
    return this.http.post<Rota>(this.apiUrl, rota);
  }

  update(id: number, rota: Rota): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, rota);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
