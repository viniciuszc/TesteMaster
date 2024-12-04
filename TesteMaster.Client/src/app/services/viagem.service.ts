import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Viagem } from '../models/viagem.model';

@Injectable({
  providedIn: 'root'
})
export class ViagemService {
  private apiUrl = 'https://localhost:44353/api/viagem';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Viagem[]> {
    return this.http.get<Viagem[]>(this.apiUrl);
  }

  getById(id: number): Observable<Viagem> {
    return this.http.get<Viagem>(`${this.apiUrl}/${id}`);
  }

  add(viagem: Viagem): Observable<Viagem> {
    return this.http.post<Viagem>(this.apiUrl, viagem);
  }

  update(id: number, viagem: Viagem): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, viagem);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  listarViagensPossiveis(origem: string, destino: string): Observable<Viagem[]> {
    return this.http.get<Viagem[]>(`${this.apiUrl}/ListarViagensPossiveis?origem=${origem}&destino=${destino}`);
  }

  listarViagensMenorValor(origem: string, destino: string): Observable<Viagem> {
    return this.http.get<Viagem>(`${this.apiUrl}/ListarViagensMenorValor?origem=${origem}&destino=${destino}`);
  }
}
