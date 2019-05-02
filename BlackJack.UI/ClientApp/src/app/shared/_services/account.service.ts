import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import { Observable } from 'rxjs';
import { LocalStorageService } from './local.storage.service';
import { AccountResponseView } from '../_viewModels/account/account.response.view';
import { map } from 'rxjs/operators';
import { AccountView } from '../_viewModels/account/account.view';

@Injectable({
  providedIn: 'root',
})
export class AccountService {

  public userName: string;
  private Url = 'api/Account/';

  constructor(private http: HttpClient, private localStorageService: LocalStorageService) {
    if (this.isSignedIn()) {
      this.userName = this.getAccount().name;
    }
  }

  public isSignedIn(): boolean {
    return this.getAccount() != null;
  }

  public getAccount(): AccountResponseView {
    return this.localStorageService.getItem<AccountResponseView>("UserToken");
  }

  public login(model: AccountView): Observable<any> {
    return this.http.post(this.Url + 'Login', model).pipe(
      map((response: AccountResponseView) => {
        this.localStorageService.setItem<AccountResponseView>("UserToken", response);
        this.userName = response.name;
      }));
  }

  public logout(): void {
    this.localStorageService.removeItem("UserToken");
  }

  public register(model: AccountView): Observable<any> {
    return this.http.post(this.Url + 'Register', model).pipe(
      map((response: AccountResponseView) => {
        this.localStorageService.setItem<AccountResponseView>("UserToken", response);
        this.userName = response.name;
      }));
  }
}
