export class UserShortDto {
    public userId: number;
    public userName: string;

    constructor(userId: number, userName: string) {
        this.userId = userId;
        this.userName = userName;
    }
}
