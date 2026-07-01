export class User {
    public userId: number;
    public userName: string;
    public email: string;

    constructor(userId: number, userName: string, email: string) {
        this.userId = userId;
        this.userName = userName;
        this.email = email;
    }
}
