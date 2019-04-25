
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HistoryRoutingModule } from './history-routing.module';
import { HistoryGamesComponent } from '../components/history-games/history-games.component';
import { RoundDetailsComponent } from '../components/history-games/round-details/round-details.component';

@NgModule({
    declarations: [
        HistoryGamesComponent,
        RoundDetailsComponent
      ],
  imports: [
    CommonModule,
    HistoryRoutingModule,
    NgbModule
  ],
})
export class HistoryModule { }