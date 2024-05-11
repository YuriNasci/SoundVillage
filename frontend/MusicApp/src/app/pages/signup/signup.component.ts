import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  step: number = 0;
  router: any;

  constructor() { }

  ngOnInit(): void {
  }

  nextStep() {
    this.step = 1;
    // Atualize a URL com o parâmetro "step=1"
    this.router.navigate(['/signup'], { queryParams: { step: 1 } });
  }

}
