/** Константы, использующиеся в процессе логина. */
export abstract class LoginConstants {
    /** Ключ для токена в хранилище. */
    public static readonly JwtTokenKey = 'jwtToken';

    /** Ключ для почты пользователя в хранилище. */
    public static readonly EmailKey = 'email';

    /** Ключ для роли пользователя в хранилище. */
    public static readonly RoleKey = 'role';
}
