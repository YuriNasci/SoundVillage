import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Plano } from '../model/plano';
@Injectable({
  providedIn: 'root',
  
})
export class PlanoService {

  private url = "https://localhost:7015/api/Plano"

  constructor(private httpClient: HttpClient) { }

  public getPlanos() : Observable<Plano[]> {
     return this.httpClient.get<Plano[]>(this.url);
  }
}
