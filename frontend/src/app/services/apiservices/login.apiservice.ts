import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../../models/user.model';
import { RolesEnum } from '../../enums/roles.enum';

@Injectable()
export class LoginApiService {
    private fakeUsers: UserWithPassword[] = [
        new UserWithPassword(new User(0, 'user', RolesEnum.User), 'user'),
        new UserWithPassword(new User(1, 'admin', RolesEnum.Admin), 'admin'),
    ];

    constructor(private http: HttpClient) {

    }

    public login(email: string, password: string): boolean {
        return this.fakeUsers.some((user) => user.user.email === email && user.password === password);
    }

    public register(email: string, password: string): boolean {
        if (this.fakeUsers.some((user) => user.user.email === email)) {
            return false;
        }
        this.fakeUsers.push(new UserWithPassword(
            new User(Math.max(...this.fakeUsers.map(user => user.user.userId)) + 1, email, RolesEnum.User),
                password));

        return true
    }
}

export class UserWithPassword {
    public user: User;
    public password: string;
    constructor(user: User, password: string) {
        this.user = user;
        this.password = password;
    }
}
