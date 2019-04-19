import {
    HttpEvent,
    HttpInterceptor,
    HttpHandler,
    HttpRequest
  } from '@angular/common/http';
  import { Observable } from 'rxjs';
  import { map } from 'rxjs/operators';
import { LocalStorageService } from '../services/localStorageService';
import { AccountResponseView } from '../viewModels/account/AccountResponseView';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { routerNgProbeToken } from '@angular/router/src/router_module';
  
@Injectable()
  export class HttpTokenInterceptor implements HttpInterceptor {

    constructor(private router: Router) {      
    }
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      var lStorage = new LocalStorageService();
      const account: AccountResponseView = lStorage.getItem<AccountResponseView>('UserToken');
      if (account) {
        request = request.clone({ headers: request.headers.set('Authorization', 'Bearer ' + account.token) });
        this.router.navigateByUrl("/game");
      }
      return next.handle(request).pipe(
        map((event: HttpEvent<any>) => {
          return event;
        }));
    }
  }