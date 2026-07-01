import { Injectable } from '@angular/core';

@Injectable()
export class LoginService {
    public const tempUsers = []
    public login(username: string, password: string) {
        if (this.isLoggedIn()) {
            return;
        }


    }

    public isLoggedIn(): boolean {
        return !!localStorage.getItem('login');
    }

    public isAdmin(): boolean {
        if (!this.isLoggedIn()){
            return false;
        }

        return localStorage.getItem('login') === 'admin';
    }

    private getFakeUsers() {
        return [
            {login: 'user', password: 'user'},
            {login: 'admin', password: 'admin'},
        ]
    }
}
