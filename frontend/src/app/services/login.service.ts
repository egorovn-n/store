import { Injectable } from '@angular/core';
import { LoginApiService } from './apiservices/login.apiservice';

@Injectable()
export class LoginService {
    private readonly loginKey = 'login';
    private readonly adminLogin = 'admin';

    constructor(private loginApiService: LoginApiService) {

    }

    public login(email: string, password: string): boolean {
        if (this.isLoggedIn()) {
            return true;
        }

        if (this.loginApiService.login(email, password)){
            localStorage.setItem(this.loginKey, email);
            return true;
        } else {
            return false;
        }
    }

    public register(email: string, password: string): boolean {
        return this.loginApiService.register(email, password);
    }

    public isLoggedIn(): boolean {
        return !!localStorage.getItem(this.loginKey);
    }

    public isAdmin(): boolean {
        if (!this.isLoggedIn()){
            return false;
        }

        return localStorage.getItem(this.loginKey) === this.adminLogin;
    }

    public logout(): void {
        localStorage.removeItem(this.loginKey);
    }
}
