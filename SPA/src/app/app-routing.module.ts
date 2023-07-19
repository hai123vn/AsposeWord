import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormInputComponent } from './views/form-input/form-input.component';
import { MainListComponent } from './views/main-list/main-list.component';

const routes: Routes = [
  {
    path: '',
    component: MainListComponent
  },
  {
    path: 'upload/:key',
    component: FormInputComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
