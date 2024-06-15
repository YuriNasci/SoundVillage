import { HttpClient, HttpHeaders } from '@angular/common/http';
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
     return this.httpClient.get<Artista[]>(this.url, this.setAuthenticationHeader());
  }

  public getArtistaPorId(id: string) : Observable<Artista> {
    return this.httpClient.get<Artista>(`${this.url}/${id}`, this.setAuthenticationHeader());
  }

  public getAlbunsArtista(id: string) : Observable<Album[]> {
    return this.httpClient.get<Album[]>(`${this.url}/${id}/albums`, this.setAuthenticationHeader());
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

  private setAuthenticationHeader() {

    let access_token = sessionStorage.getItem("access_token");

    let options = {
      headers: new HttpHeaders().set("Authorization", `Bearer ${access_token}`)
    }

    return options;
  }
}
