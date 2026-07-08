import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { LoginService } from '../../services/login.service';
import { NgOptimizedImage } from '@angular/common';
import { environment } from '@environment/environment';

@Component({
    selector: 'navigation-component',
    templateUrl: './navigation.component.html',
    imports: [
        RouterLink,
        NgOptimizedImage
    ],
    styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent {
    public appTitle: string = environment.appTitle;
    public imgSrc: string = 'favicon.ico';

    constructor(public loginService: LoginService,
                private router: Router) {
    }

    public logout(): void {
        this.loginService.logout();
        this.router.navigate(['/']).then();
    }

    public onAdminMouseEnter(): void {
        let adminDetails = document.getElementById('adminDetails') as HTMLDetailsElement;
        if (adminDetails !== undefined) {
            adminDetails.setAttribute('open', 'true');
        }
    }

    public onAdminMouseLeave(event: MouseEvent): void {
        // Проверяем, не перешел ли курсор на дочерний элемент
        const relatedTarget = event.relatedTarget as HTMLElement;
        const details = event.currentTarget as HTMLElement;

        // Если курсор перешел на дочерний элемент details - не закрываем
        if (relatedTarget && details.contains(relatedTarget)) {
            return;
        }

        let adminDetails = document.getElementById('adminDetails') as HTMLDetailsElement;
        if (adminDetails) {
            adminDetails.removeAttribute('open');
        }
    }
}
