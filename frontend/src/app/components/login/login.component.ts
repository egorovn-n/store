import { Component, ElementRef, signal, ViewChild } from '@angular/core';
import { LoginService } from '../../services/login.service';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { LoadingService } from '../../services/loading.service';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { HtmlElementsHelper } from '../../helpers/html-elements.helper';
import { ErrorsConstants } from '../../constants/errors.constants';

/** Компонент формы логина. */
@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    imports: [FormsModule]
})
export class LoginComponent {
    public email: string = '';
    public password: string = '';
    public errorText = signal('');

    @ViewChild('loginForm', { static: false })
    private loginForm: ElementRef | undefined;

    constructor(private loginService: LoginService,
                private router: Router,
                private loadingService: LoadingService) {
        loadingService.isLoading$.pipe(takeUntilDestroyed()).subscribe(isLoading => {
            HtmlElementsHelper.setInputDisabledAttribute(isLoading, this.loginForm);
            HtmlElementsHelper.setButtonDisabledAttribute(isLoading, this.loginForm);
        });
    }

    /** Логин пользователя. */
    public login() {
        this.errorText.set('');
        if (!this.email || !this.password) {
            this.errorText.set('Введите email и пароль');
            return;
        }

        //this.loadingService.startLoading();
        this.loginService.login(this.email, this.password).subscribe({next: () => {
                this.loadingService.endLoading();
                this.router.navigate(['/']).then();
            },
            error: (err) => {
                this.loadingService.endLoading();
                this.errorText.set(err.error?.title ?? ErrorsConstants.UnknownErrorText);
            }});
    }
}
