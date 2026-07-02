import { Component } from '@angular/core';
import { NavigationComponent } from './components/navigation/navigation.component';
import { RouterModule, RouterOutlet } from '@angular/router';
import { LoginService } from './services/login.service';
import { LoginApiService } from './services/apiservices/login.apiservice';

@Component({
    selector: 'app-root',
    imports: [
        NavigationComponent,
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
