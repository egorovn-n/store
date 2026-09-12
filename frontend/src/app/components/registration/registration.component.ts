import { Component, ElementRef, signal, ViewChild } from '@angular/core';
import { LoginService } from '../../services/login.service';
import { FormsModule } from '@angular/forms';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { HtmlElementsHelper } from '../../helpers/html-elements.helper';
import { LoadingService } from '../../services/loading.service';
import { ErrorsConstants } from '../../constants/errors.constants';

/** Компонент формы регистрации пользователей. */
@Component({
    selector: 'registration',
    templateUrl: './registration.component.html',
    imports: [FormsModule]
})
export class RegistrationComponent {
    public email: string = '';
    public password: string = '';
    public repeatedPassword: string = '';
    public errorText = signal('');
    public successText = signal('');

    @ViewChild('registrationForm', { static: false })
    private registrationForm: ElementRef | undefined;

    constructor(private loginService: LoginService,
                private loadingService: LoadingService) {
        loadingService.isLoading$.pipe(takeUntilDestroyed()).subscribe(isLoading => {
            HtmlElementsHelper.setInputDisabledAttribute(isLoading, this.registrationForm);
            HtmlElementsHelper.setButtonDisabledAttribute(isLoading, this.registrationForm);
        });
    }

    /** Обработчик кнопки регистрации. */
    public onRegistrationClick(): void {
        this.errorText.set('');
        this.successText.set('');
        if (this.loginService.isLoggedIn()) {
            this.errorText.set('Сначала совершите выход из текущего аккаунта.');

            return;
        }
        if (this.password !== this.repeatedPassword) {
            this.errorText.set('Введенные пароли не совпадают.');

            return;
        }

        this.loadingService.startLoading();
        this.loginService.register(this.email, this.password).subscribe({
            next: () => {
                this.loadingService.endLoading();
                this.successText.set('Регистрация прошла успешно!');
            }, error: err => {
                this.loadingService.endLoading();
                this.errorText.set(err.error?.title ?? ErrorsConstants.UnknownErrorText);
            }});
    }
}
