import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Artista } from '../model/artista';
import { Album } from '../model/album';

@Injectable({
  providedIn: 'root',
  
})
export class ArtistaService {

  private url = "https://localhost:7015/api/Artista"

  constructor(private httpClient: HttpClient) { }

  public getArtista() : Observable<Artista[]> {
     return this.httpClient.get<Artista[]>(this.url);
  }

  public getArtistaPorId(id: string) : Observable<Artista> {
    return this.httpClient.get<Artista>(`${this.url}/${id}`);
  }

  public getAlbunsArtista(id: string) : Observable<Album[]> {
    return this.httpClient.get<Album[]>(`${this.url}/${id}/albums`);
  }

  public getAlbunsArtistaPorUsuario(id: string): Observable<Album[]> {
    const user = sessionStorage.getItem("user");
    const userId = user? JSON.parse(user).id : null;
    if (userId !== null) {
      return this.httpClient.get<Album[]>(`${this.url}/${id}/albums/user/${userId}`);
    } else {
      // Handle the case when userId is null
      return this.httpClient.get<Album[]>(`${this.url}/${id}/albums`);
    }
  }
}
