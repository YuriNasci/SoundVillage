import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MusicaService {
  private url = "https://localhost:7015/api/Musica"

  constructor(private http: HttpClient) { }

  public favoritar(idMusica:String): Observable<any>{
    const user = sessionStorage.getItem("user");
    const userId = user? JSON.parse(user).id : null;
    
    return this.http.put(`${this.url}`, {
      idMusica:idMusica,
      idUsuario:userId
    });
  }
}
