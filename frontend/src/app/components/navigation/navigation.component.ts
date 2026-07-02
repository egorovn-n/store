import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { LoginService } from '../../services/login.service';

@Component({
    selector: 'navigation-component',
    templateUrl: './navigation.component.html',
    imports: [
        RouterLink
    ],
    styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent {
    constructor(public loginService: LoginService,
                private router: Router) {
    }

    public logout(): void {
        this.loginService.logout();
        this.router.navigate(['/']).then();
    }
}
