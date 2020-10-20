import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import{HeaderComponent} from './header/header.component'
import{CustomerFormComponent} from './customer-form/customer-form.component'
const routes: Routes = [];
const appRoutes:Routes=[

  /*Route State*/ {path:"" ,redirectTo:'/header' , pathMatch:'full'},
  {path:"/header",component:HeaderComponent},
  {path:"/customerForm",component:CustomerFormComponent}

  ];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
