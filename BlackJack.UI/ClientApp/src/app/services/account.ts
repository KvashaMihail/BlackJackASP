import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginAccountView } from '../viewModels/account/LoginAccountView';
import { Observable } from 'rxjs';
import { LocalStorageService } from './localStorageService';
import { RegisterAccountView } from '../viewModels/account/RegisterAccountView';
import { LoginAccountResponseView } from '../viewModels/account/LoginAccountResponseView';
import { RegisterAccountResponseView } from '../viewModels/account/RegisterAccountResponseView';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment.prod';

@Injectable({
    providedIn: 'root',
  })
export class AccountService {

  private Url = 'api/Account/';
//   private Url = `${environment}api/account/`;
  constructor(private http: HttpClient, private localStorageService: LocalStorageService) {
}

isSignedIn(): boolean {
  return this.getToken() != null;
}

getToken(): string {
  return this.localStorageService.getItem<string>("accessToken");
}

login(model: LoginAccountView): Observable<void> {
  return this.http.post<LoginAccountResponseView>(`${this.Url}Login`, model).pipe(
    map((response: LoginAccountResponseView) => {
      this.localStorageService.setItem<string>("accessToken", response.accessToken);
      this.localStorageService.setItem<string>("userName", response.name);
    }));
}

logout(): void {
  this.localStorageService.removeItem("accessToken");
  this.localStorageService.removeItem("userName");
}

getLoggedPlayerName(): string {
  return this.localStorageService.getItem<string>("userName");
}

whatClick(model: RegisterAccountView): Observable<any>  {
    let str = this.http.get(`api/Menu/GetStr`);
    console.log(str);
    return str;
}

register(model: RegisterAccountView): Observable<any> {
   return this.http.post(this.Url+'Register', model).pipe(
    map((response: RegisterAccountResponseView) => {
      this.localStorageService.setItem<string>("accessToken", response.accessToken);
      this.localStorageService.setItem<string>("userName", response.name);
    }));
}
}