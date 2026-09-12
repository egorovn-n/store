import { HttpEvent, HttpHandlerFn, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoginConstants } from '../constants/login.constants';

/** Интерцептор для добавления токена авторизации к каждому запросу. */
export function loginTokenAddingInterceptor(
    req: HttpRequest<unknown>,
    next: HttpHandlerFn
): Observable<HttpEvent<unknown>> {
    const token = localStorage.getItem(LoginConstants.JwtTokenKey);
    if (token) {
        req.headers.set('Authorization', `Bearer ${token}`);
    }

    return next(req);
}
