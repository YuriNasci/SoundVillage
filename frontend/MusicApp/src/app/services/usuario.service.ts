import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../model/usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  private url = "http://localhost:5251/api/User"

  constructor(private http: HttpClient) { }

  public autenticar(email:String, senha: String) : Observable<Usuario> {
    return this.http.post<Usuario>(`${this.url}/login`, {
      email:email,
      senha:senha
    });
  }

  public cadastrar(usuario: Usuario) : Observable<Usuario> {
    return this.http.post<Usuario>(this.url, {
      id: usuario.id,
      nome: usuario.nome,
      email: usuario.email,
      senha: usuario.senha,
      dataNascimento: usuario.dataNascimento,
      planoId: usuario.planoId,
      nomeCartao: usuario.nomeCartao,
      numeroCartao: usuario.numeroCartao,
      validadeCartao: usuario.validadeCartao,
      codigoSeguranca: usuario.codigoSeguranca
    });
  }
}