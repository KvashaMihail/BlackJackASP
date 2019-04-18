import { Component, OnInit } from '@angular/core';
import { AccountService } from './services/account';
import { BlockingProxy } from 'blocking-proxy';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  constructor(public service: AccountService, private router: Router) {
  }

  title = 'Account';
  ngOnInit(): void {
  }

  logout(): void {
    this.service.logout();
  }

  refreshAccount() {

  }



}
