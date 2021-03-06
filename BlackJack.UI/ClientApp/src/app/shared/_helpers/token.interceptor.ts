import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { LocalStorageService } from '../_services/local.storage.service';
import { AccountResponseView } from '../_viewModels/account/account.response.view';
  
@Injectable()
  export class HttpTokenInterceptor implements HttpInterceptor {

    constructor() {      
    }
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      var lStorage = new LocalStorageService();
      const account: AccountResponseView = lStorage.getItem<AccountResponseView>('UserToken');
      if (account) {
        request = request.clone({ headers: request.headers.set('Authorization', 'Bearer ' + account.token) });
      }
      return next.handle(request).pipe(
        map((event: HttpEvent<any>) => {
          return event;
        }));
    }
  }
