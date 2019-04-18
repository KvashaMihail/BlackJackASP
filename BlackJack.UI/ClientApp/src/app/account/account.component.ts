import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent {

  @Output() onSignedAccount = new EventEmitter();
  
  onSigned() {
    this.onSignedAccount.emit();
  }
}
