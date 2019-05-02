
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HistoryRoutingModule } from './history.routing.module';
import { HistoryGamesComponent } from './history.games.component/history.games.component';
import { RoundDetailsComponent } from './history.games.component/round.details.component/round.details.component';

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