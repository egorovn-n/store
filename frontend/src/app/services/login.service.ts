import { Injectable } from '@angular/core';
import { LoginApiService } from './apiservices/login.apiservice';
import { LoginConstants } from '../constants/login.constants';
import { Observable, of } from 'rxjs';
import { RolesEnum } from '../enums/roles.enum';

/** Сервис для работы с входом в систему. */
@Injectable()
export class LoginService {
    constructor(private loginApiService: LoginApiService) { }

    /** Логин пользователя. */
    public login(email: string, password: string): Observable<void> {
        if (this.isLoggedIn()) {
            return of();
        }

        return this.loginApiService.login(email, password);
    }

    /** Регистрация нового пользователя. */
    public register(email: string, password: string): Observable<unknown> {
        return this.loginApiService.register(email, password);
    }

    /** Авторизован ли пользователь. */
    public isLoggedIn(): boolean {
        return !!localStorage.getItem(LoginConstants.JwtTokenKey);
    }

    /** Является ли пользователь администратором. */
    public isAdmin(): boolean {
        if (!this.isLoggedIn()){
            return false;
        }

        return localStorage.getItem(LoginConstants.RoleKey) === RolesEnum.Admin;
    }

    /** Выход из аккаунта пользователя. */
    public logout(): void {
        localStorage.removeItem(LoginConstants.JwtTokenKey);
        localStorage.removeItem(LoginConstants.EmailKey);
        localStorage.removeItem(LoginConstants.RoleKey);
    }
}
