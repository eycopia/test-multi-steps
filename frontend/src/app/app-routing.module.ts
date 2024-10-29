import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { Step1Component } from './step1/step1.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'step1', component: Step1Component },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
