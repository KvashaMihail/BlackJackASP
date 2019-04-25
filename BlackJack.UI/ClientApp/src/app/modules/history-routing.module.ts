import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HistoryGamesComponent } from '../components/history-games/history-games.component';





const routes: Routes = [
    {path: '', component: HistoryGamesComponent}
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class HistoryRoutingModule { }