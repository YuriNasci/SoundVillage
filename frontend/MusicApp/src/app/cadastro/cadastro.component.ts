import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { MatOptionModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {provideNativeDateAdapter} from '@angular/material/core';
import {MatSelectChange, MatSelectModule} from '@angular/material/select';
import { PlanoService } from '../services/plano.service';
import { Plano } from '../model/plano';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-cadastro',
  standalone: true,
  providers: [provideNativeDateAdapter()],
  imports: [ReactiveFormsModule, MatFormFieldModule, MatOptionModule, MatButtonModule, MatInputModule, 
    MatDatepickerModule, MatSelectModule, CommonModule],
  templateUrl: './cadastro.component.html',
  styleUrl: './cadastro.component.css'
})
export class CadastroComponent {
  cadastroForm = new FormGroup({
    nome: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.email]),
    senha: new FormControl('', [Validators.required, Validators.minLength(6)]),
    nascimento: new FormControl('', Validators.required),
    plano: new FormControl('', Validators.required),
    nomeCartao: new FormControl(),
    numeroCartao: new FormControl(),
    validadeCartao: new FormControl(),
    codigoSeguranca: new FormControl()
  });

  planos: Plano[] = [];
  showCreditCardForm = false;

  onSubmit() {
    if (this.cadastroForm.invalid) {
      return;
    }
  }

  constructor(private planoService: PlanoService) {}

  ngOnInit() {
    this.planoService.getPlanos().subscribe(planos => {
      this.planos = planos; 
    });
  }

  onPlanoSelected(change: MatSelectChange) {
    const planoId = change.value as string;
    const planoSelecionado = this.planos.find(plano => plano.id === planoId);
    if (planoSelecionado && planoSelecionado.valor > 0) {
      this.showCreditCardForm = true;
      this.cadastroForm.controls['nomeCartao'].setValidators([Validators.required]);
      this.cadastroForm.controls['numeroCartao'].setValidators([Validators.required]);
      this.cadastroForm.controls['validadeCartao'].setValidators([Validators.required]);
      this.cadastroForm.controls['codigoSeguranca'].setValidators([Validators.required]);
    } else {
      this.showCreditCardForm = false;
      this.cadastroForm.controls['nomeCartao'].clearValidators();
      this.cadastroForm.controls['numeroCartao'].clearValidators();
      this.cadastroForm.controls['validadeCartao'].clearValidators();
      this.cadastroForm.controls['codigoSeguranca'].clearValidators();
    }
  }
}
