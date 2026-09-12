import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '@environment/environment';
import { LoginResponseDto } from '../../dtos/login-response.dto';
import { map, Observable, take } from 'rxjs';
import { LoginConstants } from '../../constants/login.constants';

/** Сервис для апи запросов связанных с входом в аккаунт. */
@Injectable()
export class LoginApiService {
    constructor(private http: HttpClient) { }

    /** Вход в аккаунт. */
    public login(email: string, password: string): Observable<void> {
        const result = this.http.post(environment.apiUrl + 'api/Login/Login', {
            email: email,
            password: password
        }) as Observable<LoginResponseDto>;

        return result.pipe(take(1), map(loginResponse => {
            localStorage.setItem(LoginConstants.JwtTokenKey, loginResponse.accessToken);
            localStorage.setItem(LoginConstants.EmailKey, loginResponse.email);
            localStorage.setItem(LoginConstants.RoleKey, loginResponse.role);
        }));
    }

    /** Регистрация. */
    public register(email: string, password: string): Observable<unknown> {
        return this.http.post(environment.apiUrl + 'api/Login/Register', {
            email: email,
            password: password
        }) as Observable<unknown>;
    }
}
