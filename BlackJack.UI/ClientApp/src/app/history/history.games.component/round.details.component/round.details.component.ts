import { Component, Input, OnInit } from '@angular/core';
import { RoundView } from 'src/app/shared/_viewModels/history/round.view';

@Component({
  selector: 'app-round',
  templateUrl: './round.details.component.html',
  styleUrls: ['./round.details.component.scss']
})
export class RoundDetailsComponent implements OnInit {
  
  @Input() round : RoundView;
  public isCollapsed = false;
  public itemClasses : Array<string> = ["", "", "", "", "", "", ""];
  public roundClass : string;
  
  public ngOnInit(): void {
    if (this.round.round.isCompleted) {
      this.roundClass = "btn-outline-primary";
    }
    if (!this.round.round.isCompleted) {
      this.roundClass = "btn-outline-secondary";
    }
    for (let i in this.round.isWins) {
      if (this.round.isWins[i]) {
        this.itemClasses[i] = "list-group-item-success";
      } 
      if (!this.round.isWins[i]) {
        this.itemClasses[i] = "list-group-item-secondary";
      } 
    }
  }

  

}
