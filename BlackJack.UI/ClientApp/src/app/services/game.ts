import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class GameService {

  private UrlMenu = 'api/Menu/';
  private UrlGame = 'api/Game/';

  constructor(private http: HttpClient) {
  }

  getPlayerMenu() {
    return this.http.get(`${this.UrlMenu}GetPlayerMenu`);
  }


}
