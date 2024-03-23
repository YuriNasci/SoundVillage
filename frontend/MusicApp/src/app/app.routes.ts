import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { DetailArtistaComponent } from './detail-artista/detail-artista.component';

export const routes: Routes = [
    {
        path: '',
        component: HomeComponent
    },
    {
        path: 'detail/:id',
        component: DetailArtistaComponent
    }
];
