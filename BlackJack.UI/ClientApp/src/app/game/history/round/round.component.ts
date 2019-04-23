import { Component, Input, OnInit } from '@angular/core';
import { Round } from 'src/app/_models/Round';

@Component({
  selector: 'app-round',
  templateUrl: './round.component.html',
  styleUrls: ['./round.component.scss']
})
export class RoundComponent {
  
  @Input() round : Round;

}
