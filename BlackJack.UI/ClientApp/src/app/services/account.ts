import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import { Observable } from 'rxjs';
import { LocalStorageService } from './localStorageService';
import { AccountResponseView } from '../viewModels/account/AccountResponseView';
import { map } from 'rxjs/operators';
import { AccountView } from '../viewModels/account/AccountView';

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

  isSignedIn(): boolean {
    return this.getAccount() != null;
  }

  getAccount(): AccountResponseView {
    return this.localStorageService.getItem<AccountResponseView>("UserToken");
  }

  login(model: AccountView): Observable<any> {
    return this.http.post(this.Url + 'Login', model).pipe(
      map((response: AccountResponseView) => {
        this.localStorageService.setItem<AccountResponseView>("UserToken", response);
        this.userName = response.name;
      }));
  }

  logout(): void {
    this.localStorageService.removeItem("UserToken");
  }

  register(model: AccountView): Observable<any> {
    return this.http.post(this.Url + 'Register', model).pipe(
      map((response: AccountResponseView) => {
        this.localStorageService.setItem<AccountResponseView>("UserToken", response);
        this.userName = response.name;
      }));
  }
}
