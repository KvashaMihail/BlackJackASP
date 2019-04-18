import { Component, OnInit } from '@angular/core';
import { AccountService } from '../services/account';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.scss']
})
export class GameComponent implements OnInit {
  constructor(private service: AccountService) {

  }

  ngOnInit(): void {

    this.service.index();
  }
  
}
