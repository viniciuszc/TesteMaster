import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Localizacao } from '../models/localizacao.model';

@Injectable({
  providedIn: 'root'
})
export class LocalizacaoService {
  private apiUrl = 'https://localhost:44353/api/localizacao';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Localizacao[]> {
    return this.http.get<Localizacao[]>(this.apiUrl);
  }

  getById(id: number): Observable<Localizacao> {
    return this.http.get<Localizacao>(`${this.apiUrl}/${id}`);
  }

  add(localizacao: Localizacao): Observable<Localizacao> {
    return this.http.post<Localizacao>(this.apiUrl, localizacao);
  }

  update(id: number, localizacao: Localizacao): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, localizacao);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}