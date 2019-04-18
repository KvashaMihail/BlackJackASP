import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginAccountView } from '../viewModels/account/LoginAccountView';
import { Observable } from 'rxjs';
import { LocalStorageService } from './localStorageService';
import { RegisterAccountView } from '../viewModels/account/RegisterAccountView';
import { AccountResponseView } from '../viewModels/account/AccountResponseView';
import { map } from 'rxjs/operators';

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

  index():  Observable<any> {
    return this.http.get('api/Menu/Index').pipe(
      map((object: string) => {
        console.log(object);
      })
    );
  }

  isSignedIn(): boolean {
    return this.getAccount() != null;
  }

  getAccount(): AccountResponseView {
    return this.localStorageService.getItem<AccountResponseView>("UserToken");
  }

  login(model: LoginAccountView): Observable<any> {
    return this.http.post(this.Url + 'Login', model).pipe(
      map((response: AccountResponseView) => {
        this.localStorageService.setItem<AccountResponseView>("UserToken", response);
        this.userName = response.name;
      }));
  }

  logout(): void {
    this.localStorageService.removeItem("UserToken");
  }

  register(model: RegisterAccountView): Observable<any> {
    return this.http.post(this.Url+'Register', model).pipe(
      map((response: AccountResponseView) => {
        this.localStorageService.setItem<AccountResponseView>("UserToken", response);
        this.userName = response.name;
      }));
  }
}
