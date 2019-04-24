import { Component, Input, OnInit, OnChanges } from '@angular/core';
import { RoundView } from 'src/app/_viewModels/history/RoundView';
import { Round } from 'src/app/_models/Round';
import { iterateListLike } from '@angular/core/src/change_detection/change_detection_util';

@Component({
  selector: 'app-round',
  templateUrl: './round.component.html',
  styleUrls: ['./round.component.scss']
})
export class RoundComponent implements OnInit {
  
  @Input() round : RoundView;
  public isCollapsed = false;
  public itemClasses : Array<string> = ["", "", "", "", "", "", ""];
  public roundClass : string;
  
  ngOnInit(): void {
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
