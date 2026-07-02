import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { LoginService } from '../../services/login.service';

@Component({
    selector: 'header-component',
    templateUrl: './header.component.html',
    imports: [
        RouterLink
    ],
    styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
    constructor(public loginService: LoginService,
                private router: Router) {
    }

    public logout(): void {
        this.loginService.logout();
        this.router.navigate(['/']).then();
    }
}
