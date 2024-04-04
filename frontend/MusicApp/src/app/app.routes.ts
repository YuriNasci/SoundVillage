import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { DetailArtistaComponent } from './detail-artista/detail-artista.component';
import { LoginComponent } from './login/login.component';
import { CadastroComponent } from './cadastro/cadastro.component';

export const routes: Routes = [
    {
        path: '',
        component: LoginComponent
    },
    {
        path: 'home',
        component: HomeComponent

    },
    {
        path: 'detail/:id',
        component: DetailArtistaComponent
    },
    {
        path: 'cadastro',
        component: CadastroComponent
    }
];
