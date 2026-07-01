import { RolesEnum } from '../enums/roles.enum'

export class User {
    public userId: number;
    public email: string;
    public role: RolesEnum;

    constructor(userId: number, email: string, role: RolesEnum) {
        this.userId = userId;
        this.email = email;
        this.role = role;
    }
}
