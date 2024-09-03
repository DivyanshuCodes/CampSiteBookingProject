import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminviewComponent } from './Components/adminview/adminview.component';
import { BookingscreenComponent } from './Components/bookingscreen/bookingscreen.component';
import { DashboardComponent } from './Components/dashboard/dashboard.component';
import { LoginComponent } from './Components/login/login.component';
import { LogoutComponent } from './Components/logout/logout.component';
import { ManageBookingComponent } from './Components/manage-booking/manage-booking.component';

import { SignupComponent } from './Components/signup/signup.component';
import { TrialComponent } from './Components/trial/trial.component';

const routes: Routes = [
  {
    path:'',component:DashboardComponent
  },
  {
    path:'bs',component:BookingscreenComponent
  },
  {
    path:'signup',component:SignupComponent
  },
  {
    path:'login',component:LoginComponent
  },
  {
    path:'admin',component:AdminviewComponent
  },
  {
    path:'trial',component:TrialComponent
  },
  {
    path:'mb',component:ManageBookingComponent
  },
  {
    path:'log',component:LogoutComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
