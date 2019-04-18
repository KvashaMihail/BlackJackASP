import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AccountService } from '../services/account';
import { Router } from '@angular/router';
import { routerNgProbeToken } from '@angular/router/src/router_module';

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {
    constructor(private accountService: AccountService, private router: Router) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(catchError(err => {
            if (err.status === 401) {
                //this.accountService.logout();
                this.router.navigateByUrl("/account/login");
            }
            const error = `${err.status} ${err.statusText}`;
            return throwError(error);
        }))
    }
}