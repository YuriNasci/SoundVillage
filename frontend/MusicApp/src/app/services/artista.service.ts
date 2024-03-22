import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Artista } from '../model/artista';

@Injectable({
  providedIn: 'root',
  
})
export class ArtistaService {

  private url = "https://localhost:7015/api/Artista"

  constructor(private httpClient: HttpClient) { }

  public getArtista() : Observable<Artista[]> {
     return this.httpClient.get<Artista[]>(this.url);
  }
}
