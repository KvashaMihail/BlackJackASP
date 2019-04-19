import { Component, OnInit } from '@angular/core';
import { GameService } from 'src/app/services/game';


@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  
  constructor(private service: GameService) {
  }

  ngOnInit(): void {
    this.service.getPlayerMenu().subscribe(
      response => console.log(response),
      error => console.log(error)
    )
  }
}
