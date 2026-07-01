import { Component } from '@angular/core';
import { HeaderComponent } from './components/header/header.component';
import { RouterLink, RouterModule, RouterOutlet } from '@angular/router';
import { LoginService } from './services/login.service';
import { LoginApiService } from './services/apiservices/login.apiservice';

@Component({
    selector: 'app-root',
    imports: [
        HeaderComponent,
        RouterOutlet,
        RouterModule
    ],
    providers: [LoginApiService, LoginService],
    templateUrl: './app.html'
})
export class App {
    constructor() {

    }
}
