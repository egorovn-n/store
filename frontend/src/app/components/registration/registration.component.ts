import { Component } from '@angular/core';
import { LoginService } from '../../services/login.service';
import { FormsModule } from '@angular/forms';

@Component({
    selector: 'registration',
    templateUrl: './registration.component.html',
    imports: [FormsModule]
})
export class RegistrationComponent {
    public email: string = '';
    public password: string = '';
    public repeatedPassword: string = '';
    public errorText: string = '';
    public successText: string = '';

    constructor(private loginService: LoginService) {

    }

    public onRegistrationClick(): void {
        this.errorText = '';
        this.successText = '';
        if (this.loginService.isLoggedIn()) {
            this.errorText = 'Сначала выйдите из текущего аккаунта';

            return;
        }
        if (this.password !== this.repeatedPassword) {
            this.errorText = 'Введенные пароли не совпадают';

            return;
        }
        if (this.loginService.register(this.email, this.password)) {
            this.successText = 'Регистрация прошла успешно!';
        } else {
            this.errorText = 'Не удалось зарегистрировать аккаунт на заданный email';
        }
    }
}
