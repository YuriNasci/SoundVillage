import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ActivatedRouteSnapshot, Route } from '@angular/router';
import { Artista } from '../model/artista';
import { ArtistaService } from '../services/artista.service';
import { Album, Musica } from '../model/album';
import {MatExpansionModule} from '@angular/material/expansion';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MusicaService } from '../services/musica.service';


@Component({
  selector: 'app-detail-artista',
  standalone: true,
  imports: [MatExpansionModule, CommonModule, MatIconModule ],
  templateUrl: './detail-artista.component.html',
  styleUrl: './detail-artista.component.css'
})

export class DetailArtistaComponent implements OnInit {

  idArtista = '';
  artista!:Artista;
  albuns!:Album[];
  changeDetector: any;

  constructor(private route: ActivatedRoute, private artistaService: ArtistaService, private musicaService: MusicaService) {  }
  
  ngOnInit(): void {
    this.idArtista = this.route.snapshot.params["id"];

    this.artistaService.getArtistaPorId(this.idArtista).subscribe(response => {
      this.artista = response;
    });

    this.artistaService.getAlbunsArtistaPorUsuario(this.idArtista).subscribe(response => {
      this.albuns = response;
      console.log(this.albuns);
    });
  }

  favoritar(musica: Musica) {
    this.musicaService.favoritar(musica.id!).subscribe(response => {
      console.log(response);
      musica.favorita = !musica.favorita;
      this.changeDetector.detectChanges();
    });
  }
}