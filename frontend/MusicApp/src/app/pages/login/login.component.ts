import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Usuario } from 'src/app/model/usuario';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  public usernameFormControl = new FormControl(null, [
    Validators.required,
    Validators.email,
  ]);
  public passwordFormControl = new FormControl(null, [Validators.minLength(4)]);
  public userForm!: FormGroup;
  public usuario!: Usuario;
  errorMessage = '';
  
  constructor(private usuarioService: UsuarioService, private router: Router) {

  }

  ngOnInit(): void {
    this.userForm = new FormGroup({
      username: this.usernameFormControl,
      password: this.passwordFormControl,
    });
  }

  submit() {
    let emailValue = this.userForm.value.username as String;
    let senhaValue = this.userForm.value.password as String;

    this.usuarioService.autenticar(emailValue, senhaValue).subscribe(
      {
        next: (response) => {
          this.usuario = response;
          sessionStorage.setItem("user", JSON.stringify(this.usuario));
          this.router.navigate([""]);
        },
        error: (e) => {
          if (e.error) {
            this.errorMessage = e.error.error;
          }
        }
      });
  }
}
