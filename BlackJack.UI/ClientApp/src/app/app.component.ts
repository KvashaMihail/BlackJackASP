import { Component} from '@angular/core';
import { AccountService } from './_services/account';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  constructor(public service: AccountService) {
  }

  title = 'Account';

  logout(): void {
    this.service.logout();
  }


}
