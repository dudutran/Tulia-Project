import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';

import { UserService } from '../user.service';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

    constructor(private userService: UserService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // add auth header with jwt if user is logged in and request is to the api url
        const user = this.userService.userValue;
        const isLoggedIn = user && user.role;
        const isApiUrl = request.url.startsWith('https://localhost:4200/');
        if (isLoggedIn && isApiUrl) {
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${user.role}`
                }
            });
        }

        return next.handle(request);
    }
}