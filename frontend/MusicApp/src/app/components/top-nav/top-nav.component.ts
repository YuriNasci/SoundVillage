import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { SearchBarService } from 'src/app/services/searchbar.service';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-top-nav',
  templateUrl: './top-nav.component.html',
  styleUrls: ['./top-nav.component.css'],
})
export class TopNavComponent implements OnInit {
  public isSearchFieldVisible: boolean = false;
  public isUserLoggedIn: boolean = false;
  
  @Output() public inputFilterRes: EventEmitter<any> = new EventEmitter();
  constructor(private router: Router, private sb: SearchBarService, private usuarioService: UsuarioService) {
    this.usuarioService.isUserLoggedIn().subscribe((loggedIn) => {
      this.isUserLoggedIn = loggedIn;
    });
  }

  ngOnInit(): void {
    this.sb.isSearchVisible.subscribe((status) => {
      this.isSearchFieldVisible = status;
    });

    this.usuarioService.isUserLoggedIn().subscribe((loggedIn) => {
      this.isUserLoggedIn = loggedIn;
    });
  }

  onNavigateToLogin() {
    this.router.navigate(['/', 'login']);
  }

  filterBrowsingList(inputElement: HTMLInputElement) {
    // console.log(inputElement);
    this.inputFilterRes.emit(inputElement.value);
  }

  logout() {
    this.usuarioService.logout();
  }

  public onNavigateToSignUp() {
    this.router.navigate(['/','signup']);
  }
}
