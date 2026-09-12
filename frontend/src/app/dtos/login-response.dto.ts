/** Dto для ответа на вход в профиль. */
export class LoginResponseDto
{
    /** Jwt токен доступа. */
    public accessToken: string;

    /** Почта пользователя. */
    public email: string;

    /** Пароль пользователя. */
    public password: string;

    /** Роль пользователя. */
    public role: string;

    constructor(accessToken: string, email: string, password: string, role: string) {
        this.accessToken = accessToken;
        this.email = email;
        this.password = password;
        this.role = role;
    }
}
