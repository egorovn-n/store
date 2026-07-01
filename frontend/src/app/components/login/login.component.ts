import { Component } from '@angular/core';
import { LoginService } from '../../services/login.service';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    imports: [FormsModule]
})
export class LoginComponent {
    public email: string = '';
    public password: string = '';
    public errorText: string = '';

    constructor(private loginService: LoginService,
                private router: Router,) {

    }

    public login() {
        this.errorText = '';
        if (!this.email || !this.password) {
            this.errorText = 'Введите email и пароль';
            return;
        }
        if (this.loginService.login(this.email, this.password)) {
            this.router.navigate(['/']);
        } else {
            this.errorText = 'Неправильный email или пароль.';
        }
    }
}
