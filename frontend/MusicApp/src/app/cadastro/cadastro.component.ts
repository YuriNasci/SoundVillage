import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { MatOptionModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';

@Component({
  selector: 'app-cadastro',
  standalone: true,
  imports: [ReactiveFormsModule, MatFormFieldModule, MatOptionModule],
  templateUrl: './cadastro.component.html',
  styleUrl: './cadastro.component.css'
})
export class CadastroComponent {
  cadastroForm = new FormGroup({
    nome: new FormControl('', Validators.required),
    senha: new FormControl('', [Validators.required, Validators.minLength(6)]),
    nascimento: new FormControl('', Validators.required),
    plano: new FormControl('', Validators.required)
  });

  onSubmit() {
    if (this.cadastroForm.invalid) {
      return;
    }
  }
}
