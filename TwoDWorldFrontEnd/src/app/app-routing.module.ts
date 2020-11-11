import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TitleComponent } from './Components/title/title.component';
import { TitlesListComponent } from './Components/titles-list/titles-list.component';


const routes: Routes = [
  { path: '', component: TitlesListComponent,pathMatch: "full" },
  { path: 'title/:id', component: TitleComponent,pathMatch: "full" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
