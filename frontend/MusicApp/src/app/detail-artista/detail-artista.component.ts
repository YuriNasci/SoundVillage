import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ActivatedRouteSnapshot, Route } from '@angular/router';
import { Artista } from '../model/artista';
import { ArtistaService } from '../services/artista.service';
import { Album } from '../model/album';
import {MatExpansionModule} from '@angular/material/expansion';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-detail-artista',
  standalone: true,
  imports: [MatExpansionModule, CommonModule],
  templateUrl: './detail-artista.component.html',
  styleUrl: './detail-artista.component.css'
})

export class DetailArtistaComponent implements OnInit {

  idArtista = '';
  artista!:Artista;
  albuns!:Album[];

  constructor(private route: ActivatedRoute, private artistaService: ArtistaService) {  }
  
  ngOnInit(): void {
    this.idArtista = this.route.snapshot.params["id"];

    this.artistaService.getArtistaPorId(this.idArtista).subscribe(response => {
      this.artista = response;
    });

    this.artistaService.getAlbunsArtista(this.idArtista).subscribe(response => {
      this.albuns = response;
      console.log(this.albuns);
    });

  }
}