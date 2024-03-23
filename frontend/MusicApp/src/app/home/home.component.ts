import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { ArtistaService } from '../services/artista.service';
import { Artista } from '../model/artista';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from "@angular/flex-layout";
import { Router } from '@angular/router';



@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MatButtonModule, MatCardModule, HttpClientModule, CommonModule, FlexLayoutModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {

  artistas = null;

  constructor(private artistaService: ArtistaService, private router: Router) {
  }
  ngOnInit(): void {
    this.artistaService.getArtista().subscribe(response => {
      console.log(response);
      this.artistas = response as any;
    });
  }

  public goToDetail(item:Artista) {
    this.router.navigate(["detail", item.id]);
  }

}
